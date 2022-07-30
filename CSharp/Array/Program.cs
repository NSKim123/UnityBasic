using System;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array
            //형태 : 자료형[]    ([] : 인덱서)
            //자료형이 정적으로 , 연속적으로 나열되어있는 형태
            //한번 크기를 정하면 일반적으로는 바꿀 수 없다.

            int[] arrint = new int[3];
            int[] arrint2= {1, 2, 3};
            float[] arrFloat = new float[4];


            arrint[0] = 3; //arrint의 첫번째 주소 +(0 *자료형 크기)의 주소부터 자료형크기만큼 접근한다.
            arrint[1] = 4; //arrint의 첫번째 주소 +(1 *자료형 크기)의 주소부터 자료형크기만큼 접근한다.
            //Console.WriteLine(arrint2[3]); 은 안됨!

            Console.WriteLine($"arrint2 length : {arrint2.Length}");
            
        }
    }
}
