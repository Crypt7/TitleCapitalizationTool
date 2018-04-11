using System;
using System.Text;

namespace TitleCapitalizationTool

{
    class Program
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
            String tmpGotline = gotTextLine;
            tmpGotline = tmpGotline.Trim();
            tmpGotline = tmpGotline.ToLower();
            tmpGotline = SpaceNormalization(tmpGotline);
            tmpGotline = SeparatorNormalization(tmpGotline);
            tmpGotline = CaseNormalization(tmpGotline);
            Console.WriteLine(tmpGotline);
            Console.WriteLine();
            StringCapitalization();
        }

        private static string CaseNormalization(string myLine)
        {
            string[] ar = myLine.Split(' ');
            int arrayLen = ar.Length - 1;
            StringBuilder sb = new StringBuilder(null);
            for (int i = 0; i <= arrayLen; i++)
            {
                string str = ar[i];
                if (CheckIfLowercase(str) && i != arrayLen)
                {
                    sb.Append(str + ' ');
                }
                else
                {
                    sb.Append(UpperFirstWordLetter(str) + ' ');
                }
            }
            sb[0] = char.ToUpper(sb[0]);
            return sb.ToString().Trim();
        }

        private static string UpperFirstWordLetter(string myString)
        {
            StringBuilder sb = new StringBuilder(myString);
            if (Char.IsLetter(sb[0]))
            {
                sb[0] = Char.ToUpper(sb[0]);
            }
            return sb.ToString();
        }

        private static string SpaceNormalization(string myLine)
        {
            string[] ar = myLine.Split(' ');
            StringBuilder sb = new StringBuilder(null);
            foreach (string str in ar)
            {
                if (str.Length != 0)
                {
                    sb.Append(' ' + str);
                }
            }
            return sb.ToString().Trim();
        }

        private static string SeparatorNormalization(string myLine)
        {
            string[] ar = myLine.Split(' ');
            StringBuilder sb = new StringBuilder(null);
            foreach (string str in ar)
            {
                int cLen = str.Length;
                for (int i = 0; i < cLen; i++)
                {
                    if (CheckIfSeparator(str[i]))
                    {
                        if (str[i] == '-')
                        {
                            sb.Append(" - ");
                        }
                        else
                        {
                            if ((i + 1) != cLen && Char.IsLetter(str[i + 1]) == true)
                            {
                                sb.Append(str[i]);
                                sb.Append(' ');
                                Console.WriteLine(str[i]);
                            }
                            else
                            {
                                sb.Append(str[i]);
                            }
                        }
                    }
                    else
                    {
                        sb.Append(str[i]);
                    }
                }
                sb.Append(' ');
            }
            return sb.ToString().Trim();
        }

        private static bool CheckIfLowercase(String myStr)
        {
            String[] lowerCaseElementsList = { "a", "an",  "and","at", "but", "by", "for", "in", "nor",  "of", "on", "or", "out", "so", "the", "to", "up", "yet" };
            bool isLowerCase = false;
            foreach (string str in lowerCaseElementsList)
            {
                if (str == myStr)
                {
                    isLowerCase = true;
                    break;
                }
            }
            return isLowerCase;
        }

        private static bool CheckIfSeparator(char myChar)
        {
            char[] SeparatorsList = { '.', ',', ';', ':', '!', '?', '-' };
            bool isSeparator = false;
            foreach (char cChar in SeparatorsList)
            {
                if (cChar == myChar)
                {
                    isSeparator = true;
                    break;
                }
            }
            return isSeparator;
        }
    }

}


