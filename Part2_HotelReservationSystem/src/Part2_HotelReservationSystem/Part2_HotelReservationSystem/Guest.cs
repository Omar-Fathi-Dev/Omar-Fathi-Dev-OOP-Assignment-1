namespace Part2_HotelReservationSystem;

public class Guest
{
    private static int _nextId = 1;
    private readonly List<Reservation> _reservations = new();
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public int GuestId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }
    
    
    public Guest(string fullName , string phoneNumber)
    {
        if(string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full Name cannot be empty.");
        ValidatePhone(phoneNumber);
        
        (GuestId , FullName , PhoneNumber) = (_nextId++, fullName, phoneNumber);
    }
    
    
    private static void ValidatePhone(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number cannot be empty.");
        if (phoneNumber.Length != 11)
            throw new ArgumentException("Phone number must be 11 digits.");

        for (int i = 0; i < phoneNumber.Length; i++)
        {
            if (phoneNumber[i] < '0' || phoneNumber[i] > '9')
                throw new ArgumentException("Phone number must contain digits only.");
        }

        if (phoneNumber[0] != '0')
            throw new ArgumentException("Phone number must start with 0.");
        if (phoneNumber[1] != '1')
            throw new ArgumentException("Second digit must be 1.");

        char third = phoneNumber[2];
        if (third != '0' && third != '1' && third != '5' && third != '2')
            throw new ArgumentException("Third digit must be 0, 1, 2, or 5.");
    }
    
    public Reservation MakeReservation(Room room, DateOnly checkIn, DateOnly checkOut)
    {
        var reservation = new Reservation(checkIn, checkOut, room);
        _reservations.Add(reservation);
        return reservation;
    }
    

    public Reservation? GetReservation(int reservationId)
    {
        foreach (var reservation in _reservations)
            if(reservation.ReservationId == reservationId)
                return reservation;
        return null;
    }


    public override string ToString()
    {
        return $"{GuestId} - {FullName} - {PhoneNumber} ";
    }
}


