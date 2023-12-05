// See https://aka.ms/new-console-template for more information

void Main()
{
    Console.WriteLine("Üdvözöllek a Színözön játékban!");

    Random random = new Random();
    List<int> secretCode = new List<int>();
    for (int i = 0; i < 4; i++)
    {
        secretCode.Add(random.Next(1, 7));
    }

    int attempts = 0;
    bool guessed = false;

    while (!guessed && attempts < 10)
    {
        Console.Write("\nTippeljen egy 4 számjegyből álló számot (1-6 között): ");
        string guessString = Console.ReadLine();

        if (guessString.Length != 4)
        {
            Console.WriteLine("Érvénytelen hosszúságú tipp. 4 számot adjon meg!");
            continue;
        }

        bool validInput = true;
        foreach (char c in guessString)
        {
            if (!char.IsDigit(c) || c < '1' || c > '6')
            {
                validInput = false;
                break;
            }
        }

        if (!validInput)
        {
            Console.WriteLine("Csak számjegyeket (1-6 között) adj meg!");
            continue;
        }

        List<int> guess = new List<int>();
        foreach (char c in guessString)
        {
            guess.Add(int.Parse(c.ToString()));
        }

        int exactMatches = 0;
        int partialMatches = 0;

        for (int i = 0; i < 4; i++)
        {
            if (secretCode[i] == guess[i])
            {
                exactMatches++;
            }
            else if (secretCode.Contains(guess[i]))
            {
                partialMatches++;
            }
        }

        Console.WriteLine($"Találatok: {exactMatches} helyes és {partialMatches} részleges.");

        if (exactMatches == 4)
        {
            guessed = true;
            Console.WriteLine("Gratulálok, eltaláltad a kódot!");
        }

        attempts++;
    }

    if (!guessed)
    {
        Console.WriteLine("Sajnos nem sikerült eltalálni a kódot. A helyes kód: " + string.Join("", secretCode));
    }

    Console.WriteLine("\nKöszönöm, hogy játszottál!");
}

Main();