namespace HotelGrandioso.Services;

public interface IBookingRepository
{
    void BookRoom(int roomNumber, DateTime checkIn, DateTime checkOut,
        string firstName, string lastName, string email, string phoneNumber);

    void CancelBooking(int bookingId);

    void ShowAllBookings();

    void ShowAllRooms();
}