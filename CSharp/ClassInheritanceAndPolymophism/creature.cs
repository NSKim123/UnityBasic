using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritanceAndPolymophism
{
    //abstract : 추상화 키워드 (이것으로 객체를 만들 수 없다.)
    internal abstract class Creature
    {
        public string DNA;
        public float mass;
        public void Breathe()
        {
            Console.WriteLine($"{DNA} 형질을 가진 생명체가 숨을 쉰다.");
        }

        public abstract void Grow();  //상속받는 자식 클래스에서 더 정의를 해야만 한다.
    }
}
