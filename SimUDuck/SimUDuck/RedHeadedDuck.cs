using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    class RedHeadedDuck: Duck
    {
        public RedHeadedDuck()
        {
            Name = "Read Headed Duck";
            quackableBehavior = new Quack();
        }
    }
}
