using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritanceAndPolymophism
{
    internal class Wizard : Player
    {

        public void Fire()
        {
            Console.WriteLine($"{nickname} (이)가 불덩이를 던졌다.");
        }
    }
}
