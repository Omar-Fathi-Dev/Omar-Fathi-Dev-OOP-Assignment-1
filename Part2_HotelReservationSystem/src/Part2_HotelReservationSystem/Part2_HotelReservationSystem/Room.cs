namespace Part2_HotelReservationSystem;

public class Room
{
    private readonly List<Reservation> _reservations = new();
    
    public int RoomNumber { get; }
    public RoomType RoomType { get;  }
    public decimal NightlyRate {get; private set;}
    public bool IsUnderMaintenance{get; private set;}
    

    public Room(int roomNumber, RoomType roomType , decimal  nightlyRate)
    {
        if(roomNumber < 1) throw new ArgumentException("Room Number cannot be less than 1.");
        
        (RoomNumber, RoomType) = (roomNumber,roomType);
        ChangeRate(nightlyRate);
    }

    public void ChangeRate(decimal rate)
    {
        if(rate <= 0) throw new ArgumentException("Rate cannot be negative  or zero.");
        
        NightlyRate = rate;
    }

    public void StartMaintenance() => IsUnderMaintenance = true;
    public void EndMaintenance() => IsUnderMaintenance = false;
    
    
    internal void AddReservation(Reservation reservation)
    {
        if (IsUnderMaintenance)
            throw new InvalidOperationException($"Room {RoomNumber} is under maintenance.");

        foreach (var r in _reservations)
        {
            if (r.IsActive &&
                r.Overlaps(reservation.CheckInDate, reservation.CheckOutDate))
                throw new InvalidOperationException(
                    $"Room {RoomNumber} is already booked from {r.CheckInDate} to {r.CheckOutDate}.");
        }

        _reservations.Add(reservation);
    }
    
    
    
    public override string ToString()
    {
        return $"{RoomNumber} - {RoomType} -  {NightlyRate} - {IsUnderMaintenance}";
    }
}


