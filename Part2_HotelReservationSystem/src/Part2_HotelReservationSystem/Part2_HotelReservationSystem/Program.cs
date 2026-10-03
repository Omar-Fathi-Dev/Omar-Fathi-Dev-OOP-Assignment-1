namespace Part2_HotelReservationSystem;

class Program
{
    static void Main(string[] args)
    {
        #region Setup

        Console.WriteLine("=== Setup ===");
        var room101 = new Room(101, RoomType.Double, 500m);
        var room102 = new Room(102, RoomType.Single, 300m);
        var ahmed = new Guest("ahmed Ali", "01012345678");
        var omar = new Guest("Omar Fathi", "01198765432");
        Console.WriteLine(room101);
        Console.WriteLine(room102);
        Console.WriteLine(ahmed);
        Console.WriteLine(omar);

        #endregion

        #region Booking

        Console.WriteLine("\n=== Booking ===");
        Reservation booking = ahmed.MakeReservation(room101, new DateOnly(2026, 10, 10), new DateOnly(2026, 10, 15));
        Console.WriteLine(booking);   
        #endregion

        #region Status changes

        Console.WriteLine("\n=== Status ===");
 
        try
        {
            booking.CheckIn();
            Console.WriteLine("OK: check in");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: check in before confirming -> " + ex.Message);
        }
 
        try
        {
            booking.Confirm();
            Console.WriteLine("OK: confirm");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: confirm -> " + ex.Message);
        }
 
        try
        {
            booking.CheckIn();
            Console.WriteLine("OK: check in");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: check in -> " + ex.Message);
        }
 
        try
        {
            booking.Cancel();
            Console.WriteLine("OK: cancel");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: cancel after check-in -> " + ex.Message);
        }
 
        try
        {
            booking.CheckOut();
            Console.WriteLine("OK: check out");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: check out -> " + ex.Message);
        }
 
        try
        {
            booking.CheckIn();
            Console.WriteLine("OK: check in again");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: check in after check-out -> " + ex.Message);
        }
 
        Console.WriteLine("Final status: " + booking.Status);

        #endregion

        #region Dates

        
        Console.WriteLine("\n=== Dates ===");
        try
        {
            omar.MakeReservation(room102, new DateOnly(2026, 12, 20), new DateOnly(2026, 12, 18));
            Console.WriteLine("OK: reservation created");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: check-out before check-in -> " + ex.Message);
        }


        #endregion

        #region Double booking

        Console.WriteLine("\n=== Double booking ===");
        Reservation first = ahmed.MakeReservation(room102, new DateOnly(2026, 11, 1), new DateOnly(2026, 11, 5));
        Console.WriteLine("Ahmed booked room 102 from 11-01 to 11-05");
 
        try
        {
            omar.MakeReservation(room102, new DateOnly(2026, 11, 3), new DateOnly(2026, 11, 7));
            Console.WriteLine("OK: overlapping reservation created");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: overlapping dates -> " + ex.Message);
        }
 
        try
        {
            omar.MakeReservation(room102, new DateOnly(2026, 11, 5), new DateOnly(2026, 11, 8));
            Console.WriteLine("OK: starts the day the first one ends");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: starts the day the first one ends -> " + ex.Message);
        }
 
        first.Cancel();
        Console.WriteLine("Ahmed cancelled his reservation");
 
        try
        {
            omar.MakeReservation(room102, new DateOnly(2026, 11, 2), new DateOnly(2026, 11, 4));
            Console.WriteLine("OK: same dates after the cancellation");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: same dates after the cancellation -> " + ex.Message);
        }


        #endregion

        #region Maintenance

        Console.WriteLine("\n=== Maintenance ===");
        room101.StartMaintenance();
 
        try
        {
            omar.MakeReservation(room101, new DateOnly(2027, 1, 5), new DateOnly(2027, 1, 8));
            Console.WriteLine("OK: reservation created");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: room under maintenance -> " + ex.Message);
        }
 
        room101.EndMaintenance();
 
        try
        {
            omar.MakeReservation(room101, new DateOnly(2027, 1, 5), new DateOnly(2027, 1, 8));
            Console.WriteLine("OK: reservation after maintenance ended");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: reservation after maintenance -> " + ex.Message);
        }


        #endregion

        #region Pricing

        Console.WriteLine("\n=== Pricing ===");
 
        try
        {
            room101.ChangeRate(600m);
            Console.WriteLine("OK: new rate = " + room101.NightlyRate);
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: rate 600 -> " + ex.Message);
        }
 
        try
        {
            room101.ChangeRate(0m);
            Console.WriteLine("OK: rate 0");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: rate 0 -> " + ex.Message);
        }
 
        try
        {
            room101.ChangeRate(-50m);
            Console.WriteLine("OK: rate -50");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: rate -50 -> " + ex.Message);
        }


        #endregion

        #region Guest validation

        Console.WriteLine("\n=== Guest validation ===");
 
        try
        {
            Guest g = new Guest("", "01012345678");
            Console.WriteLine("OK: empty name accepted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: empty name -> " + ex.Message);
        }
 
        try
        {
            Guest g = new Guest("Test", "0101234567");
            Console.WriteLine("OK: 10 digits accepted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: phone with 10 digits -> " + ex.Message);
        }
 
        try
        {
            Guest g = new Guest("Test", "0101234567a");
            Console.WriteLine("OK: phone with a letter accepted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: phone with a letter -> " + ex.Message);
        }
 
        try
        {
            Guest g = new Guest("Test", "11012345678");
            Console.WriteLine("OK: phone starting with 1 accepted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("REJECTED: phone starting with 1 -> " + ex.Message);
        }


        #endregion

        #region History

        Console.WriteLine("\n=== Ahmed's reservations ===");
        foreach (Reservation r in ahmed.Reservations)
        {
            Console.WriteLine(r);
        }


        #endregion
        
        

    }
}