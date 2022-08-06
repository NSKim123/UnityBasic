using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritanceAndPolymophism
{
    internal class Warrior : Player
    {

        public void Smash()
        {
            Console.WriteLine($"{nickname} (이)가 휘둘렀다.");
        }
    }
}
