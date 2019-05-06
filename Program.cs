using System;
using System.Collections.Generic;

namespace ProgrammingChallenge1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("How many sides do you want your dice to have?");

            var sides = RetrievePositiveInteger();

            var rolls = new List<int>();
            
            var firstRoll = MakeDiceRoll(sides);

            rolls.Add(firstRoll);

            while(true) {
                Console.WriteLine("Do you want to make another roll? (y/n)");

                var rolling = RetrieveYesOrNo();

                if(rolling) {
                    var roll = MakeDiceRoll(sides);

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

            var rollTotal = 0;

            for(var i = 0; i < rollCount; i += 1) {
                var roll = rolls[i];

                Console.WriteLine($"Roll {i + 1}: {roll}");

                rollTotal += roll;
            }

            var averageRoll = rollTotal / rollCount;

            Console.WriteLine($"The total of your rolls was {rollTotal} and your average roll was {averageRoll}");
        }

        static int MakeDiceRoll(int sides) {
            Console.WriteLine("Do you want to roll two dice? (y/n)");

            var rollingTwice = RetrieveYesOrNo();

            var random = new Random();

            var roll = random.Next(sides) + 1;

            if(rollingTwice) {
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