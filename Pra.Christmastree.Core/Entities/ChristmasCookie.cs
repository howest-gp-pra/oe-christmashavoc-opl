using System;
using System.Collections.Generic;
using System.Text;
using Pra.Christmastree.Core.Entities.Base;
using Pra.Christmastree.Core.Interfaces;
namespace Pra.Christmastree.Core.Entities
{
    public class ChristmasCookie : ChristmasDecoration, IEatable
    {
        private static int number = 0;
        private static Random rnd = new Random();

        public ChristmasCookie()
        {
            number++;
            Name = $"Cookie nr {number}";
        }

        public void TryToEat()
        {
            if(rnd.Next(0,2) == 1)
                Health = Health - rnd.Next(10, 51);
            if (Health < 0) Health = 0;
        }
        public override string ToString()
        {
            return $"{Name} - {Health}% remaining";
        }
    }
}
