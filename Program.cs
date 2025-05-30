using System;
using System.Collections.Generic;

class Program
{
    // Lista wszystkich stworzonych chættbått’er
    static List<ChatBått> chatBåtts = new List<ChatBått>();

    static void Main(string[] args)
    {
        bool play = true;

        while (play)
        {
            ShowMenu();
        }
    }

    // Wyświetla menu główne
     static void ShowMenu()
    {
        Console.Clear(); // Czyści ekran konsoli
        Console.WriteLine("=== Velkommen til Chættbått 3000 ===");
        Console.WriteLine("1. Lag en ny chættbått");
        Console.WriteLine("2. Snakk med en chættbått");
        Console.WriteLine("3. Avslutt");
        Console.Write("Velg et alternativ (1-3): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateChatBått();
                break;
            case "2":
                TalkToChatbot();
                break;
            case "3":
                Console.WriteLine("Avslutter programmet. Ha det!");
                Environment.Exit(0); // Zamyka aplikację
                break;
            default:
                Console.WriteLine("Ugyldig valg. Trykk ENTER for å fortsette.");
                Console.ReadLine();
                break;
        }
    }

    // Klasa reprezentująca chættbått
    class ChatBått
    {
        public string Name { get; set; }
        List<string> Replies { get; set; } = new List<string>();
        Random random = new Random();

        public ChatBått(string name)
        {
            Name = name;
        }

        // Dodaje odpowiedź do bazy chattbåtta
        public void AddReply(string reply)
        {
            Replies.Add(reply);
        }

        // Zwraca losową odpowiedź
        public string GetRandomReply()
        {
            if (Replies.Count == 0)
            {
                return $"{Name}: Jeg har ingenting å si ennå...";
            }
            int index = random.Next(Replies.Count);
            return $"{Name}: {Replies[index]}";
        }
    }

    // Tworzy nowego chattbåtta
    static void CreateChatBått()
    {
        Console.Clear();
        Console.Write("Skriv inn navnet til chættbått’en: ");
        string chatBåttName = Console.ReadLine();
        ChatBått bot = new ChatBått(chatBåttName);

        Console.WriteLine($"Legg til svar for {chatBåttName} (skriv 'slutt' for å avslutte):");
        while (true)
        {
            Console.Write("> ");
            string reply = Console.ReadLine();
            if (reply.ToLower() == "slutt")
            {
                break;
            }
            bot.AddReply(reply);
        }

        chatBåtts.Add(bot); // Dodajemy bota do listy
        Console.WriteLine($"Chættbått '{chatBåttName}' ble lagret! Trykk ENTER.");
        Console.ReadLine();
    }

    // Rozmowa z wybranym chattbåttem
    static void TalkToChatbot()
    {
        if (chatBåtts.Count == 0)
        {
            Console.WriteLine("Ingen chættbått’er tilgjengelige. Lag en først.");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine("Tilgjengelige chættbått’er:");
        for (int i = 0; i < chatBåtts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {chatBåtts[i].Name}");
        }

        Console.Write("Velg nummeret til chættbått’en du vil snakke med: ");
        if (int.TryParse(Console.ReadLine(), out int choice) &&
            choice >= 1 && choice <= chatBåtts.Count)
        {
            ChatBått selected = chatBåtts[choice - 1];
            Console.WriteLine($"Du snakker med {selected.Name}. Skriv noe (skriv 'slutt' for å avslutte):");

            while (true)
            {
                Console.Write("Du: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "slutt")
                    break;
                Console.WriteLine(selected.GetRandomReply());
            }
        }
        else
        {
            Console.WriteLine("Ugyldig valg.");
        }

        Console.WriteLine("Trykk ENTER for å gå tilbake til menyen.");
        Console.ReadLine();
    }
}
