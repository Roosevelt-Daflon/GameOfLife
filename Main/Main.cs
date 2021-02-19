using GameOfLife.Process;
using System;
using System.Threading;
namespace GameOfLife.Main
{
    public static class Game
    {
        public static int[,] map;
        static CalcGame calcGAme = new CalcGame();
        static Thread t1;
        static bool active;
        public static bool activeP {get => active; set{active = value;}}
        public static Thread thread = new Thread(() => {while(t1.IsAlive){if(active)calcGAme.CalcMatrix(ref map);};});
               
        public static void Start(int mapWidth, int mapHeight, Thread t)
        {
            map =  new int[mapWidth, mapHeight];
            map.Initialize();
            t1 = t;
            thread.Start();
        }
    }
}