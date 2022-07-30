using System;

namespace Array2DImension
{
    internal class Program
    {
        static int[,] map = new int[5, 5]
        {
            {0,0,0,0,1},
            {0,1,1,1,1},
            {0,0,0,1,1},
            {1,1,0,0,0},
            {0,1,1,0,0},
        };
        static void Main(string[] args)
        {
            Player player = new Player(3, 4, map);
            DisplayMap();
            player.Moveleft(map);
            DisplayMap();

           // int[][] testArr = new int[3][]; // 배열의 배열. int[]를 3개 만들고 testArr에 그 주소를 저장함. 3개의 배열 testArr[0] ~ [2]의 형태를 정해주어야함.
            //testArr[0] = new int[2];
            //testArr[1] = new int[3];
           // testArr[2] = new int[4];

            while(true)
            {
                Console.WriteLine($"플레이어 이동방향을 입력하세요 : Left/Right/Up/Down")
                string input = Console.ReadLine();
                if (input.Equals("Left"))
                {
                    player.Moveleft(map);
                    DisplayMap();
                }
                else if (input.Equals("Right"))
                {
                    player.Moveright(map);
                    DisplayMap();
                }
                else if (input.Equals("Up"))
                {
                    player.Moveup(map);
                    DisplayMap();
                }
                else if (input.Equals("down"))
                {
                    player.Movedown(map);
                    DisplayMap();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. Left/Right/Up/Down중에 하나 입력하세요");
                }
            }
        }

        static void DisplayMap()
        {
            for(int i = 0; i < map.GetLength(0);i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + ",");
                }
                Console.WriteLine();
            }
        }
    }
public class Player
    {
        private int _x;
        private int _y;

        public Player(int x, int y, int[,] map)
        {
            _x = x;
            _y= y;
            map[_y, _x] = 2;

        }

        public void Moveleft(int[,] map)
        {
            if (_x - 1 < 0) 
            {
                Console.WriteLine($"플레이어 왼쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y,_x-1]==1)  //행렬처럼 세로가 x값이다.
            {
                Console.WriteLine($"플레이어 왼쪽 이동 실패. (벽이 있습니다.)");
            }
            else if (map[_y, _x - 1] == 0)  //행렬처럼 세로가 x값이다.
            {
                map[_y, _x] = 0;
                _x--;
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 왼쪽 이동. 현재 좌표 : {_x}, {_y}");
            }
        }
        public void Moveright(int[,] map)
        {
            if (_x + 1 > map.GetLength(1)-1) //
            {
                Console.WriteLine($"플레이어 오른쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y, _x + 1] == 1)  //행렬처럼 세로가 x값이다.
            {
                Console.WriteLine($"플레이어 오른쪽 이동 실패. (벽이 있습니다.)");
            }
            else if (map[_y, _x + 1] == 0)  //행렬처럼 세로가 x값이다.
            {
                map[_y, _x] = 0;
                _x++;
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 오른쪽 이동. 현재 좌표 : {_x}, {_y}");
            }
        }
        public void Movedown(int[,] map)
        {
            if (_y + 1 > map.GetLength(0)-1) //
            {
                Console.WriteLine($"플레이어 아래쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y+1, _x ] == 1)  //행렬처럼 세로가 x값이다.
            {
                Console.WriteLine($"플레이어 아래쪽 이동 실패. (벽이 있습니다.)");
            }
            else if (map[_y+1, _x ] == 0)  //행렬처럼 세로가 x값이다.
            {
                map[_y, _x] = 0;
                _y++;
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 아래쪽 이동. 현재 좌표 : {_x}, {_y}");
            }
        }
        public void Moveup(int[,] map)
        {
            if (_y + 1 <0 ) //
            {
                Console.WriteLine($"플레이어 위쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y - 1, _x] == 1)  //행렬처럼 세로가 x값이다.
            {
                Console.WriteLine($"플레이어 위쪽 이동 실패. (벽이 있습니다.)");
            }
            else if (map[_y - 1, _x] == 0)  //행렬처럼 세로가 x값이다.
            {
                map[_y, _x] = 0;
                _y--;
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 위쪽 이동. 현재 좌표 : {_x}, {_y}");
            }
        }
    }
}
