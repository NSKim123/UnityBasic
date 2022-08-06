using System;
using System.Threading;
//프로그램 시작시
//말다섯마리를 만들고
//각 다섯마리는 초당 10~20(정수형) 범위 거리를 랜덤하게 움직임
//각각의 말이 거리 200에 도달하면 말의 이름과 등수를 출력해줌
//
//말은 매초 달릴때 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌
//경주가 끝나면 1,2,3,4,5 등 말의 이름을 등수 순서대로 콘솔창에 출력해줌

namespace HorseRacing
{
    internal class Program
    {
        static int totalhorses = 5;
        static Random random;
        static int minspeed=10;
        static int maxSpeed=20;
        static bool isFinished = false;
        static void Main(string[] args)
        {
            //말 5마리를 인스턴스화
            //for (5) {horse= new horse(); horse.name=경주마 i}
            Horse[] horses = new Horse[5];
            for (int i = 0; i < horses.Length; i++)
            {
                horses[i] = new Horse();
                horses[i].name = $"경주마{i + 1}";
            }
            Console.WriteLine("경주 시작!");

            int count = 1;

            int[] finishedHorsesIndex = new int[totalhorses];
            
            int sec = 0;

            while (isFinished=false)
            {               
                for (int i = 0; i < horses.Length; i++)   
                {
                    Console.WriteLine($"========================{sec}초 경과=======================");
                    

                    Horse horse = horses[i]; 
                    if (horse.enabled && horse.distance < 200)
                    {
                        random = new Random();   //랜덤속도 정의
                        int tmpMoveDistance = random.Next(minspeed, maxSpeed + 1); //랜덤속도의 최대최소
                        horse.Run(tmpMoveDistance);
                        Console.Write($"{horses[i].name} 이 달린 거리 : {horses[i].distance}");
                        if (horse.distance >= 200)
                        {
                            horse.enabled = false;
                            horse.grade = count;
                            finishedHorsesIndex[horse.grade-1] = i;

                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"경주마{i}는 도착함.");
                    }
                }
                if (count > horses.Length)
                {
                    isFinished = true;
                    Console.WriteLine("경주 끝!");
                    break;
                }    

                sec++;
                Thread.Sleep(1000);
            }
            Console.WriteLine("착준표");
            for (int i = 0; i < finishedHorsesIndex.Length; i++)
            {
                Console.WriteLine($"{horses[finishedHorsesIndex[i]]} 는 {i+1}등");
            }
        }
    }
}

public class Horse
{
    public string name;
    public int distance=0;
    public bool enabled=true;
    public int grade = 0;


    public void Run(int moveDistance)
    {
        distance+=moveDistance;
    }
}