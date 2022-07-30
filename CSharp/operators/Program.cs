using System;

namespace operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 14;
            int b = 6;
            int c = 0;

            //산술연산자
            // 더하기,뺴기,곱하기,나누기,나머지
            //=======================================

            // 더하기
            c = a + b;
            Console.WriteLine(c);

            //뺴기
            c = a - b;

            //곱하기
            c = a * b;

            //나누기
            c = a / b; //정수 나눗셈은 소숫점을 버린 정수를 반환

            //나머지
            c= a % b; //자료형 관계없이 정수 나눗셈 후 나머지 결과를 반환



            //증감연산자
            //증가연산자, 감소 연산자
            //===================================================

            //증가 연산
            ++c; // 전위연산 : 해당 라인의 연산을 먼저 수행한 뒤 명령 실행
            c++; // 후위연사 : 해당 라인에서 명령을 실행한 뒤 연산 실행

            c = 0;
            Console.WriteLine("증가연산 출력");
            Console.WriteLine(c);
            Console.WriteLine(++c); //c에 1을 더한후 출력
            Console.WriteLine(c++); //현재 c를 출력하고 1을 더하여 저장. 1이 나옴
            Console.WriteLine(c); //2가 나올 것임.


            // 감소 연산
            --c;
            c--;

            //관계 연산자
            // 같음, 다름, 크기 등의 비교 연산자
            // 관계 연산자의 연산결과가 참이면 true, 거짓이면 false
            //=====================================================

            Console.WriteLine("관계연산 출력");
            //같음 비교
            Console.WriteLine(a == b);
            // 다름비교
            Console.WriteLine(a != b);
            //크기비교
            Console.WriteLine(a > b);
            Console.WriteLine(a >= b);
            Console.WriteLine(a <= b);

            //대입 연산자
            //===============================
            c = 20;
            c += b; //== c=c+b
            c -= b;
            c *= b;
            c /= b;
            c %= b;

            // 논리 연산자
            //or, and, xor, not
            //============================================
            bool A= true;
            bool B= false;
            Console.WriteLine("논리 연산 출력");

            //or
            //둘 중 하나라도 참이면 true 반환
            Console.WriteLine(A | B); //\를 쉬프트키랑 같이 누름.
            //and
            //둘다 참일떄만 true
            Console.WriteLine(A & B);
            //xor
            //둘 중 하나만 참일때 true 반환
            Console.WriteLine(A ^ B);
            //not
            //피연산자가 true이면 false, false이면 true 반환
            Console.WriteLine(!A); //A가 바뀌는 게 아니라 반환값만 바꿔준다.


            //조건부 논리여산자
            //조건부 or, 조건부 and
            //==================================================
            
            //조건부 or
            //c첫번째 피연산자가 true면 B 비교하지 않고 true 반환
            Console.WriteLine(A || B);

            //조건부 and
            //첫번쨰 피연산자가 false면 B비교하지 않고 false 반환
            //Console.WriteLine(A && B);

            //if (swordMan != null &%
            //   swordMan Lv > 0)
            //{
            //   Console.WriteLine(swordMan lv)
            //}

            //비트 연산자
            //or, and, xor, not, shift-left, shift-right
            //정수형 연산할때 보통 씀
            //비트 자리에 관한 연산
            //=========================================================
            int howmanybityouwanttoshift = 1;
            
            Console.WriteLine(a | b);
            Console.WriteLine(a & b);//5 와 8로 하면 or와 and 둘다 0나옴
            Console.WriteLine(a ^ b);
            Console.WriteLine(~a); //비트 반전. 원래 -1을 곱하면 비트를 반전시킨 후 1을 더한다. 그래서 비트만 반전시키면, 1 작은 숫자가 나온다.
            Console.WriteLine(a << howmanybityouwanttoshift); //14가 28이 됨.
            Console.WriteLine(A >> howmanybityouwanttoshift); //14가 7이 됨.

        }
    }
}
