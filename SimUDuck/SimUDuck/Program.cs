using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    class Program
    {
        static void Main(string[] args)
        {
            MallardDuck m = new MallardDuck();
            Console.WriteLine("I am a {0}", m.Name);
            m.performQuack();
            m.fly();
            m.swim();

            RedHeadedDuck r = new RedHeadedDuck();
            Console.WriteLine("I am a {0}", m.Name);
            r.performQuack();
            r.fly();
            r.swim();

            RubberDuck duck = new RubberDuck();
            Console.WriteLine("I am a {0}", duck.Name);
            duck.performQuack();
            duck.swim();
            duck.fly();

            //DecoyDuck d = new DecoyDuck();
            //Console.WriteLine("I am a {0}", d.Name);
            ////d.quack();
            //d.swim();
            //d.fly();
        }
    }
}
