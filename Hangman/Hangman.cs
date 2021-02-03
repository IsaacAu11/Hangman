using System;
using System.Linq;
using System.Collections.Generic;

namespace Hangman
{
    class Hangman
    {
        static List<int> Compare(string[] Array,string letter,int WordLength) 
        {
            List<int> myList = new List<int>();
            for (int i = 1; i < WordLength+1; i++)
            {
                if (letter == Array[i - 1])
                {
                    myList.Add(i-1);
                }
            }
            return myList;
        }

        static void Main(string[] args)
        {
            string result = "";
            int tries = 10;
            bool Win = false;
            string Word = "";
            string[] Asterisks = { };
            string[] HangmanWord = { };
            Random Rnd = new Random();
            int HangmanWordsRandom = Rnd.Next(1, 8);
            switch (HangmanWordsRandom) 
            {
                case 1:
                    HangmanWord = new string[] { "e", "m", "b", "e", "z", "z", "l", "e" };
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*", "*", "*"};
                    Word = "embezzle";
                    break;
                case 2:
                    HangmanWord = new string[] { "b", "u", "f", "f", "a", "l", "o",};
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*", "*"};
                    Word = "buffalo";
                    break;
                case 3:
                    HangmanWord = new string[] { "q", "u", "a", "r", "t", "z"};
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*"};
                    Word = "quartz";
                    break;
                case 4:
                    HangmanWord = new string[] { "o", "x", "y", "g", "e", "n"};
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*"};
                    Word = "oxygen";
                    break;
                case 5:
                    HangmanWord = new string[] { "s", "c", "r", "a", "t", "c", "h", };
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*", "*"};
                    Word = "scratch";
                    break;
                case 6:
                    HangmanWord = new string[] { "s", "t", "r", "e", "n", "g", "t", "h" };
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*", "*", "*" };
                    Word = "strength";
                    break;
                case 7:
                    HangmanWord = new string[] { "i", "n", "v", "o", "k", "e"};
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*" };
                    Word = "invoke";
                    break;
                case 8:
                    HangmanWord = new string[] { "r", "h", "y", "t", "h", "m", };
                    Asterisks = new string[] { "*", "*", "*", "*", "*", "*"};
                    Word = "rhythm";
                    break;
            }
            int WordLength = HangmanWord.Length;
            while (Win == false || tries >0) 
            {
                Console.WriteLine("Guess a letter :");
                string LetterGuess = Console.ReadLine();
                if (LetterGuess == Word || result == Word)
                {
                    Win = true;
                    break;
                }
                else
                {
                    List<int> Comparison = Compare(HangmanWord, LetterGuess, WordLength);
                    int ComparisonLength = Comparison.Count;
                    if (ComparisonLength == 0)
                    {
                        result = (string.Join("", Asterisks));
                        Console.WriteLine(result);
                        Console.WriteLine("You guessed wrong, please try again.");
                        tries -= 1;
                        Console.WriteLine("You have " + tries + " tries left");
                        Console.WriteLine();
                    }
                    else
                    {
                        foreach (var item in Comparison)
                        {
                            Asterisks[item] = HangmanWord[item];
                        }
                        result = (string.Join("",Asterisks));
                        Console.WriteLine(result);
                        Console.WriteLine();
                    }
                }
                
            }
            if (Win == true)
            {
                Console.WriteLine("Congrats! You win");
            }
            else if (Win == false || tries == 0) 
            {
                Console.WriteLine("You lose!");
            }

        }
    }
}
