namespace HotelGrandioso.UI;

public class ConsoleMenu
{
    public static string ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== MENY ===");
        Console.WriteLine("1. Boka rum");
        Console.WriteLine("2. Visa alla rum");
        Console.WriteLine("3. Visa alla bokningar");
        Console.WriteLine("4. Avboka");
        Console.WriteLine("5. Avsluta");

        Console.Write("Välj ett alternativ: ");

        return Console.ReadLine()!;
    }
}