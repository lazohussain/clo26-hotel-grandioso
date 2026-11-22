# Data

Här ligger databaskopplingen.

- **EF Core:** en `DbContext`-klass och eventuella migrationer. Connectionstring läses från miljövariabel eller en lokal fil som ligger i `.gitignore`, aldrig i koden.
- **MongoDB:** en klass som samlar anslutningen och en klass per collection.
- **Serverdatabas:** starta med Docker eller använd en gratis onlineinstans. Beskriv hur i projektets README.

Ingen ADO.NET. Använd EF Core eller MongoDB.

Hotel Grandioso — Inlämning 1
Namn: [ditt namn]

Så kör du projektet
Forka repot på GitHub och klona din fork
Öppna HotelGrandioso.slnx i Visual Studio (eller öppna mappen i VS Code)
Tryck F5 för att starta
Via terminalen:

dotnet run --project HotelGrandioso
Databas
Databas: [SQLite eller LocalDB]
Migrationer: [hur du skapar och kör dem]
UML-klassdiagram
Parse error on line 3:
classDiagram
------------^
Expecting 'acc_title', 'acc_descr', 'acc_descr_multiline_value', 'NAMESPACE', 'ANNOTATION_START', 'CLASS', 'MEMBER', 'SEPARATOR', 'NOTE_FOR', 'NOTE', 'CLASSDEF', 'ALPHA', 'direction_tb', 'direction_bt', 'direction_rl', 'direction_lr', 'CALLBACK', 'LINK', 'CLICK', 'STYLE', 'CSSCLASS', 'NUM', 'MINUS', 'UNICODE_TEXT', 'BQUOTE_STR', got 'EOF'
GDPR
Utvärdera fälten i Guest ett i taget. Vad bygger du in, och varför?

Designmönster
Beskriv det designmönster du använt (till exempel Repository), vad det gör och varför du valde det.

Tekniker
C# / .NET 10
Entity Framework Core