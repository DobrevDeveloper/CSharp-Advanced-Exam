using System;
using System.Linq;
using System.Collections.Generic;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputBombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var inputBombCasings = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bombEffects = new Queue<int>(inputBombEffects);
            var bombCasings = new Stack<int>(inputBombCasings);

            int counterDaturaBombs = 0;
            int counterCherryBombs = 0;
            int counterSmokeDecoyBombs = 0;

            bool isSuccess = false;

            while (bombEffects.Any() && bombCasings.Any())
            {
                if (counterDaturaBombs >= 3 && counterCherryBombs >= 3 && counterSmokeDecoyBombs >= 3)
                {
                    isSuccess = true;
                    break;
                }

                int currentBombEffect = bombEffects.Peek();
                int currentBombCasing = bombCasings.Peek();

                if (currentBombEffect + currentBombCasing == 40)
                {
                    counterDaturaBombs++;

                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }

                else if (currentBombEffect + currentBombCasing == 60)
                {
                    counterCherryBombs++;

                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }

                else if (currentBombEffect + currentBombCasing == 120)
                {
                    counterSmokeDecoyBombs++;

                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }

                else
                {
                    int valueToDecrease = bombCasings.Pop();
                    valueToDecrease -= 5;
                    bombCasings.Push(valueToDecrease);
                }
            }

            if (isSuccess == true)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            var bombsDict = new Dictionary<string, int>();

            bombsDict.Add("Cherry Bombs:", counterCherryBombs);
            bombsDict.Add("Datura Bombs:", counterDaturaBombs);
            bombsDict.Add("Smoke Decoy Bombs:", counterSmokeDecoyBombs);

            foreach (var bomb in bombsDict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key} {bomb.Value}");
            }
        }
    }
}
