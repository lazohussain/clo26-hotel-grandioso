
using Microsoft.EntityFrameworkCore;
using HotelGrandioso.Data;
using HotelGrandioso.Models;

namespace HotelGrandioso.Services;

public class BookingRepository : IBookingRepository{
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

        int numberOfNights = (checkOut - checkIn).Days;

        decimal totalPrice = numberOfNights * selectedRoom.PricePerNight;

        var booking = new Booking
        {
            GuestId = guest.Id,
            RoomId = selectedRoom.Id,
            CheckIn = checkIn,
            Checkout = checkOut,
            TotalPrice = totalPrice
        };

        db.Bookings.Add(booking);
        db.SaveChanges();

        Console.WriteLine("Bokningen har genomförts!");
        Console.WriteLine("Gästen har sparats!");
        Console.WriteLine($"Rum: {selectedRoom.RoomNumber}");
        Console.WriteLine($"Antal nätter: {numberOfNights}");
        Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight} kr");
        Console.WriteLine($"TOTALPRIS: {totalPrice} kr");
    }

    public void CancelBooking(int bookingId)
    {
        using var db = new HotelDbContext();

        var booking = db.Bookings
            .FirstOrDefault(b => b.Id == bookingId);

        if (booking == null)
        {
            Console.WriteLine("Bokningen hittades inte.");
            return;
        }

        db.Bookings.Remove(booking);
        db.SaveChanges();

        Console.WriteLine("Bokningen har avbokats!");
    }

    public void ShowAllBookings()
    {
        using var db = new HotelDbContext();

        var allBookings = db.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Room)
            .ToList();

        if (allBookings.Count == 0)
        {
            Console.WriteLine("Det finns inga bokningar.");
            return;
        }

        foreach (var booking in allBookings)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Boknings-ID: {booking.Id}");
            Console.WriteLine($"Gäst: {booking.Guest.FirstName} {booking.Guest.LastName}");
            Console.WriteLine($"Rum: {booking.Room.RoomNumber}");
            Console.WriteLine($"Incheckning: {booking.CheckIn:yyyy-MM-dd}");
            Console.WriteLine($"Utcheckning: {booking.Checkout:yyyy-MM-dd}");
            Console.WriteLine($"Totalpris: {booking.TotalPrice} kr");
        }
    }

    public void ShowAllRooms()
    {
        using var db = new HotelDbContext();

        var allRooms = db.Rooms
            .Include(r => r.RoomType)
            .ToList();

        if (allRooms.Count == 0)
        {
            Console.WriteLine("Det finns inga rum i databasen.");
            return;
        }

        foreach (var room in allRooms)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Rum: {room.RoomNumber}");
            Console.WriteLine($"Våning: {room.Floor}");
            Console.WriteLine($"Storlek: {room.SizeM2} m²");
            Console.WriteLine($"Pris: {room.PricePerNight} kr");
            Console.WriteLine($"Rumstyp: {room.RoomType.Name}");
        }
    }
}
