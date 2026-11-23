using Microsoft.EntityFrameworkCore;
using HotelGrandioso.Models;

namespace HotelGrandioso.Data;

public class HotelDbContext : DbContext
{
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "../../../hotel.db"));

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}