using System;
using System.Text;

namespace TitleCapitalizationTool

{
    internal class Program
    {

        private static void Main()
        {
            StringCapitalization();
        }

        private static void StringCapitalization()
        {
            String gotTextLine = null;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "TitleCapitalizationTool";
            Console.Write("Enter title to capitalize: ");
            Console.ForegroundColor = ConsoleColor.Red;
            bool fixCurrentCursorPosition = true;
            do
            {
                int fixedCursorLeft = Console.CursorLeft;
                int fixedCursorTop = Console.CursorTop;
                gotTextLine = Console.ReadLine();
                if (String.IsNullOrEmpty(gotTextLine) || String.IsNullOrWhiteSpace(gotTextLine))
                {
                    Console.CursorLeft = fixedCursorLeft;
                    Console.CursorTop = fixedCursorTop;
                }
                else
                {
                    fixCurrentCursorPosition = false;
                }
            } while (fixCurrentCursorPosition);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Capitalized title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            String gotTextLineCopy = gotTextLine;
            gotTextLineCopy = gotTextLineCopy.Trim();
            gotTextLineCopy = gotTextLineCopy.ToLower();
            gotTextLineCopy = SpaceNormalization(gotTextLineCopy);
            gotTextLineCopy = SeparatorNormalization(gotTextLineCopy);
            gotTextLineCopy = CaseNormalization(gotTextLineCopy);
            Console.WriteLine(gotTextLineCopy);
            Console.WriteLine();
            StringCapitalization();
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
                    constructedString.Append(UpperFirstWordLetter(currentWord) + ' ');
                }
            }
            constructedString[0] = char.ToUpper(constructedString[0]);
            return constructedString.ToString().Trim();
        }

        private static string UpperFirstWordLetter(string processedString)
        {
            StringBuilder constructedString = new StringBuilder(processedString);
            if (Char.IsLetter(constructedString[0]))
            {
                constructedString[0] = Char.ToUpper(constructedString[0]);
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
                    if (CheckIfSeparator(currentWord[i]))
                    {
                        if (currentWord[i] == '-')
                        {
                            constructedString.Append(" - ");
                        }
                        else
                        {
                            if ((i + 1) != currentWordLendth && Char.IsLetter(currentWord[i + 1]))
                            {
                                constructedString.Append(currentWord[i]);
                                constructedString.Append(' ');
                                Console.WriteLine(currentWord[i]);
                            }
                            else
                            {
                                constructedString.Append(currentWord[i]);
                            }
                        }
                    }
                    else
                    {
                        constructedString.Append(currentWord[i]);
                    }
                }
                constructedString.Append(' ');
            }
            return constructedString.ToString().Trim();
        }

        private static bool CheckIfLowercase(String processedString)
        {
            String[] lowerCaseElementsList = { "a", "an",  "and","at", "but", "by", "for", "in", "nor",  "of", "on", "or", "out", "so", "the", "to", "up", "yet" };
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
            char[] SeparatorsList = { '.', ',', ';', ':', '!', '?', '-' };
            bool isSeparator = false;
            foreach (char currentSeparator in SeparatorsList)
            {
                if (currentSeparator == symbolToCheck)
                {
                    isSeparator = true;
                    break;
                }
            }
            return isSeparator;
        }
    }

}


