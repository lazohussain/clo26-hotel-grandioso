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