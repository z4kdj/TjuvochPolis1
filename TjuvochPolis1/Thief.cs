using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvochPolis
{
    public class Thief : Person
    {
        public List<string> Inventory { get; private set; } = new List<string>();
        public int ImprisonmentTime { get; set; }

        public Thief(Prison prison) : base(prison)
        {
            Symbol = 'T';
            
        }

        public override void Interact(Person other)
        {
            if (other is Police police && Inventory.Count > 0)
            {
                police.Inventory.AddRange(Inventory);
                int imprisonmentDuration = Inventory.Count * 10;
                ImprisonmentTime = imprisonmentDuration;
                Inventory.Clear();
                Program.arrestedThieves++;
                prison.Imprison(this);
                Program.eventLog.Add("Polisen har gripit tjuven och alla stöldgods.");

                // Begränsar loggen till de senaste 3 händelserna
                if (Program.eventLog.Count > 3)
                {
                    Program.eventLog.RemoveAt(0);
                }

                Thread.Sleep(2000);
            }
        }

                  public override void Move()
        {
            // Om tjuven är inlåst, rör sig inom fängelseområdet
            if (prison.Inmates.Contains(this))
            {
                int xDirection = Program.Random.Next(-1, 2);
                int yDirection = Program.Random.Next(-1, 2);

                // Uppdatera position
                X += xDirection;
                Y += yDirection;

                // Wrap around logik för fängelset
                if (X < 0) X = Prison.PrisonWidth - 1;
                if (X >= Prison.PrisonWidth) X = 0;
                if (Y < 15) Y = 15; // Se till att Y är inom fängelsegränserna
                if (Y >= 15 + Prison.PrisonHeight) Y = 15 + Prison.PrisonHeight - 1;

                
            }
        }
    }
}
        
    

