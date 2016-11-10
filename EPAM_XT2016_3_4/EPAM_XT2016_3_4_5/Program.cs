using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_4_5
{
    internal class Program
    {
        public static bool validSignOrDot = false;

        private static void Main(string[] args)
        {
            string stringForParse = "1.1102111111112e13";

            Console.WriteLine(FindLongestSeq(stringForParse));
        }

        private static int CharToInt(char c)
        {
            return c - '0';
        }

        public static bool FindLongestSeq(string stringForParse)
        {
            char[] notNullDigit = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] separator = { '.', ',' };
            char[] exp = { 'e', 'E' };
            List<int> partsOnDegree = new List<int>();
            double sumDegree = 0;
            int counterBeforeExp = 1;
            string caseSwitch = "0";
            bool isPositiveInteger = true;

            for (int i = 0; i < stringForParse.Length; i++)
            {
                switch (caseSwitch)
                {
                    case "0":
                        {
                            if (stringForParse[i] == '+')
                            {
                                caseSwitch = "2";
                                break;
                            }
                            if (notNullDigit.Contains(stringForParse[i]))
                            {
                                caseSwitch = "1";
                                break;
                            }
                            return false;
                        }
                    case "1":
                        {
                            if (char.IsDigit(stringForParse[i]))
                            {
                                caseSwitch = "3";
                                break;
                            }
                            if (exp.Contains(stringForParse[i]))
                            {
                                caseSwitch = "5";
                                break;
                            }
                            if (separator.Contains(stringForParse[i]))
                            {
                                caseSwitch = "4";
                                break;
                            }
                            return false;
                        }
                    case "2":
                        {
                            if (notNullDigit.Contains(stringForParse[i]))
                            {
                                caseSwitch = "1";
                                break;
                            }
                            return false;
                        }
                    case "3":
                        {
                            if (char.IsDigit(stringForParse[i]))
                            {
                                caseSwitch = "3";
                                break;
                            }
                            return false;
                        }
                    case "4":
                        {
                            if (notNullDigit.Contains(stringForParse[i]))
                            {
                                caseSwitch = "7";
                                break;
                            }
                            return false;
                        }
                    case "5":
                        {
                            if (notNullDigit.Contains(stringForParse[i]))
                            {
                                caseSwitch = "3";
                                break;
                            }
                            if (stringForParse[i] == '+')
                            {
                                caseSwitch = "6";
                                break;
                            }
                            return false;
                        }
                    case "6":
                        {
                            if (notNullDigit.Contains(stringForParse[i]))
                            {
                                caseSwitch = "3";
                                break;
                            }

                            return false;
                        }
                    case "7":
                        {
                            if (char.IsDigit(stringForParse[i]))
                            {
                                counterBeforeExp++;
                                caseSwitch = "7";
                                break;
                            }
                            if (exp.Contains(stringForParse[i]))
                            {
                                caseSwitch = "8";
                                break;
                            }
                            return false;
                        }
                    case "8":
                        {
                            if (notNullDigit.Contains(stringForParse[i]))
                            {
                                partsOnDegree.Add(CharToInt(stringForParse[i]));
                                caseSwitch = "10";
                                break;
                            }
                            if (stringForParse[i] == '+')
                            {
                                caseSwitch = "9";
                                break;
                            }
                            return false;
                        }
                    case "9":
                        {
                            if (notNullDigit.Contains(stringForParse[i]))
                            {
                                caseSwitch = "10";
                                break;
                            }
                            return false;
                        }
                    case "10":
                        {
                            if (char.IsDigit(stringForParse[i]))
                            {
                                if (counterBeforeExp >= partsOnDegree.Count)
                                {
                                    partsOnDegree.Add(CharToInt(stringForParse[i]));
                                }
                                caseSwitch = "10";
                                break;
                            }
                            return false;
                        }
                }
            }

            for (int i = 0; i < partsOnDegree.Count; i++)
            {
                sumDegree += partsOnDegree[i] * Math.Pow(10, partsOnDegree.Count - 1 - i);
            }

            if (counterBeforeExp > sumDegree)
                return false;

            return isPositiveInteger;
        }
    }
}