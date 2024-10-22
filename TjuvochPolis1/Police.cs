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
                Program.eventLog.Add("Polisen hälsar på medborgaren.");


                // Begränsar loggen till de senaste 3 händelserna
                if (Program.eventLog.Count > 3)
                {
                    Program.eventLog.RemoveAt(0);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
