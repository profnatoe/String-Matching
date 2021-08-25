using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string name1, name2, sentence;
            bool isName1Correct = true;
            bool isName2Correct = true;
            do
            {
                Console.WriteLine("Enter your first name");
                name1 = Console.ReadLine();

                isName1Correct = IsAllLetters(name1);
                
                Console.WriteLine("Enter your second name");

                name2 = Console.ReadLine();

                isName2Correct = IsAllLetters(name2);

                if (!isName1Correct || !isName2Correct)
                    Console.WriteLine("One of the entered values contains non-alphabetic characters");
            } while (!isName1Correct || !isName2Correct);

            sentence = $"{name1} matches {name2}";

            var matchCount = CalculateMatches(sentence);
            var percentCount = CalculatePercentage(matchCount);
            DeclareOutput(percentCount, name1, name2);
        }

        public static bool IsAllLetters(string sentence)
        {
            foreach(var c in sentence)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public static string CalculateMatches(string sentence)
        {
            var newString = "";
            sentence = sentence.ToLower();
            sentence = Regex.Replace(sentence, @" ", "");
            foreach(var letter in sentence)
            {
                newString += sentence.Count(a => a == letter);
                sentence = sentence.Replace(letter.ToString(), "");
            }
            //remove the zeros from the string
            newString = Regex.Replace(newString, @"0", "");
            return newString;
        }

        public static string CalculatePercentage(int numbers)
        {
            var newString = numbers.ToString();
            var l = 0;
            var r = newString.Length - 1;
            var sum = new { };

            if (newString.Length <= 2)
                return numbers.ToString();

            
        }

        public static void DeclareOutput(string percentage, string name, string otherName)
        {
            var p = Convert.ToInt32(percentage);
            if (p >= 80)
                Console.WriteLine($"{name} matches {otherName} {p}%, good match");
            else Console.WriteLine($"{name} matches {otherName} {p}%");
        }
    }
}
