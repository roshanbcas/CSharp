using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    class Quack : QuackableBehavior
    {
        public void quack()
        {
            Console.WriteLine("Quack! Quack!");
        }
    }
}
