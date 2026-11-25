using Microsoft.EntityFrameworkCore;
using HotelGrandioso.Data;
using HotelGrandioso.UI;
using HotelGrandioso.Services;

using var db = new HotelDbContext();

db.Database.Migrate();

HotelSeeder.Seed(db);

var choice = ConsoleMenu.ShowMenu();

switch (choice)
{
    case "1":
        Console.Write("Ange rumsnummer: ");
        int roomNumber = int.Parse(Console.ReadLine()!);

        Console.Write("Ange incheckningsdatum (yyyy-MM-dd): ");
        DateTime checkIn = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Ange utcheckningsdatum (yyyy-MM-dd): ");
        DateTime checkOut = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Förnamn: ");
        string firstName = Console.ReadLine()!;

        Console.Write("Efternamn: ");
        string lastName = Console.ReadLine()!;

        Console.Write("E-post: ");
        string email = Console.ReadLine()!;

        Console.Write("Telefonnummer: ");
        string phoneNumber = Console.ReadLine()!;

        var repository = new BookingRepository();

        repository.BookRoom(roomNumber, checkIn, checkOut,
            firstName, lastName, email, phoneNumber);
        break;

    case "2":
        var roomRepository = new BookingRepository();
        roomRepository.ShowAllRooms();
        break;

    case "3":
        var bookingRepository = new BookingRepository();
        bookingRepository.ShowAllBookings();
        break;

    case "4":
        Console.Write("Ange boknings-ID: ");
        int bookingId = int.Parse(Console.ReadLine()!);

        var cancelRepository = new BookingRepository();
        cancelRepository.CancelBooking(bookingId);
        break;

    case "5":
        Console.WriteLine("Programmet avslutas.");
        break;

    default:
        Console.WriteLine("Ogiltigt val.");
        break;
}