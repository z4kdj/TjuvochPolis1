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
                Inventory.Clear();
                Program.arrestedThieves++;
                prison.Imprison(this);
                Console.WriteLine("Polisen har gripit tjuven och alla stöldgods.");
                Thread.Sleep(2000);
            }
        }
    }
}
