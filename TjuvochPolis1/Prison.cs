using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TjuvochPolis.Program;
using TjuvochPolis;

public class Prison
{
    public List<Thief> Inmates { get; private set; } = new List<Thief>();
    public const int PrisonWidth = 10;
    public const int PrisonHeight = 10;

    public void Imprison(Thief thief)
    {
        Inmates.Add(thief);
        thief.X = Program.Random.Next(0, PrisonWidth);
        thief.Y = new Random().Next(15, 15 + PrisonHeight);
        Console.WriteLine("En tjuv har blivit inlåst.");
    }

    public void Release(Thief thief)
    {
        Inmates.Remove(thief);
        Console.WriteLine("En tjuv har blivit frisläppt.");
        thief.X = Program.Random.Next(0, Program.width);
        thief.Y = Program.Random.Next(0, Program.height - 10);
    }

    public void DrawPrison()
    {
        Console.WriteLine("\nFängelse:");
        Console.WriteLine($"Antal tjuvar inlåsta: {Inmates.Count}");
        Console.WriteLine($"Antal tjuvar på fri fot: {Program.persons.OfType<Thief>().Count() - Inmates.Count}");

        for (int y = 0; y < PrisonHeight; y++)
        {
            for (int x = 0; x < PrisonWidth; x++)
            {
                if (Inmates.Any(thief => thief.X == x && thief.Y == y + 15))
                {
                    Console.Write('T');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}


