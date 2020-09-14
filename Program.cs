using System;
using System.Collections.Generic;
namespace StrFragmentation
{
    public class Program
    {
        /*
         * Решение основывается на сравнении индекса текущего символа,
         * который перебирается в строке, с последним индексом этого 
         * символа, который встречается в строке.
         */
        static int[] StrFragmentation(string str)
        {
            List<int> ans = new List<int>();
            char letter;
            int end = -1;   // здесь храниться граница проверяемого участка,
                            // идея в том, что если индекс текущего символа
                            // больше чем эта граница, то этот символ является
                            // началом нового участка.
            for (int i = 0; i < str.Length; i++)
            {
                if (i == end)   // если индекс текущего символа равен границе,
                                // то это конец учаска.
                {
                    // в этом случае вычисляется длина участка и запиывается в ответ.
                    // Длина вычисляется вычитанием из индекса конца участка длин всех найденных участков.
                    foreach (int item in ans)
                    {
                        end -= item;
                    }
                    ans.Add(end + 1); // т.к. мы вычисляем длину из индекса, нужно не забыть прибавить 1
                    continue;
                }
                letter = str.ToCharArray()[i];
                int lastIndex = str.LastIndexOf(letter);

                if (lastIndex == i && i > end)  // в этом случае текущий символ является участком сам по себе
                {
                    ans.Add(1);
                    continue;
                }
                if (lastIndex > end)    // если символ в текущем участке встречается за его текущей границей,
                                        // то последний индекс этого символа, который встречается в строке,
                                        // становится новой границей.
                {
                    end = lastIndex;
                }
            }
            return ans.ToArray();
        }

        public static void Main(string[] args)
        {
            string s = "ababdeeda";
            Console.WriteLine("string:" + s);
            foreach (var item in StrFragmentation(s))
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            s = "ababdeedhigtht";
            Console.WriteLine("string:" + s);
            foreach (var item in StrFragmentation(s))
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
    }
}
