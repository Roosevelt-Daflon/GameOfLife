using System;
using GameOfLife.Main;
using Raylib_cs;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Raylib.InitWindow(800, 800, "Game of Life ");
            Raylib.SetTargetFPS(60);
            Game.start(400,400, Thread.CurrentThread);
            int pixelWidth = Raylib.GetScreenWidth() / Game.map.GetLength(0), pixelHeight = Raylib.GetScreenHeight() / Game.map.GetLength(1);

            while (!Raylib.WindowShouldClose())
            {
                int[,] tempMap = (int[,])Game.map.Clone();
                Raylib.SetWindowTitle("Game of Life " + Raylib.GetFPS().ToString());
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                //=================Start==================
                for (int i = 0; i < tempMap.GetLength(0); i++)
                {
                    for (int j = 0; j < tempMap.GetLength(1); j++)
                    {
                        if(tempMap[i, j] == 1) Raylib.DrawRectangle(i * pixelWidth, j * pixelHeight, pixelWidth, pixelHeight, Color.BLACK);
                    }
                }
                
                if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    Game.activeP = false;
                    if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        Game.map[Raylib.GetMouseX() / pixelWidth, Raylib.GetMouseY() / pixelHeight] = 1;
                    else if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON) )
                        Game.map[Raylib.GetMouseX() / pixelWidth, Raylib.GetMouseY() / pixelHeight] = 0;
                }
                else if(Raylib.IsKeyUp(KeyboardKey.KEY_SPACE))
                    Game.activeP = true;

                //=================End====================
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
