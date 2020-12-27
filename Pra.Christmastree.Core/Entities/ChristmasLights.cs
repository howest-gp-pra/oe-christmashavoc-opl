using System;
using System.Collections.Generic;
using System.Text;
using Pra.Christmastree.Core.Entities.Base;
using Pra.Christmastree.Core.Interfaces;

namespace Pra.Christmastree.Core.Entities
{
    public class ChristmasLights : ChristmasDecoration, IBreakable
    {
        private static int number = 0;
        private static Random rnd = new Random();

        public ChristmasLights()
        {
            number++;
            Name = $"Christmaslights nr {number}";

        }
        public void TryToBreak()
        {
            Health = Health - rnd.Next(10, 21);
            if (Health < 0) Health = 0;
        }
        public override string ToString()
        {
            return $"{Name} - {Health} lights still burning";
        }
    }
}
