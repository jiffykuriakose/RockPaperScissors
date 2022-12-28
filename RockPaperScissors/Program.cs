using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Program
    {
        private static List<GameOption> GameOptions { get; set; }
        static void Main(string[] args)
        {
            Prepare();
            string userChoiceInput;
            int userChoice = 0;

            int computerChoice = 0;

            int userScore = 0;
            int computerScore = 0;
            int round = 1;
            bool continueLoop = false;
            do
            {
                if (round <= 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Welcome to Rock, Paper, Scissors game. Please enter a number below for your choice and press enter:");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Round " + round);
                    Console.WriteLine("User Points:" + userScore);
                    Console.WriteLine("Computer Points:" + computerScore);
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Please enter a number below for your choice and press enter:");
                    Console.WriteLine("------------------------------------------------------");
                    foreach (var item in GameOptions)
                    {
                        Console.WriteLine(String.Format(@"{0}{1}{2}", item.Id, ".", item.Option));
                    }
                    Console.WriteLine("------------------------------------------------------");

                    userChoiceInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userChoiceInput) || string.IsNullOrWhiteSpace(userChoiceInput))
                    {
                        Console.WriteLine("You must select an option !!");
                        Console.WriteLine();
                        continueLoop = true;//To make the loop run for select the option.
                        continue;
                    }
                    else if (!IsNumeric(userChoiceInput))
                    {
                        Console.WriteLine("You have selected an invalid option !!");
                        Console.WriteLine();
                        continueLoop = true;
                        continue;
                    }
                    else
                    {
                        userChoice = Convert.ToInt32(userChoiceInput);
                        if (userChoice < 1 || userChoice > 3)
                        {
                            Console.WriteLine("You have selected an invalid option !!");
                            Console.WriteLine();
                            continueLoop = true;
                            continue;
                        }
                    }
                    computerChoice = SelectComputerChoice(computerChoice);                    

                    var compChoice = GameOptions.Find(o => o.Id == computerChoice);
                    var usrChoice = GameOptions.Find(o => o.Id == userChoice);
                    Console.WriteLine("User chose " + usrChoice.Option);
                    Console.WriteLine("Computer chose " + compChoice.Option);

                    if (userChoice == computerChoice)
                    {
                        continueLoop = true;
                        Console.WriteLine("It is a tie.");
                        Console.WriteLine("Round restarts.");
                        continue;
                    }
                    else
                    {
                        if (compChoice.LosesTo.Contains(userChoice))//user earns a point.
                        {
                            userScore++;
                            Console.WriteLine("User earns a point.");
                        }
                        else
                        {
                            computerScore++;
                            Console.WriteLine("Computer earns a point.");
                        }
                        continueLoop = true;
                        round++;
                    }
                }
                else
                {
                    if (userScore > computerScore)
                    {
                        Console.WriteLine("User wins !!!!");
                    }
                    else
                    {
                        Console.WriteLine("Computer wins !!!!");
                    }
                    Console.ReadLine();
                }
            }
            while (continueLoop);
        }

        static void Prepare()
        {
            GameOptions = new List<GameOption> {
                new GameOption { Id = 1, Option = "Rock" , Beats = new List<int>{ 3 }, LosesTo = new List<int>{ 2 } },
                new GameOption { Id = 2, Option = "Paper" , Beats = new List<int>{ 1 }, LosesTo = new List<int>{ 3 }},
                new GameOption { Id = 3, Option = "Scissors" , Beats = new List<int>{ 2 }, LosesTo = new List<int>{ 1 }}
            };
        }

        static bool IsNumeric(string input)
        {
            return int.TryParse(input, out int n);
        }

        static int SelectComputerChoice(int previousChoice)
        {
            if (previousChoice == 0)
            {
                Random randomChoice = new Random();
                return randomChoice.Next(1, 4);
            }
            else
            {
                return GameOptions.Find(o => o.Beats.Contains(previousChoice)).Id;
            }
        }
    }
}
