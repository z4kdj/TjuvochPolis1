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
                Program.eventLog.Add($"Tjuv rånar medborgare på {stolenItem}");

                // Begränsar loggen till de senaste 3 händelserna
                if (Program.eventLog.Count > 3)
                {
                    Program.eventLog.RemoveAt(0);
                }

                Thread.Sleep(1000);
            }
            else if (other is Police)
            {
                Program.eventLog.Add("Medborgare hälsar på polisen.");

                // Begränsa loggen till de senaste 3 händelserna
                if (Program.eventLog.Count > 3)
                {
                    Program.eventLog.RemoveAt(0);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
