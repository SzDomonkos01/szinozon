

var jelszo = string.Empty;
Console.Write("Adjon meg a színeket: ");
ConsoleKey key;
do
{
    var keyInfo = Console.ReadKey(intercept: true);
    key = keyInfo.Key;

    if (key == ConsoleKey.Backspace && jelszo.Length > 0)
    {
        Console.Write("\b \b"); // Így működik
        jelszo = jelszo[0..^1]; // a törlés!
    }
    else if (!char.IsControl(keyInfo.KeyChar))
    {
        Console.Write("*");
        jelszo += keyInfo.KeyChar;
    }
} while (key != ConsoleKey.Enter);


Console.WriteLine("\nA színek: " + jelszo); // Csak, hogy lássam működik-e!!!
