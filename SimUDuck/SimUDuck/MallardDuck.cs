using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    class MallardDuck : Duck
    {
        public MallardDuck()
        {
            Name = "Mallard Duck";
            quackableBehavior = new Quack();
        }
        
    }
}
