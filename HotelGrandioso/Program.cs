
using Microsoft.EntityFrameworkCore;
using HotelGrandioso.Data;
using HotelGrandioso.UI;
using HotelGrandioso.Services;

using var db = new HotelDbContext();

db.Database.Migrate();

HotelSeeder.Seed(db);

while (true)
{
    var choice = ConsoleMenu.ShowMenu();

    switch (choice)
    {
        case "1":
            Console.Write("Ange rumsnummer: ");
            if (!int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Console.WriteLine("Ogiltigt rumsnummer.");
                break;
            }

            Console.Write("Ange incheckningsdatum (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime checkIn))
            {
                Console.WriteLine("Ogiltigt incheckningsdatum.");
                break;
            }

            Console.Write("Ange utcheckningsdatum (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime checkOut))
            {
                Console.WriteLine("Ogiltigt utcheckningsdatum.");
                break;
            }

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
            if (!int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.WriteLine("Ogiltigt boknings-ID.");
                break;
            }

            var cancelRepository = new BookingRepository();
            cancelRepository.CancelBooking(bookingId);
            break;

        case "5":
            Console.WriteLine("Programmet avslutas.");
            return;

        default:
            Console.WriteLine("Ogiltigt val.");
            break;
    }
}
