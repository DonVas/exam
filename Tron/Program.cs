using System;

namespace Tron
{
    class Program
    {
       
        public static char[][] matrix;
        public static int fplayerRow = -1;
        public static int fplayerCol = -1;
        public static int splayerRow = -1;
        public static int splayerCol = -1;
        public static void Main()
        {
            int martixLenght = int.Parse(Console.ReadLine());
            matrix = new char[martixLenght][];

            for (int row = 0; row < martixLenght; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }



            for (int row = 0; row < martixLenght; row++)
            {
                for (int col = 0; col < martixLenght; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        fplayerCol = col;
                        fplayerRow = row;
                    }
                    else if (matrix[row][col] == 's')
                    {
                        splayerCol = col;
                        splayerRow = row;
                    }

                }
            }

            bool playerIsDead = false;

            while (playerIsDead != true)
            {
                string[] commands = Console.ReadLine().Split();
                string firstOne = commands[0];
                string secondOne = commands[1];

                if (MovePlayer('f', firstOne, fplayerRow, fplayerCol) == 1)
                {
                    playerIsDead = true;
                    break;
                }

                if (MovePlayer('s', secondOne, splayerRow, splayerCol) == 1)
                {
                    playerIsDead = true;
                    break;
                }
            }

            for (int i = 0; i < martixLenght; i++)
            {
                for (int j = 0; j < martixLenght; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static int MovePlayer(char player, string command, int row, int col)
        {
            switch (command)
            {
                case "down":
                    if (row + 1 > matrix.Length)
                    {
                        row = 0;
                        if (IsDead(player, row, col) == true)
                        {
                            return 1;
                        }
                        UpdateCordinats(player, row, col);
                        return 0;
                    }

                    if (IsDead(player, row+1, col) == true)
                    {
                        return 1;
                    }
                    UpdateCordinats(player, row+1, col);
                    break;

                case "up":
                    if (row - 1 < 0)
                    {
                        row = matrix.Length-1;
                        if (IsDead(player, row, col) == true)
                        {
                            return 1;
                        }
                        UpdateCordinats(player, row, col);
                        return 0;
                    }

                    if (IsDead(player, row-1, col) == true)
                    {
                        return 1;
                    }
                    UpdateCordinats(player, row-1, col);
                    break;
                case "right":
                    if (col + 1 > matrix.Length-1)
                    {
                        col = 0;
                        if (IsDead(player, row, col) == true)
                        {
                            return 1;
                        }
                        UpdateCordinats(player, row, col);
                        return 0;
                    }

                    if (IsDead(player, row, col + 1) == true)
                    {
                        return 1;
                    }
                        UpdateCordinats(player, row, col+1);
                    break;
                case "left":

                    if (col - 1 < 0)
                    {
                        col = matrix.Length-1;
                        if (IsDead(player, row, col) == true)
                        {
                            return 1;
                        }
                        UpdateCordinats(player, row, col);
                        return 0;
                    }
                    if (IsDead(player, row, col - 1)==true)
                    {
                        return 1;
                    }                                   
                    UpdateCordinats(player, row, col-1);
                    break;
            }
            return 0;
        }

        private static bool IsDead(char player, int row, int col)
        {
            if (matrix[row][col] == 's' || matrix[row][col] == 'f')
            {
                matrix[row][col] = 'x';
                return true;
            }
            return false;
        }

        private static void UpdateCordinats(char player, int row, int col)
        {
            if (player == 's')
            {
                matrix[row][col] = player;
                splayerCol = col;
                splayerRow = row;
            }
            else if (player == 'f')
            {
                matrix[row][col] = player;
                fplayerCol = col;
                fplayerRow = row;
            }
        }
    }
}
