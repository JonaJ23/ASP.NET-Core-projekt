# README om ASP.NET Core. 🖥️

ASP.NET Core är en fri programvara med öppen källkod som används för att skapa 
dynamiska webbsidor med bl.a. användning av cloud-lagring och Razor Pages.
Förrutom Windows så är ASP.NET Core även kompatibel med Linux och MacOS.

En Razor Pages applikation består oftast av flera modelklasser 
som lagrar properties i en databas med hjälp av olika tabeller. 
Dessa tabeller har alltid en PRIMARY KEY som används för 
identifikation. Om tabellerna ska sammanlänkas så behövs 
också en FOREIGN KEY som använder varandras ID (PRIMARY KEY) 
för att kommuniceras.

En MVC applikation styrs av tre olika delar: Model, View och Controller.
Alla tre fungerar i en slags cirkulation.

1. Model är ansvarig för applikationens tillstånd och meddelar
   data som uppdaterats till View.

2. View hämtar data från Model och uppdaterar sig själv
   för användaren att se.

3. Controller får meddelande från View att hantera
   en ny händelse och kan sedan uppdatera Model.
