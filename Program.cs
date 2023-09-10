using System.Runtime.CompilerServices;
using System;

namespace Game;

class Program
{
    private const int SCREEN_WIDTH = 100;
    private const int SCREEN_HEIGHT = 50;

    private const int MAP_WIDTH = 32;
    private const int MAP_HEIGHT = 32;

    private const double DEPTH = 16;
    private static string _map = "";

    private static readonly char[] _screen = new char[SCREEN_WIDTH * SCREEN_HEIGHT];

    static void Main(string[] args)
    {
        Player player = new Player(5, 5, 0);

        _map += "##############################";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#.......###..................#";
        _map += "#................###.........#";
        _map += "#............................#";
        _map += "#...###......................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "#............................#";
        _map += "##############################";


        Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
        Console.SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
        Console.CursorVisible = false;

        while (true)
        {
            player.A += 0.001;
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                double rayAngle = player.A + player.FOV / 2 - x * player.FOV / SCREEN_WIDTH;

                double rayX = Math.Sin(rayAngle);
                double rayY = Math.Cos(rayAngle);

                double distanceToWall = 0;

                bool hitWall = false;

                while (!hitWall && distanceToWall < DEPTH)
                {
                    distanceToWall += 0.1;

                    int testX = (int)(player.X + rayX * distanceToWall);
                    int testY = (int)(player.Y + rayY * distanceToWall);

                    if (testX < 0 || testX >= DEPTH + player.X || testY < 0 || testY >= DEPTH + player.Y)
                    {
                        hitWall = true;
                        distanceToWall = DEPTH;
                    }
                    else
                    {
                        char testCell = _map[testY * MAP_WIDTH + testX];
                        if (testCell == '#')
                        {
                            hitWall = true;
                        }
                    }
                }

                int ceilling = (int)(SCREEN_HEIGHT / 2d - SCREEN_HEIGHT * player.FOV / distanceToWall);
                int floor = SCREEN_HEIGHT - ceilling;
                
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    if(y <= ceilling)
                    {
                        _screen[y * SCREEN_WIDTH + x] = ' ';
                    }
                    else if (y > ceilling && y <= floor)
                    {
                        _screen[y * SCREEN_WIDTH + x] = '#';
                    }
                    else
                    {
                        _screen[y * SCREEN_WIDTH + x] = '.';
                    }
                }


            }

            Console.SetCursorPosition(0, 0);
            Console.Write(_screen);
        }
    }
}