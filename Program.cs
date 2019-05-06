using System;
using System.Collections.Generic;

namespace ProgrammingChallenge1 {
    class Program {
        static void Main(string[] args) {
            var rolls = new List<int>();
            
            var firstRoll = MakeDiceRoll();

            rolls.Add(firstRoll);

            while(true) {
                Console.WriteLine("Do you want to roll another die? (y/n)");

                bool rolling;
                while(true) {
                    var inputText = Console.ReadLine().Trim().ToLower();

                    if(inputText == "y") {
                        rolling = true;
                        break;
                    } else if(inputText == "n") {
                        rolling = false;
                        break;
                    } else {
                        Console.WriteLine("Invalid input. Please input 'y' or 'n'.");
                    }
                }

                if(rolling) {
                    var roll = MakeDiceRoll();

                    rolls.Add(roll);
                } else {
                    break;
                }
            }

            Console.WriteLine("How many rolls would you like to examine?");

            int rollCount;
            while(true) {
                var rollCountText = Console.ReadLine();

                if(int.TryParse(rollCountText, out rollCount)) {
                    if(rollCount > rolls.Count) {
                        Console.WriteLine("Invalid Input. Please input a number of rolls less than or equal to the total number of rolls.");
                    } else if(rollCount == 0) {
                        Console.WriteLine("Invalid input. Please input a non-zero number of rolls.");
                    } else if(rollCount < 0) {
                        Console.WriteLine("Invalid Input. Please input a positive number of rolls.");
                    } else {
                        break;
                    }
                } else {
                    Console.WriteLine("Invalid input. Please input a whole number of rolls.");
                }
            }

            Console.WriteLine("These are the dice rolls you made:");

            var rollTotal = 0;

            for(var i = 0; i < rollCount; i += 1) {
                var roll = rolls[i];

                Console.WriteLine($"Roll {i + 1}: {roll}");

                rollTotal += roll;
            }

            var averageRoll = rollTotal / rollCount;

            Console.WriteLine($"The total of your rolls was {rollTotal} and your average roll was {averageRoll}");
        }

        static int MakeDiceRoll() {
            var random = new Random();

            var roll = random.Next(6) + 1;

            Console.WriteLine($"You rolled a {roll}!");

            return roll;
        }
    }
}