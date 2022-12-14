using System;
using Delegate;
namespace Delegate
{
    internal class Program
    {
        public delegate int DelegateHandler(int a, int b);
        public static event DelegateHandler opDelegate;

        //event 한정자
        //delegate를 위한 한정자
        //외부 클래스에서 함수를 대리자에 등록하거나 제거할수는 있으나 직접 대리자를 호출 할 수는 없도록 하는 한정자

        public static Action<int, int> opAction;
        public static Func<int, int, int> opFunc;

        static void Main(string[] args)
        {
            //Delegate : 대리자
            //함수 포인터 타입 ( 함수를 대입해뒀다가 호출할 수 있도록 해줌 )
            // delegate 키워드로 대리자를 정의할 수 있음
            //정의한 대리자 타입의 대리자변수를 선언해서 사용함.

            //함수체이닝
            //Delegate += OPs.Sum;
            //Delegate += OPs.Sub; //opDelegate라는 함수에 Sum Sub 함수가 순서대로 추가됨.
            //Delegate += OPs.Mul;
            //Delegate += OPs.Div;
            //Delegate += OPs.Mod;
            //
            //Delegate -= OPs.Mod;

            OPs.Init();

            while (true)
            {
                Console.WriteLine("연산을 수행하고 싶으면 DoOP를 입력하세요.");
                string input = Console.ReadLine();
                if (input == "DoOP")
                {
                    int a = 0, b = 0;
                    Console.WriteLine("첫번째 피연산자를 입력하세요");
                    try
                    {
                        a = Int32.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("아니 정수 입력 하시라고요.");
                        Console.WriteLine(e.Message);
                        continue; //다시 상위 반복문으로 돌아가는 것.
                    }
                    finally
                    {
                        // 예외 catch가 되든 안되는 마지막에 수행하고 싶은 내용
                    }
                    a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("두번째 피연산자를 입력하세요");
                    try
                    {
                        b = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("아니 정수 입력 하시라고요.");
                    }
                    b = Int32.Parse(Console.ReadLine());

                    //OPs.Sum(a, b);
                    //OPs.Sub(a, b);
                    //OPs.Mul(a, b);
                    //OPs.Div(a, b);
                    //OPs.Mod(a, b);
                    opDelegate(a, b);
                    //익명 메소드 등록
                    opAction += delegate (int a, int b)
                    {
                        Console.WriteLine(a + b);
                    };
                    opAction(1, 2);

                    //람다식 등록( => 를 사용하면 람다식이라고 함.)
                    opAction += (a, b) => { Console.WriteLine(a + b); };

                }

            }
        }

        public static void RegisterCallBack(DelegateHandler delegateHandler)
        {
            opDelegate += delegateHandler;
        }
    }
}
