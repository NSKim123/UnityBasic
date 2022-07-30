using System;

namespace statement_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tmpArr = { 1, 2, 3, 4, 5 };

            int count = 0;
            //while(조건문이 참일때만 계속 실행)
            while (count < tmpArr.Length)
            {
                //if(count==3)
                //{
                //    break; // 카운트가 3일때만 빠져나오는 코드
                //}

                //if(count ==3)
                //{
                //    count++;
                //    continue; //상위 반복문의 조건비교문으로 돌아가는 분기문
                //}

                #if( count == 3)
                {
                return; //해당 함수 즉시 반환
                }
                
                Console.WriteLine(tmpArr[count]);
                count++; 
            }

            count = 0;
            do //일단 한번 실행하고 while문에 따라 진행
            {
                Console.WriteLine(tmpArr[count]);
                count++;
            } while (count < 0);

            //for (인덱스용 변수 초기화 ; 반복 조건문 ; 루프 한번 실행되고 나서 수행할 연산)
            //{ }
            //인덱스용 변수 초기화 할때 인덱스의 형태를 정의해줘야 한다. ex) int i
            for (count = 0; count < tmpArr.Length ; count++)
            {
                Console.WriteLine(tmpArr[count]);
            }

            //for 안의 for
            int[,] mat2D = new int[3, 5]
            {
                {1, 2, 3, 4, 5},
                {4, 5, 6, 7, 8},
                {5, 6, 7, 8, 9}

            };

            for(int i =0; i<mat2D.GetLength(0); i++)
            {
                for(int j =0; i< mat2D.GetLength(1); j++)
                { 
                    Console.Write(mat2D[i, j]+","); 
                }
                Console.WriteLine();
            }
        }
    }
}
