
using HotelGrandioso.Models;

namespace HotelGrandioso.Data;

public static class HotelSeeder
{
    public static void Seed(HotelDbContext db)
    {
        var standard = db.RoomTypes.FirstOrDefault(r => r.Name == "Standard");

        if (standard == null)
        {
            standard = new RoomType
            {
                Name = "Standard",
                Description = "Standardrum"
            };

            db.RoomTypes.Add(standard);
        }

        var lyxsvit = db.RoomTypes.FirstOrDefault(r => r.Name == "Lyxsvit");

        if (lyxsvit == null)
        {
            lyxsvit = new RoomType
            {
                Name = "Lyxsvit",
                Description = "Lyxig svit"
            };

            db.RoomTypes.Add(lyxsvit);
        }

        var brollopssvit = db.RoomTypes.FirstOrDefault(r => r.Name == "Bröllopsvit");

        if (brollopssvit == null)
        {
            brollopssvit = new RoomType
            {
                Name = "Bröllopsvit",
                Description = "Exklusiv bröllopssvit"
            };

            db.RoomTypes.Add(brollopssvit);
        }

        db.SaveChanges();

        var rooms = new List<Room>();

        for (int i = 101; i <= 105; i++)
        {
            rooms.Add(new Room
            {
                RoomNumber = i,
                Floor = 1,
                SizeM2 = 80,
                PricePerNight = 800,
                RoomType = standard
            });
        }

        for (int i = 201; i <= 205; i++)
        {
            rooms.Add(new Room
            {
                RoomNumber = i,
                Floor = 2,
                SizeM2 = 100,
                PricePerNight = 1000,
                RoomType = standard
            });
        }

        for (int i = 301; i <= 303; i++)
        {
            rooms.Add(new Room
            {
                RoomNumber = i,
                Floor = 3,
                SizeM2 = 120,
                PricePerNight = 1200,
                RoomType = standard
            });
        }

        rooms.Add(new Room
        {
            RoomNumber = 304,
            Floor = 3,
            SizeM2 = 180,
            PricePerNight = 2800,
            RoomType = lyxsvit
        });

        rooms.Add(new Room
        {
            RoomNumber = 305,
            Floor = 3,
            SizeM2 = 220,
            PricePerNight = 3500,
            RoomType = brollopssvit
        });

        foreach (var room in rooms)
        {
            if (!db.Rooms.Any(r => r.RoomNumber == room.RoomNumber))
            {
                db.Rooms.Add(room);
            }
        }

        db.SaveChanges();
    }
}
