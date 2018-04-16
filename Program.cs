using System;
using System.Text;

namespace TitleCapitalizationTool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                StringCapitalization();
            }
            else
            {
                foreach (string gotTextLine in args)
                {
                    StringCapitalization(gotTextLine);
                }
            }
        }

        private static void StringCapitalization()
        {
            string gotTextLine = null;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "TitleCapitalizationTool";
            Console.Write("Enter title to capitalize: ");
            Console.ForegroundColor = ConsoleColor.Red;
            gotTextLine = GetTextline();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Capitalized title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string gotTextLineCopy = BuildString(gotTextLine);
            Console.WriteLine(gotTextLineCopy);
            Console.WriteLine();
            StringCapitalization();
        }

        private static void StringCapitalization(string gotTextLine)
        {
            //string gotTextLine = null;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "TitleCapitalizationTool";
            Console.Write("Original title: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(gotTextLine);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Capitalized title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string gotTextLineCopy = BuildString(gotTextLine);
            Console.WriteLine(gotTextLineCopy);
            Console.WriteLine();
         }

        private static string BuildString(string gotTextLine)
        {
            string gotTextLineCopy = gotTextLine;
            if (!string.IsNullOrWhiteSpace(gotTextLineCopy))
            {
                gotTextLineCopy = gotTextLineCopy.Trim();
                gotTextLineCopy = gotTextLineCopy.ToLower();
                gotTextLineCopy = SpaceNormalization(gotTextLineCopy);
                gotTextLineCopy = SeparatorNormalization(gotTextLineCopy);
                gotTextLineCopy = CaseNormalization(gotTextLineCopy);
            }
            return gotTextLineCopy;
        }

        private static string CaseNormalization(string processedString)
        {
            string[] wordsArray = processedString.Split(' ');
            int arrayLendth = wordsArray.Length - 1;
            StringBuilder constructedString = new StringBuilder();
            for (int i = 0; i <= arrayLendth; i++)
            {
                string currentWord = wordsArray[i];
                if (CheckIfLowercase(currentWord) && i != arrayLendth)
                {
                    constructedString.Append(currentWord + ' ');
                }
                else
                {
                    if (currentWord.Length != 0)
                    {
                        constructedString.Append(UpperFirstWordLetter(currentWord) + ' ');
                    }
                }
            }
            constructedString[0] = char.ToUpper(constructedString[0]);
            return constructedString.ToString().Trim();
        }

        private static string UpperFirstWordLetter(string processedString)
        {
            StringBuilder constructedString = new StringBuilder(processedString);
            if (char.IsLetter(constructedString[0]))
            {
                constructedString[0] = char.ToUpper(constructedString[0]);
            }
            return constructedString.ToString();
        }

        private static string SpaceNormalization(string processedString)
        {
            string[] wordsArray = processedString.Split(' ');
            StringBuilder constructedString = new StringBuilder();
            foreach (string currentWord in wordsArray)
            {
                if (currentWord.Length != 0)
                {
                    constructedString.Append(' ' + currentWord);
                }
            }
            return constructedString.ToString().Trim();
        }

        private static string SeparatorNormalization(string processedString)
        {
            string[] wordsArray = processedString.Split(' ');
            StringBuilder constructedString = new StringBuilder();
            foreach (string currentWord in wordsArray)
            {
                int currentWordLendth = currentWord.Length;
                for (int i = 0; i < currentWordLendth; i++)
                {
                    if (!CheckIfSeparator(currentWord[i]))
                    {
                        constructedString.Append(currentWord[i]);
                    }
                    else
                    {
                        constructedString=AddSeparator(constructedString, currentWord[i]);
                    }
                }
                constructedString.Append(' ');
            }
            return constructedString.ToString().Trim();
        }

        private static StringBuilder AddSeparator(StringBuilder constructedString, char currentSeparator)
        {
            int constructedStringLendth = constructedString.Length;
            StringBuilder modifiedString = new StringBuilder(constructedString.ToString().TrimEnd());
            if (currentSeparator != '-')
            {
                modifiedString.Append(currentSeparator);
                modifiedString.Append(' ');
            }
            else
            {
                modifiedString.Append(" - ");
            }
            return modifiedString;
        }

        private static bool CheckIfLowercase(string processedString)
        {
            string[] lowerCaseElementsList = {"a", "an", "and", "at", "but", "by", "for", "in", "nor", "of", "on", "or", "out", "so", "the", "to", "up", "yet"};
            bool isLowerCase = false;
            foreach (string currentlowerCaseElement in lowerCaseElementsList)
            {
                if (currentlowerCaseElement == processedString)
                {
                    isLowerCase = true;
                    break;
                }
            }
            return isLowerCase;
        }

        private static bool CheckIfSeparator(char symbolToCheck)
        {
            char[] separatorsList = {'.', ',', ';', ':', '!', '?', '-'};
            bool isSeparator = false;
            foreach (char currentSeparator in separatorsList)
            {
                if (currentSeparator == symbolToCheck)
                {
                    isSeparator = true;
                    break;
                }
            }
            return isSeparator;
        }
        private static string GetTextline()
        {
            string gotTextLine = null;
            bool fixCurrentCursorPosition = true;
            do
            {
                int fixedCursorLeft = Console.CursorLeft;
                int fixedCursorTop = Console.CursorTop;
                gotTextLine = Console.ReadLine();
                if (string.IsNullOrEmpty(gotTextLine))
                {
                    Console.CursorLeft = fixedCursorLeft;
                    Console.CursorTop = fixedCursorTop;
                }
                else
                {
                    fixCurrentCursorPosition = false;
                }
            } while (fixCurrentCursorPosition);
            return gotTextLine;
        }
    }
}