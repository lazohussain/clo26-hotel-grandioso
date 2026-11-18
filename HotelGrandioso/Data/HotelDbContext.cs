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
        optionsBuilder.UseSqlite("Data Source=/Users/lazo/RiderProjects/clo26-hotel-grandioso/HotelGrandioso/hotel.db");
    }
}