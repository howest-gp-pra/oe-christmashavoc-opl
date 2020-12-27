using System;
using System.Collections.Generic;
using System.Text;
using Pra.Christmastree.Core.Entities.Base;
using Pra.Christmastree.Core.Interfaces;

namespace Pra.Christmastree.Core.Entities
{
    public class ChristmasBauble : ChristmasDecoration,IBreakable
    {
        private static int number = 0;
        private static Random rnd = new Random();

        public ChristmasBauble()
        {
            number++;
            Name = $"Bauble nr {number}";
        }
        public void TryToBreak()
        {
            if(rnd.Next(0,2) == 1)
            {
                Health = 0;
            }
        }

        public override string ToString()
        {
            if (Health == 0)
                return $"{Name} - I'm broken";
            else
                return $"{Name} - not broken yet";
        }
    }
}
