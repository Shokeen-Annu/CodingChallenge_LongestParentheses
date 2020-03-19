using System;

namespace CodingChallenge_LongestParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This algorithm will return maximum length of exact parenthesis pairs in a string.");
            Console.WriteLine("For example ()()))((())) should return 6");
            Console.WriteLine("Enter string with only '(' and ')' e.g. (()()");
            string input = Console.ReadLine();
            char[] strArr = input.ToCharArray();
            int maxLen = 0;
            for (int j = 0; j < strArr.Length; j++)
            {
               if(strArr[j] == '(')
                {
                    int[] result = findExactPairs(strArr, j);
                    if((result[1]) > j)
                        j = result[1] - 1;
                    if (maxLen < result[0])
                        maxLen = result[0];
                }


            }
            Console.WriteLine(maxLen);
            Console.Read();
        }

        public static int[] findExactPairs(char[] input, int index)
        {
            int length = 0;
            int startIndex = 0;
            int openCount = 0;
            int closeCount = 0;
            for (int j = index; j < input.Length; j++)
            {

                if (input[j] == '(')
                {
                    openCount += 1;
                }
                if (input[j] == ')')
                {
                    startIndex = j;
                    break;
                }
            }
            if (startIndex > 0)
            {
                for (int i = startIndex; i < input.Length; i++)
                {
                    if (input[i] == ')')
                    {
                        closeCount += 1;

                    }
                    if (input[i] == '(')
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (openCount >= closeCount)
                length += 2 * closeCount;
        
            return new int[] { length, index };
        }
    }
}
