namespace Part2_HotelReservationSystem;

public class Reservation
{
    private static int _nextId = 101;
    public int ReservationId {get;}
    public DateOnly CheckInDate {get;}
    public DateOnly CheckOutDate {get;}
    public Room Room {get;}
    public ReservationStatus Status { get; private set; }
    public decimal TotalCost => Room.NightlyRate * (CheckOutDate.DayNumber - CheckInDate.DayNumber);

    internal Reservation(DateOnly checkInDate, DateOnly checkOutDate , Room room)
    {
        if(checkOutDate <= checkInDate)  throw new ArgumentException("CheckOutDate must be strictly after CheckInDate.");
        if (room is null) throw new ArgumentNullException(nameof(room), "Room cannot be null.");
        
        
        (CheckInDate ,  CheckOutDate , Room , Status ) =
            (checkInDate, checkOutDate , room , ReservationStatus.Pending);
        room.AddReservation(this);
        ReservationId = _nextId++; 
    }

    public void Confirm()
    {
        if(Status != ReservationStatus.Pending)
            throw new InvalidOperationException("Reservation is not pending.");
        Status = ReservationStatus.Confirmed;
    }

    public void CheckIn()
    {
        if(Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException("Reservation is not confirmed.");
        Status = ReservationStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if(Status != ReservationStatus.CheckedIn)
            throw new InvalidOperationException("Reservation is not checked in.");
        Status = ReservationStatus.CheckedOut;
    }

    public void Cancel()
    {
        if (Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException("Reservation is not Pending or Confirmed.");
        Status = ReservationStatus.Cancelled;
    }
    
        
    internal bool IsActive =>
        Status != ReservationStatus.Cancelled && Status != ReservationStatus.CheckedOut;

    internal bool Overlaps(DateOnly checkIn, DateOnly checkOut) =>
        checkIn < CheckOutDate && checkOut > CheckInDate;
    


    public override string ToString()
    {
        return $"{ReservationId} - {CheckInDate} - {CheckOutDate} - {Status} - {TotalCost}";
    }
    
    
}