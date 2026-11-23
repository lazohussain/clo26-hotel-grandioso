namespace HotelGrandioso.Models;

public class Booking
{
    public int Id  { get; set; }
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    public DateTime CheckIn { get; set; }
    public DateTime Checkout { get; set; }
    public decimal TotalPrice { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
}
