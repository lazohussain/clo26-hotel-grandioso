# Hotel Grandioso — Inlämning 1

Lazo Hussai

## Så kör du projektet

1. Forka repot på GitHub och klona din fork
2. Öppna `HotelGrandioso.slnx` i Visual Studio (eller öppna mappen i VS Code)
3. Tryck **F5** för att starta

Via terminalen:

```bash
dotnet run --project HotelGrandioso
```

## Databas

- Databas: SQLite
-Migrationer skapas och körs med Entity Framework Core.
dotnet ef migrations add InitialCreate
dotnet ef database update

## UML-klassdiagram

```mermaid
lassDiagram
    class Guest {
        +int Id
        +string FirstName
        +string LastName
        +string Email
        +string PhoneNumber
        +List~Booking~ Bookings
    }

    class Booking {
        +int Id
        +int GuestId
        +DateTime CheckIn
        +DateTime Checkout
        +int RoomId
    }

    class Room {
        +int Id
        +int RoomNumber
        +int Floor
        +double SizeM2
        +decimal PricePerNight
        +int RoomTypeId
    }

    class RoomType {
        +int Id
        +string Name
        +string Description
        +List~Room~ Rooms
    }

    Guest "1" --> "0..*" Booking
    Room "1" --> "0..*" Booking
    RoomType "1" --> "0..*" Room
```

## GDPR

FirstName: Används för att identifiera gästen.

LastName: Används för att identifiera gästen.

Email: Behövs för att kunna kontakta gästen angående bokningen.

PhoneNumber: Behövs för att kunna kontakta gästen vid frågor eller ändringar.
Jag valde att använda personuppgifter som enbart är relevanta för bokningshanteringen. Detta följer principen om dataminimering enligt GDPR lagen.

## Designmönster

Projektet använder Repository-mönstret för att separera databaslogik från övrig programlogik.
Genom att använda ett repository kan programmet kommunicera med databasen via separata metoder istället för att hantera all databaskod direkt i huvudprogrammet. 
Detta gör koden mer strukturerad och lättare att underhålla.
>

## Tekniker

- C# / .NET 10
- Entity Framework Core
- SQLite
- Github
