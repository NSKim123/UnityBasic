using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class OPs
    {
        public static int opCount;
        public static void Init()
        {
            Program.RegisterCallBack(Sum);
            Program.RegisterCallBack(Sub);
            Program.opDelegate += Mul;
            // Program.opDelegate(1,2); // event 때문에 에러가 뜸.
        }
        public static int Sum(int a, int b) //int 형태로 정의했으면 int로 반환해야하는 것이 하나 있어야 한다. 없다면 void 사용
        {
            Console.WriteLine($"OP : Sum() , result : {a+b}");
         opCount++;     
            return a + b;   //int 형태로 정의했으면 int로 반환해야하는 것이 하나 있어야 한다.
        }

        public static int Sub(int a, int b)
        {
            Console.WriteLine($"OP : Sub() , result : {a - b}");
            opCount++;
            return a - b;
        }

        public static int Mul(int a, int b)
        {
            Console.WriteLine($"OP : Mul() , result : {a * b}");
            opCount++;
            return a * b;
        }

        public static int Div(int a, int b)
        {
            Console.WriteLine($"OP : Div() , result : {a / b}");
            opCount++;
            return a / b;
        }

        public static int Mod(int a, int b)
        {
            Console.WriteLine($"OP : Mod() , result : {a % b}");
            opCount++;
            return a % b;
        }

        
    }
}
