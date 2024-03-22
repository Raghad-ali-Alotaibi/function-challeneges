using System;
using System.Globalization;

namespace FunctionChallenges
{
    class Program
    {
        // Challenge 1: String and Number Processor
        static void StringNumberProcessor(params object[] inputs)
        {
            List<string> strings = new List<string>();
            List<int> Numbers = new List<int>();

            // check inputs is a string or number
            foreach (var input in inputs)
            {
                if (input is string)
                {
                    strings.Add((string)input);
                }
                else if (input is int)
                {
                    Numbers.Add((int)input);
                }
            }
            int sum = 0;
            foreach (int num in Numbers)
            {
                sum += num;
            }
            string result = string.Join(" ", strings) + "; " + sum;
            Console.WriteLine(result);
        }

        // Challenge 2: Object Swapper
        static void SwapObjects(ref dynamic input1, ref dynamic input2)
        {
            try
            {
                if (input1.GetType() != input2.GetType())
                {
                    throw new Exception("Objects must be of same types");
                }
                switch (input1)
                {
                    case string:
                        if (input1.Length > 5 && input2.Length > 5)
                        {
                            string tempStr1 = input1;
                            input1 = input2;
                            input2 = tempStr1;
                        }
                        else
                        {
                            Console.WriteLine("Length must be more than 5");
                        }
                        break;
                    case int:
                        if (input1 > 18 && input2 > 18)
                        {
                            int tempNum1 = input1;
                            input1 = input2;
                            input2 = tempNum1;
                        }
                        else
                        {
                            Console.WriteLine("Value must be more than 18");
                        }
                        break;
                    default:
                        throw new Exception("Unsupported type or value conditions not met");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The Exception: " + e.Message);
            }
        }

        // Challenge 3: Guessing Game
        static void GuessingGame()
        {
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int userGuess = 0;
            Console.WriteLine("Guess a number between 1 and 100 or enter 'Quit' to exit.");

            try
            {
                while (true)
                {
                    Console.WriteLine("Enter your guess: ");
                    string input = Console.ReadLine() ?? "";

                    if (input.ToLower() == "quit")
                    {
                        Console.WriteLine("Game is terminated");
                        break;
                    }

                    if (!int.TryParse(input, out userGuess))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number or 'Quit'.");
                        continue;
                    }

                    if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You guessed the number correctly: " + numberToGuess);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The Exception" + e.Message);
            }
        }

        // Challenge 4: Simple Word Reversal
        static string ReverseWords(string sentence)
        {
            string[] words = sentence.Split(' ');
            string reversedSentence = "";

            foreach (string word in words)
            {
                char[] wordChars = word.ToCharArray();
                Array.Reverse(wordChars);
                reversedSentence += new string(wordChars) + " ";
            }
            return reversedSentence.Trim();
        }


        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"

            // Challenge 2: Object Swapper
            Console.WriteLine("\nChallenge 2: Object Swapper");
            object num1 = 25, num2 = 30;
            object num3 = 10, num4 = 30;
            object str1 = "HelloWorld", str2 = "Programming";
            object str3 = "Hi", str4 = "Programming";
            object bool1 = true, bool2 = false;

            SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25  
            SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            SwapObjects(ref str1, ref str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            SwapObjects(ref str3, ref str4); // Error: Length must be more than 5

            SwapObjects(ref bool1, ref bool2); // Error: Upsupported data type
            SwapObjects(ref num1, ref str1); // Error: Objects must be of same types

            Console.WriteLine($"Numbers: {num1}, {num2}");
            Console.WriteLine($"Strings: {str1}, {str2}");

            // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // Challenge 4: Simple Word Reversal
            Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            string sentence = "This is the original sentence!";
            string reversed = ReverseWords(sentence);
            Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }
    }
}