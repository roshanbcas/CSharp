using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    abstract class Duck
    {
        //Name of the duck
        public string Name { get; set; }
        public QuackableBehavior quackableBehavior;

        public void performQuack()
        {
            quackableBehavior.quack();
        }

        //Behaviors        
        public void swim() {
            Console.WriteLine("Hi, I am Swiming!");
        }
        public void fly() {
            Console.WriteLine("Hey! I am flying!");
        }
    }
}
