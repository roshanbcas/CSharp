using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    class Squeak : QuackableBehavior
    {
        public void quack()
        {
            Console.WriteLine("Squeak! Squeak!");
        }
    }
}
