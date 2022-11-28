using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    class RubberDuck : Duck
    {
        public RubberDuck()
        {
            Name = "Rubber Duck";
            quackableBehavior = new Squeak();
        }
        
    }
}
