using System;
using System.Collections.Generic;
using System.Threading;


namespace TjuvochPolis
{
    public class Citizen : Person
    {
        public List<string> Inventory { get; private set; } = new List<string> { "Nycklar", "Mobiltelefon", "Pengar", "Klocka" };

        public Citizen(Prison prison) : base(prison) // Skicka in prison-objektet
        {
            Symbol = 'M';
        }

        public override void Interact(Person other)
        {
            if (other is Thief thief && Inventory.Count > 0)
            {
                string stolenItem = Inventory[Program.Random.Next(0, Inventory.Count)];
                Inventory.Remove(stolenItem);
                thief.Inventory.Add(stolenItem);
                Program.robbedCitizens++;
                Console.WriteLine($"Tjuv rånar medborgare på {stolenItem}");
                Thread.Sleep(2000);
            }
            else if (other is Police)
            {
                Console.WriteLine("Medborgare hälsar på polisen.");
                Thread.Sleep(2000);
            }
        }
    }
}
