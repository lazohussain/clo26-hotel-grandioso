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
        Console.WriteLine("Du har valt att boka rum.");
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