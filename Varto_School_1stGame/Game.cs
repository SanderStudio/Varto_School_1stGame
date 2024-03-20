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
            string playerName = null;
            string startAnswer;
            string oneMoreTimeAnswer;
            int age = 0;
            int wins = 0;
            int rounds = 0;

            while (ready)
            {
                Console.WriteLine($"---------------------------------------------");
                Console.WriteLine($"     Welcome to CHU-WA-CHI Game!       ");
                Console.WriteLine($"---------------------------------------------");
                Console.WriteLine($"  It's a 12+ rated game, so please enter your age:");
                if (!int.TryParse(Console.ReadLine(), out age))
                    Console.WriteLine($"Wrong age");
                else
                {
                    if (age >= 12)
                    {
                        Console.WriteLine($"Please enter your name:");
                        playerName = Console.ReadLine();
                            Console.WriteLine($"Hello {playerName}, your age: {age}, round played: {rounds}, today wins: {wins}");
                            Console.WriteLine($"Are you ready to play? yes/no");
                            startAnswer = Console.ReadLine();

                            if (startAnswer == "no")
                            {
                                Console.WriteLine($"Have a nice day!");
                                Environment.Exit(0);
                            }
                            else if (startAnswer == "yes")
                            {
                                Playing(ref rounds, ref wins);
                            }
                            else
                            {
                                Console.WriteLine($"Wrong answer");
                                startAnswer = null;
                            }

                        while (true)
                        {
                            Console.WriteLine($"---------------------------------------------");
                            Console.WriteLine($"\tOne more time? yes/no");
                            Console.WriteLine($"---------------------------------------------");
                            oneMoreTimeAnswer = Console.ReadLine();

                            if (oneMoreTimeAnswer == "no")
                            {
                                Console.WriteLine($"Have a nice day!");
                                Environment.Exit(0);
                            }
                            else if (oneMoreTimeAnswer == "yes")
                            {
                                oneMoreTimeAnswer = null;
                                Console.WriteLine($"Hello {playerName}, your age: {age}, rounds played: {rounds}, total wins: {wins}");
                                Playing(ref rounds, ref wins);
                            }
                            else
                            {
                                Console.WriteLine($"Wrong answer");
                                startAnswer = null;
                            }
                        }
                    }
                    else
                        Console.WriteLine($"You are too young");
                }

               
            }

            static void Playing(ref int rounds, ref int wins)
            {
                Random random = new Random();
                int playerWeapon;
                int playerScore = 0;
                int aiScore = 0;
                int randomPhrase = random.Next(3);

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

                        int roundResult = GameResult(pickedWeapon, randomPickedWeapon);
                        if (roundResult == 1)
                        {
                            playerScore++;
                        }
                        else if (roundResult == -1)
                        {
                            aiScore++;
                        }
                    }
                }
                if (playerScore > aiScore)
                {
                    switch (randomPhrase)
                    {
                        case 0:
                            Console.WriteLine("Congratulations! You emerge victorious!");
                            wins++;
                            break;
                        case 1:
                            Console.WriteLine("You've conquered the game! Well done!");
                            wins++;
                            break;
                        case 2:
                            Console.WriteLine("Victory is yours! Celebrate your triumph!");
                            wins++;
                            break;
                    }
                }
                else if (playerScore == aiScore)
                {
                    Console.WriteLine("It's a tie!");
                }
                else
                {
                    switch (randomPhrase)
                    {
                        case 0:
                            Console.WriteLine("Better luck next time! You were narrowly defeated.");
                            break;
                        case 1:
                            Console.WriteLine("Alas, you've been bested this time. Keep striving!");
                            break;
                        case 2:
                            Console.WriteLine("Defeat is bitter, but it's a chance to learn and grow.");
                            break;
                    }
                }
                rounds += 3;
            }

        }


        static int GameResult(Weapons player, Weapons random)
        {
            int playerScore = 0;
            int aiScore = 0;

            switch (player)
            {
                case Weapons.Rock:
                    {
                        if (random == Weapons.Rock)
                        {
                            Console.WriteLine($"Draw");
                        }
                        else if (random == Weapons.Scissors)
                        {
                            Console.WriteLine("You win!");
                            return 1;
                        }
                        else if (random == Weapons.Paper)
                        {
                            Console.WriteLine("You lose");
                            return -1;
                        }
                        break;
                    }
                case Weapons.Scissors:
                    {
                        if (random == Weapons.Scissors)
                        {
                            Console.WriteLine($"Draw");
                        }
                        else if (random == Weapons.Rock)
                        {
                            Console.WriteLine("You lose");
                            return -1;
                        }
                        else if (random == Weapons.Paper)
                        {
                            Console.WriteLine("You win");
                            return 1;
                        }
                        break;
                    }
                case Weapons.Paper:
                    {
                        if (random == Weapons.Paper)
                        {
                            Console.WriteLine($"Draw");
                        }
                        else if (random == Weapons.Rock)
                        {
                            Console.WriteLine("You win!");
                            return 1;
                        }
                        else if (random == Weapons.Scissors)
                        {
                            Console.WriteLine("You lose");
                            return -1;
                        }
                        break;
                    }
            }
            return 0;
        }
    }

}
