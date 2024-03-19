using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Varto_School_1stGame
{
    class Game
    {

        enum Weapons
        {
            Rock = 1,
            Scissors,
            Paper
        }
        static void Main(string[] args)
        {
            bool ready = true;
            string playerName;
            string startAnswer;
            int age;

            while (ready)
            {
                Console.WriteLine($"Welcome to CHU-WA-CHI Game! It's 12+ rated game, so please enter your age:");
                if (!int.TryParse(Console.ReadLine(), out age))
                    Console.WriteLine($"Wrong age");
                else
                {
                    if (age >= 12)
                    {
                        Console.WriteLine($"Please enter your name:");
                        playerName = Console.ReadLine();

                        Console.WriteLine($"Hello {playerName}, your age: {age}, round played: 0, today wins: 0");
                        Console.WriteLine($"Are you ready to play? yes/no");
                        startAnswer = Console.ReadLine();

                            if (startAnswer == "no")
                            {
                                Console.WriteLine($"Have a nice day!");
                                Environment.Exit(0);
                            }
                            else if (startAnswer == "yes")
                            {
                            Playing();
                            }
                            else
                            {
                                Console.WriteLine($"Wrong answer");
                            startAnswer = null;
                            }

                    }
                    else
                        Console.WriteLine($"You are too young");
                }
            }

            static void Playing()
            {
                Random random = new Random();
                int playerWeapon;
                int playerScore = 0;
                int aiScore = 0;

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Pick a weapon: \nTo pick Rock enter 1 \nTo pick Scissors enter 2 \nTo pick Paper enter 3");
                    if (!int.TryParse(Console.ReadLine(), out playerWeapon))
                        Console.WriteLine($"Wrong input");
                    else
                    {
                        Weapons pickedWeapon = (Weapons)playerWeapon;
                        Console.WriteLine($"You picked {pickedWeapon}");

                        int randomWeapon = random.Next(1, 4);
                        Weapons randomPickedWeapon = (Weapons)randomWeapon;
                        Console.WriteLine($"Opponent picked {randomPickedWeapon}");

                        GameResult(pickedWeapon, randomPickedWeapon);
                    }

                    if (playerScore > aiScore)
                    {

                    }
                    else if (playerScore == aiScore)
                    {

                    }
                    else
                    {

                    }
                }
            }

            static void GameResult(Weapons player, Weapons random)
            {
                int a = (int)player;
                int b = (int)random;

                switch (a)
                {
                    case 1:
                        {
                            if (a == b)
                            {
                                Console.WriteLine($"Draw");
                            }
                            else if(b == 2)
                            {
                                Console.WriteLine("You win!");

                            }
                            else if (b == 3)
                            {
                                Console.WriteLine("You lose");

                            }
                            break;
                        }
                    case 2:
                        {
                            if (a == b)
                            {
                                Console.WriteLine($"Draw");
                            }
                            else if (b == 1)
                            {
                                Console.WriteLine("You lose");

                            }
                            else if (b == 3)
                            {
                                Console.WriteLine("You win");

                            }
                            break;
                        }
                    case 3:
                        {
                            if (a == b)
                            {
                                Console.WriteLine($"Draw");
                            }
                            else if (b == 1)
                            {
                                Console.WriteLine("You win!");

                            }
                            else if (b == 2)
                            {
                                Console.WriteLine("You lose");

                            }
                            break;
                        }
                }

            }
        }
    }
}
