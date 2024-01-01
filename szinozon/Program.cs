// See https://aka.ms/new-console-template for more information
Console.WriteLine("Üdvözöllek a Mastermind játékban!");
Console.WriteLine("1 vagy 2 játekos mód?(1/2)");
string oneOrTwo = Console.ReadLine();



if (oneOrTwo == "1")
{
    Egyszemelyes();
}
else if (oneOrTwo == "2")
{
    Ketszemelyes();
}



void Egyszemelyes()
{
    

    List<string> availableColors = new List<string>
        {
            "piros", "kék", "zöld", "sárga", "lila", "narancssárga"
        };

    Random random = new Random();
    List<string> secretCode = new List<string>();
    for (int i = 0; i < 4; i++)
    {
        int index = random.Next(0, availableColors.Count);
        secretCode.Add(availableColors[index]);
    }

    int attempts = 0;
    bool guessed = false;

    while (!guessed && attempts < 10)
    {
        Console.WriteLine("\nTippelj négy színt az alábbiak közül: (Piros, Kék, Zöld, Sárga, Lila, Narancssárga) :");
        List<string> guess = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Tipp {i + 1}: ");
            string colorChoice = GetValidColorChoice(availableColors);
            guess.Add(colorChoice);
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
        Console.WriteLine("Sajnos nem sikerült eltalálni a kódot. A helyes kód: " + string.Join(", ", secretCode));
    }

    Console.WriteLine("\nKöszönöm, hogy játszottál!");
}

string GetValidColorChoice(List<string> availableColors)
{
    while (true)
    {
        string input = Console.ReadLine().Trim().ToLower();
        if (availableColors.Contains(input))
        {
            return input;
        }
        else
        {
            Console.WriteLine("Érvénytelen szín! Válassz a következők közül: " + string.Join(", ", availableColors));
        }
    }
}





void Ketszemelyes()
{
    string[] ketszinek = new string[4];
    string[] kettippek = new string[4];
    string vagaselott = "";
    int joszin = 0;
    int mindenjo = 0;
    int tokeletes = 0;


        Console.WriteLine("Adja meg a 4 színt:");

        for (int i = 0; i < ketszinek.Length; i++)
        {
            Console.WriteLine($"{i + 1}. szín: ");

            var jelszo = string.Empty;
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
            ketszinek[i] = jelszo;
            Console.WriteLine();

        }
        List<string> vagas = new List<string>();


        do
        {
            vagas.Clear();
            mindenjo = 0;
            joszin = 0;

            Console.WriteLine("Adja meg tippjeit(szóközökkel elválasztva): ");
            vagaselott = Console.ReadLine();

            foreach (var item in vagaselott.Split(' '))
            {
                vagas.Add(item);
            }

            for (int i = 0; i < ketszinek.Length; i++)
            {
                if (vagas[i] == ketszinek[i])
                {
                    mindenjo += 1;
                }
                else if (ketszinek.Contains(vagas[i]))
                {
                    joszin += 1;
                }
            }
            Console.WriteLine($"{mindenjo}db van jó helyen");
            Console.WriteLine($"{joszin}db van van benne rossz helyen");
            Console.WriteLine("\n");
        } while (mindenjo != 4);
        Console.WriteLine("Gratulálok, eltaláltad az összes színt!");

        for (int i = 0; i < ketszinek.Length; i++)
        {
            if (kettippek[i] == ketszinek[i])
            {
                tokeletes += 1;
            }
        }
        if (tokeletes == 4)
        {

        }
}

