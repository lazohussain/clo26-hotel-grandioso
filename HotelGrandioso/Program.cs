using Microsoft.EntityFrameworkCore;
using System.Linq;
using HotelGrandioso.Data;
using HotelGrandioso.Models;
using HotelGrandioso.UI;
using HotelGrandioso.Services;

using var db = new HotelDbContext();

Console.WriteLine(db.RoomTypes.Count());

if (!db.RoomTypes.Any())
{
    Console.WriteLine("Databasen saknar rumstyper.");

    var standard = new RoomType
    {
        Name = "Standard",
        Description = "Standardrum"
    };

    var deluxe = new RoomType
    {
        Name = "Deluxe",
        Description = "Deluxerum"
    };

    db.RoomTypes.AddRange(standard, deluxe);
    db.SaveChanges();
}

var standardType = db.RoomTypes.First(r => r.Name == "Standard");

if (!db.Rooms.Any(r => r.RoomNumber == 101))
{
    var room101 = new Room
    {
        RoomNumber = 101,
        Floor = 1,
        SizeM2 = 25,
        PricePerNight = 1200,
        RoomType = standardType
    };

    db.Rooms.Add(room101);
    db.SaveChanges();
}
var rooms = db.Rooms
    .Include(r => r.RoomType)
    .ToList();

foreach (var room in rooms)
{
    Console.WriteLine($"Rum: {room.RoomNumber}");
    Console.WriteLine($"Våning: {room.Floor}");
    Console.WriteLine($"Storlek: {room.SizeM2} m²");
    Console.WriteLine($"Pris: {room.PricePerNight} kr");
    Console.WriteLine($"Rumstyp: {room.RoomType.Name}");
}
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