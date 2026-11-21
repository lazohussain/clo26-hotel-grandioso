using Microsoft.EntityFrameworkCore;
using System.Linq;
using HotelGrandioso.Data;
using HotelGrandioso.Models;

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
Console.WriteLine();
Console.WriteLine("=== MENY ===");
Console.WriteLine("1. Boka rum");
Console.WriteLine("2. Visa alla rum");
Console.WriteLine("3. Visa alla bokningar");
Console.WriteLine("4. Avboka");
Console.WriteLine("5. Avsluta");

Console.Write("Välj ett alternativ: ");

var choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.Write("Ange rumsnummer: ");
        int roomNumber = int.Parse(Console.ReadLine()!);

        Console.Write("Ange incheckningsdatum (yyyy-MM-dd): ");
        DateTime checkIn = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Ange utcheckningsdatum (yyyy-MM-dd): ");
        DateTime checkOut = DateTime.Parse(Console.ReadLine()!);

        var selectedRoom = db.Rooms
            .FirstOrDefault(r => r.RoomNumber == roomNumber);

        if (selectedRoom == null)
        {
            Console.WriteLine("Rummet finns inte.");
            break;
        }

        if (checkOut <= checkIn)
        {
            Console.WriteLine("Utcheckningsdatum måste vara efter incheckningsdatum.");
            break;
        }

        bool isBooked = db.Bookings.Any(b =>
            b.RoomId == selectedRoom.Id &&
            b.CheckIn < checkOut &&
            b.Checkout > checkIn
        );

        if (isBooked)
        {
            Console.WriteLine("Rummet är redan bokat under dessa datum.");
        }
        else
        {
            Console.WriteLine("Rummet är ledigt!");
            Console.Write("Förnamn: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Efternamn: ");
            string lastName = Console.ReadLine()!;

            Console.Write("E-post: ");
            string email = Console.ReadLine()!;

            Console.Write("Telefonnummer: ");
            string phoneNumber = Console.ReadLine()!;

            var guest = new Guest
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };
          
            db.Guests.Add(guest);
            db.SaveChanges();

            Console.WriteLine("Gästen har sparats!");

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
          
          
        } 

        break;


    case "2":
        Console.WriteLine("Du har valt att visa alla rum.");
        break;

    case "3":
        Console.WriteLine("Du har valt att visa alla bokningar.");
        break;

    case "4":
        Console.WriteLine("Du har valt att avboka.");
        break;

    case "5":
        Console.WriteLine("Programmet avslutas.");
        break;

    default:
        Console.WriteLine("Ogiltigt val.");
        break;
}