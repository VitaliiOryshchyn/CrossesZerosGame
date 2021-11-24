using System;
using System.Collections.Generic;

namespace CrossesZerosGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> indexXO = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] field = { "|       |       |       |", " ----------------------- " };
            int[] moveGamerX = new int[5];
            int[] moveGamerY = new int[4];
            int selectNumber;
            int counterX = 0;
            int counterY = 0;

            Console.WriteLine("Welcom to the GAME X : O");
            Console.WriteLine();
            Console.WriteLine("It's yours battleField gamers!!! Let's start game!!!");
            Console.WriteLine();
            GameField(indexXO, field);
            Console.WriteLine();
            Console.WriteLine("Player X do first move:");
            Console.WriteLine();
            for (int j = 0; ; j++)
            {
                selectNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (IfMassivaHaveDuplacats(moveGamerX, moveGamerY, selectNumber) || selectNumber > 9)
                {
                    Console.WriteLine("Don't cheating player, choice another number");
                    Console.WriteLine();
                    --j;
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        indexXO.RemoveAt(selectNumber - 1);
                        indexXO.Insert(selectNumber - 1, "X");
                        moveGamerX[counterX++] = selectNumber;
                        GameField(indexXO, field);
                        Console.WriteLine();
                        if (Winners(moveGamerX, moveGamerY, j))
                            break;
                        Console.WriteLine("Now step player O");
                        Console.WriteLine();
                    }
                    else
                    {
                        indexXO.RemoveAt(selectNumber - 1);
                        indexXO.Insert(selectNumber - 1, "O");
                        moveGamerY[counterY++] = selectNumber;
                        GameField(indexXO, field);
                        Console.WriteLine();
                        if (Winners(moveGamerX, moveGamerY, j))
                            break;
                        Console.WriteLine("Now step player X");
                        Console.WriteLine();
                    }
                }
            }
        }

        public static bool Winners(int[] moveGamerX, int[] moveGamerY, int maxStep)
        {

            if (WinnerCombination(moveGamerX))
            {
                Console.WriteLine("First Gamer WINS");
                return true;
            }
            else if (WinnerCombination(moveGamerY))
            {
                Console.WriteLine("Second Gamer WINS");
                return true;
            }
            else if (maxStep == 8)
            {
                Console.WriteLine("Draw");
                return true;
            }
            return false;
        }


        public static void GameField(List<string> indexXO, string[] field)
        {
            for (int j = 0; j <= 12; j++)
            {
                if (j == 2 || j == 6 || j == 10)
                {
                    switch (j)
                    {
                        case 2:
                            Console.WriteLine($"|   {indexXO[0]}   |   {indexXO[1]}   |   {indexXO[2]}   |");
                            break;
                        case 6:
                            Console.WriteLine($"|   {indexXO[3]}   |   {indexXO[4]}   |   {indexXO[5]}   |");
                            break;
                        case 10:
                            Console.WriteLine($"|   {indexXO[6]}   |   {indexXO[7]}   |   {indexXO[8]}   |");
                            break;
                    }
                }
                else
                {
                    if (j == 0 || j % 4 == 0)
                    {
                        Console.WriteLine(field[1]);
                    }
                    else
                    {
                        Console.WriteLine(field[0]);
                    }
                }
            }
        }

        public static bool IfMassivaHaveDuplacats(int[] firstMassive, int[] secondMassive, int numberPlayer)
        {
            foreach (var i in firstMassive)
            {
                if (numberPlayer == i)
                    return true;

            }
            foreach (var i in secondMassive)
            {
                if (numberPlayer == i)
                    return true;
            }

            return false;
        }

        public static bool WinnerCombination(int[] combination)
        {
            string[] winnerCombination = { "123", "147", "159", "258", "369", "357", "456", "789" };
            List<string> listCombination = new List<string>();

            foreach (var i in combination)
            {
                listCombination.Add(i.ToString());
            }

            listCombination.Sort();

            for (int i = 0; i < listCombination.Count; i++)
            {
                for (int j = i + 1; j < listCombination.Count; j++)
                {
                    for (int k = j + 1; k < listCombination.Count; k++)
                    {
                        for (int z = 0; z < winnerCombination.Length; z++)
                        {
                            if ((listCombination[i] + listCombination[j] + listCombination[k]) == winnerCombination[z])
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
