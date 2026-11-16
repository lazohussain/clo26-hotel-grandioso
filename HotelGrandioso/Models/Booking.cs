namespace HotelGrandioso.Models;

public class Booking
{
    public int Id  { get; set; }
    public int GuestId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime Checkout { get; set; }
    public int RoomId { get; set; }
}
