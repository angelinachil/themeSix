using System;
using System.Globalization;

public class ParsingExample
{
    public static void Main(string[] args)
    {
        // Пример строк с датами
        string dateString1 = "2024-03-15";
        string dateString2 = "15/03/2024";
        string dateString3 = "March 15, 2024"; // Дата на английском языке
        string dateString4 = "Неверная дата";
        string dateString5 = "15.03.2024";


        // Переменные типа DateTime для хранения результатов парсинга
        DateTime parsedDate;
        DateTime parsedDateExact;


        // Метод Parse(): Простой парсинг, использует текущую культуру
        try
        {
            parsedDate = DateTime.Parse(dateString1);
            Console.WriteLine($"Parse(\"{dateString1}\"): {parsedDate}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Parse(\"{dateString1}\"): FormatException - Не удалось разобрать строку даты.");
        }


        // Метод ParseExact(): Парсинг с указанным форматом
        try
        {
            parsedDateExact = DateTime.ParseExact(dateString2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine($"ParseExact(\"{dateString2}\", \"dd/MM/yyyy\"): {parsedDateExact}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"ParseExact(\"{dateString2}\", \"dd/MM/yyyy\"): FormatException - Строка даты не соответствует указанному формату.");
        }


        // Метод TryParse(): Пытается разобрать строку, возвращает true/false
        if (DateTime.TryParse(dateString3, out parsedDate))
        {
            Console.WriteLine($"TryParse(\"{dateString3}\"): {parsedDate}");
        }
        else
        {
            Console.WriteLine($"TryParse(\"{dateString3}\"): Не удалось разобрать строку даты.");
        }

        // Метод TryParseExact(): Пытается разобрать строку с указанным форматом
        if (DateTime.TryParseExact(dateString5, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateExact))
        {
            Console.WriteLine($"TryParseExact(\"{dateString5}\", \"dd.MM.yyyy\"): {parsedDateExact}");
        }
        else
        {
            Console.WriteLine($"TryParseExact(\"{dateString5}\", \"dd.MM.yyyy\"): Не удалось разобрать строку даты.");
        }


        //Обработка неверной строки даты
        if (DateTime.TryParse(dateString4, out parsedDate))
        {
            Console.WriteLine($"TryParse(\"{dateString4}\"): {parsedDate}");
        }
        else
        {
            Console.WriteLine($"TryParse(\"{dateString4}\"): Не удалось разобрать строку даты. Это ожидаемо.");
        }

        //Демонстрация TryParse с русской культурой
        CultureInfo myCulture = new CultureInfo("ru-RU"); // Русская культура
        if (DateTime.TryParse(dateString1, myCulture, DateTimeStyles.None, out parsedDate))
        {
            Console.WriteLine($"TryParse(\"{dateString1}\" с культурой ru-RU): {parsedDate}");
        }
        else
        {
            Console.WriteLine($"TryParse(\"{dateString1}\" с культурой ru-RU): Не удалось разобрать. Обратите внимание на формат даты: \"{dateString1}\" - он не соответствует стандартному формату для русской культуры.");
        }

    }
}



