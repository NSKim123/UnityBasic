﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritanceAndPolymophism
{
    internal class Enemy : Creature
    {
        public string name;

        public void Hurt(int damage)
        {
            Console.WriteLine($"{name} (이)가 {damage} 데미지로 피격당했다.");
        }

        public override void Grow()
        {
            throw new NotImplementedException();
        }
    }
}
