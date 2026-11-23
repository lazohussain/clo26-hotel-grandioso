using HotelGrandioso.Data;
using HotelGrandioso.Models;
namespace HotelGrandioso.Services;

public class BookingRepository
{
    public void BookRoom(int roomNumber, DateTime checkIn, DateTime checkOut,
        string firstName, string lastName, string email, string phoneNumber)
    {
        using var db = new HotelDbContext();

        var selectedRoom = db.Rooms
            .FirstOrDefault(r => r.RoomNumber == roomNumber);

        if (selectedRoom == null)
        {
            Console.WriteLine("Rummet finns inte.");
            return;
        }

        if (checkOut <= checkIn)
        {
            Console.WriteLine("Utcheckningsdatum måste vara efter incheckningsdatum.");
            return;
        }

        bool isBooked = db.Bookings.Any(b =>
            b.RoomId == selectedRoom.Id &&
            b.CheckIn < checkOut &&
            b.Checkout > checkIn);

        if (isBooked)
        {
            Console.WriteLine("Rummet är redan bokat under dessa datum.");
            return;
        }

        var guest = new Guest
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber
        };

        db.Guests.Add(guest);
        db.SaveChanges();

        var booking = new Booking
        {
            GuestId = guest.Id,
            RoomId = selectedRoom.Id,
            CheckIn = checkIn,
            Checkout = checkOut
        };

        db.Bookings.Add(booking);
        db.SaveChanges();

        Console.WriteLine("Bokningen har sparats!");
        Console.WriteLine("Gästen har sparats!");
    }
}