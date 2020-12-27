using System;
using System.Collections.Generic;
using System.Text;

namespace Pra.Christmastree.Core.Entities.Base
{
    public abstract class ChristmasDecoration
    {
        private int health;
        private string name;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ChristmasDecoration()
        {
            health = 100;
        }


    }
}
