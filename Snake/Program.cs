using System;
using System.Linq;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int snakeRow = 0;
            int snakeCol = 0;

            int counterForFood = 0;
            bool isInside = true;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (counterForFood < 10)
            {
                matrix[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }

                if (snakeRow < 0 || snakeCol < 0 || snakeRow == rows || snakeCol == cols)
                {
                    isInside = false;
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    counterForFood++;
                }

                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row, col] == 'B' && row != snakeRow && col != snakeCol)
                            {
                                matrix[snakeRow, snakeCol] = '.';
                                snakeRow = row;
                                snakeCol = col;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (isInside == true)
            {
                matrix[snakeRow, snakeCol] = 'S';
            }

            if (isInside == false)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {counterForFood}");

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
