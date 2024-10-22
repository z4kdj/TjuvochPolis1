using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TjuvochPolis
{
    class Program
    {
        public const int width = 100;
        public const int height = 25;
        public static List<Person> persons = new List<Person>();
        public static int robbedCitizens = 0;
        public static int arrestedThieves = 0;
        public static Prison prison;
        public static List<string> eventLog = new List<string>();
        public static Random Random = new Random();
        public static int minTime = 5; // Exempel på minimi fängelsetid

        static void Main()
        {
            prison = new Prison();
            persons.Clear();

            // Skapa personer
            for (int i = 0; i < 20; i++) persons.Add(new Police(prison));
            for (int i = 0; i < 30; i++) persons.Add(new Thief(prison));
            for (int i = 0; i < 40; i++) persons.Add(new Citizen(prison));

            while (true)
            {
                
                DrawCity();
                MovePersons();       
                Thread.Sleep(200);

                ReleaseThieves();

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine($"Antal rånade medborgare: {robbedCitizens}");
            Console.WriteLine($"Antal gripna tjuvar: {arrestedThieves}");
        }

        static void MovePersons()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                persons[i].Move();
                CheckInteractions(i);
            }
        }

        static void CheckInteractions(int index)
        {
            for (int j = 0; j < persons.Count; j++)
            {
                if (index != j && persons[index].X == persons[j].X && persons[index].Y == persons[j].Y)
                {
                    persons[index].Interact(persons[j]);
                    break;
                }
            }
        }
        static void DrawCity()
        {
            Console.Clear ();
            char[,] city = new char[height - 10, width];

            // Rita ut personer
            foreach (var person in persons)
            {
                if (person.X >= 0 && person.X < width && person.Y >= 0 && person.Y < height - 10)
                {
                   
                    city[person.Y, person.X] = person.Symbol;
                    
                   
                }
            }

            // Skriv ut staden
            
            for (int y = 0; y < height - 10; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(city[y, x] != '\0' ? city[y, x] : ' ');
                }
                Console.WriteLine();
                
            }
            

            // Skriv ut fängelse-information
           // Console.WriteLine("Fängelse:");
            prison.DrawPrison();

            // Skriv ut händelser
            Console.WriteLine("\nHändelser:");
            if (eventLog.Count == 0)
            {
                Console.WriteLine("Inga händelser.");
            }
            else
            {
                foreach (var log in eventLog)
                {
                    Console.WriteLine(log);
                }
            }

            Console.WriteLine($"\nAntal händelser: {eventLog.Count}");
        }
        



        static void ReleaseThieves()
        {
            for (int i = prison.Inmates.Count - 1; i >= 0; i--)
            {
                Thief inmate = prison.Inmates[i];
                inmate.ImprisonmentTime -= 1; // Minska tiden långsammare

                if (inmate.ImprisonmentTime <= minTime)
                {
                    prison.Release(inmate);
                }
            }
        }
    }
}
