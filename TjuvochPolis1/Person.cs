using System;
using TjuvochPolis;

namespace TjuvochPolis
{
    public abstract class Person
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; protected set; }
        protected Prison prison;

        protected Person(Prison prison)
        {
            this.prison = prison;
            X = Program.Random.Next(0, Program.width);
            Y = Program.Random.Next(0, Program.height - 10);
        }

        public virtual void Move()
        {
            int xDirection = Program.Random.Next(-1, 2);
            int yDirection = Program.Random.Next(-1, 2);
            X += xDirection;
            Y += yDirection;

            // Wrap around logic
            if (X < 0) X = Program.width - 1;
            if (X >= Program.width) X = 0;
            if (Y < 0) Y = Program.height - 1;
            if (Y >= Program.height - 10) Y = Program.height - 11;
        }

        public abstract void Interact(Person other);
    }
}
