using System;
using System.Collections.Generic;

namespace ProgrammingChallenge1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("How many sides do you want your dice to have?");

            var sides = RetrievePositiveInteger();

            Console.WriteLine("How many dice do you want to roll each time?");

            var dieCount = RetrievePositiveInteger();

            var rolls = new List<int>();
            
            var firstRoll = MakeDiceRoll(sides, dieCount);

            rolls.Add(firstRoll);

            while(true) {
                Console.WriteLine("Do you want to make another roll? (y/n)");

                var rolling = RetrieveYesOrNo();

                if(rolling) {
                    var roll = MakeDiceRoll(sides, dieCount);

                    rolls.Add(roll);
                } else {
                    break;
                }
            }

            Console.WriteLine("How many rolls would you like to examine?");

            int rollCount;
            while(true) {
                rollCount = RetrievePositiveInteger();

                if(rollCount > rolls.Count) {
                    Console.WriteLine($"Invalid input. Please input a number less than or equal to the total number of rolls ({rolls.Count})");
                } else {
                    break;
                }
            }

            Console.WriteLine("These are the dice rolls you made:");

            var rollsTotal = 0;

            for(var i = 0; i < rollCount; i += 1) {
                var roll = rolls[i];

                Console.WriteLine($"Roll {i + 1}: {roll}");

                rollsTotal += roll;
            }

            var rollsAverage = (float)rollsTotal / rollCount;

            Console.WriteLine($"The total of your rolls was {rollsTotal} and the average was {rollsAverage}");
        }

        static int MakeDiceRoll(int sides, int dieCount) {
            var random = new Random();

            int roll = 0;

            for(var i = 0; i < dieCount; i += 1) {
                roll += random.Next(sides) + 1;
            }

            Console.WriteLine($"You rolled a {roll}!");

            return roll;
        }

        static int RetrievePositiveInteger() {
            while(true) {                
                var text = Console.ReadLine();

                if(int.TryParse(text, out var number)) {
                    if(number == 0) {
                        Console.WriteLine("Invalid input. Please input a non-zero number.");
                    } else if(number < 0) {
                        Console.WriteLine("Invalid input. Please input a positive number.");
                    } else {
                        return number;
                    }
                } else {
                    Console.WriteLine("Invalid input. Please input a whole number.");
                }
            }
        }

        static bool RetrieveYesOrNo() {
            while(true) {
                var text = Console.ReadLine().Trim().ToLower();

                if(text == "y") {
                    return true;
                } else if(text == "n") {
                    return false;
                } else {
                    Console.WriteLine("Invalid input. Please input 'y' or 'n'.");
                }
            }
        }
    }
}