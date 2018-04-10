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
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "English text capitalisation";
            Console.Write("Enter title to capitalize:");
            Console.ForegroundColor = ConsoleColor.Red;
            gotTextLine = Console.ReadLine();
            if (gotTextLine.Length == 0)
                StringCapitalization();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Capitalised text:");
            Console.ForegroundColor = ConsoleColor.Green;
            string tmpGotline = gotTextLine;
            tmpGotline = tmpGotline.Trim();
            tmpGotline = tmpGotline.ToLower();
            tmpGotline = SpaceNormalization(tmpGotline);
            tmpGotline = SeparatorNormalization(tmpGotline);
            tmpGotline = CaseNormalisation(tmpGotline);
            Console.WriteLine(tmpGotline);
            StringCapitalization();
        }

        private static string CaseNormalisation(string myLine)
        {
            string[] ar = myLine.Split(' ');
            int arrayLen = ar.Length - 1;
            StringBuilder sb = new StringBuilder(null);
            for (int i = 0; i <= arrayLen; i++)
            {
                string str = ar[i];
                if (CheckIfLowercase(str) == true && i != arrayLen)
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

            if (Char.IsLetter(sb[0]) == true)
                sb[0] = Char.ToUpper(sb[0]);
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
                    if (CheckIfSeparator(str[i]) == true)
                    {
                        if (str[i] == '-')
                            sb.Append(" - ");
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
            String[] lowerCaseElementsList = { "a", "an", "the", "and", "but", "for", "nor", "so", "yet", "at", "by", "in", "of", "on", "or", "out", "to", "up" };
            foreach (string str in lowerCaseElementsList)
            {
                if (str == myStr)
                    return true;
            }

            return false;
        }

        private static bool CheckIfSeparator(char myChar)
        {
            char[] SeparatorsList = { '.', ',', ';', ':', '!', '?', '-' };
            foreach (char cChar in SeparatorsList)
            {
                if (cChar == myChar)
                    return true;
            }
            return false;
        }

        private static string UpperFirstLetter(string mysrt)
        {

            return mysrt;
        }
    }

}


