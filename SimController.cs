using System;
using System.Collections.Generic;
using System.Text;

namespace Simsokot
{
    public class SimController
    {
        public Cat Kitten { get; private set; }
        private void DrawStats()
        {
            Console.WriteLine($"Imię kota: \t{ Kitten.Name }");
            Console.Write($"Głód: [{ GetStatBar(Kitten.Food)}]  Zadowolenie: [{ GetStatBar(Kitten.Satisfaction) }]  Senność: [{ GetStatBar(Kitten.Torpor) }]\n\n\n");
        }
        private string GetStatBar(int statValue)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < (int)(Math.Round((double)statValue / 10, MidpointRounding.AwayFromZero)); i++)
                sb.Append("*");
            return sb.ToString().PadRight(10);
        }
        private ConsoleKeyInfo GetKittenAction()
        {
            Console.WriteLine("Co chcesz robić z kotem? Wybierz odpowiednią opcją i zatwierdz klawiszem Enter:");
            Console.WriteLine("1. Nakarm".PadRight(15) + "2. Baw się".PadRight(15) + "3. Wyczesz".PadRight(15));
            bool isActionCorrect = false;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            while (!isActionCorrect)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.D3) isActionCorrect = true;
                if (!isActionCorrect) Console.WriteLine("Wybierz prawidłową opcję!");
            }
            return cki;
        }
        public void Play()
        {
            Kitten = new Cat();
            while (true)
            {
                Console.Clear();
                DrawStats();
                if(Kitten.Satisfaction <= 0)
                {
                    Console.WriteLine("Kot był niezadowolony, przez co uciekł...");
                    Kitten = null;
                    break;
                }
                if(Kitten.Food <= 0)
                {
                    Console.WriteLine("Niestety, kot zdechł z głodu...");
                    Kitten = null;
                    break;
                }
                switch (GetKittenAction().Key)
                {
                    case ConsoleKey.D1:
                        Kitten.Feed();
                        break;
                    case ConsoleKey.D2:
                        Kitten.Play();
                        break;
                    case ConsoleKey.D3:
                        Kitten.Brush();
                        break;
                    default:
                        Console.WriteLine("Zastanów się i wybierz jeszcze raz.");
                        break;
                }
                Console.WriteLine("Naciśnij dowolny klawisz");
                Console.ReadLine();
            }

        }
    }
}
