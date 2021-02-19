using System;
using System.Threading;

namespace GameOfLife.Process
{
    public class CalcGame
    {
        public void CalcMatrix(ref int[,] map)
        {
            int[,] mapCopy = new int[map.GetLength(0), map.GetLength(1)];
            mapCopy.Initialize();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int x = (i == 0 || i == map.GetLength(0)-1)?i:i-1;
                    int y = (j == 0 || j == map.GetLength(1)-1)?j:j-1;
                    int tempI = (i == 0)?1:i+1;
                    int tempJ = (j == 0)?1:j+1;
                    for (int k = x; k <= tempI; k++)
                    {
                        
                        for (int l = y; l <= tempJ; l++)
                        {
                            if(k == map.GetLength(0) || l == map.GetLength(1)) break;
                            if(i != k || j != l)
                                if(map[k, l] == 1) mapCopy[i, j]++;  
                        }
                    }
                }
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if(mapCopy[i, j] < 2 || mapCopy[i, j] > 3)
                    {
                        map[i, j] = 0;
                    }else if(mapCopy[i, j] == 3)
                    {
                        map[i, j] = 1;
                    }
                }
            }
        }
    }
}