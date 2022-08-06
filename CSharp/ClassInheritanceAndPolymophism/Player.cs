using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritanceAndPolymophism
{
    internal class Player : Creature, ITwoLeggedWalkable
    {
        public string nickname;
        //virtual
        //가상키워드. 해당 함수를 재정의 할 수 있도록 해줌.
        //virtual 함수가 호출되면 최하단에 오버라이드된 함수를 호출. (오버라이드 : 함수를 고침)
        public virtual void Attack()
        {
            Console.WriteLine($"{nickname} (이)가 공격했다.");
        }

        public void Jump()
        {
            Console.WriteLine($"{nickname} (이)가 점프했다.");
        }

        public void TwoLeggedWalk()
        {
            Console.WriteLine($"{nickname} (이)가 이족보행했다.");
        }

        public override void Grow()
        {
            throw new NotImplementedException();
        }
    }
}
