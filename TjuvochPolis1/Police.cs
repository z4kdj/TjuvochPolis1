using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvochPolis
{
    public class Police : Person
    {
        public List<string> Inventory { get; private set; } = new List<string>();

        public Police(Prison prison) : base(prison) // Skickar prison-objektet till basklassen
        {
            Symbol = 'P';
        }

        public override void Interact(Person other)
        {
            if (other is Citizen)
            {
                Console.WriteLine("Polisen hälsar på medborgaren.");
                Thread.Sleep(2000);
            }
        }
    }
}
