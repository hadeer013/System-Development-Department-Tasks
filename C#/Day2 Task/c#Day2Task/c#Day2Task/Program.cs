using System.Diagnostics;
using System.Text;

namespace c_Day2Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LongestDistance
            Console.WriteLine("Enter size of array");
            int size = int.Parse(Console.ReadLine());

            int[] arrNum = new int[size];

            for (int i = 0; i < size; i++)
                arrNum[i] = int.Parse(Console.ReadLine());

            int maxDis = LongestDistance(arrNum);
            Console.WriteLine(maxDis);

            #endregion

            #region Reverse Sentence
            //ReverseWords("my name is hadeer");
            #endregion

            #region CountOneOccurances

            //Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();
            //Console.WriteLine($"Number of ones : {CountOneOccurancesUsingSplit(1, 99_999_999)}");
            //stopwatch.Stop();

            //Console.WriteLine($"Time elapsed in millisecond using Split: {stopwatch.Elapsed}");
            //Console.WriteLine("=====================================================");

            //stopwatch.Restart();
            //Console.WriteLine($"Number of ones : {CountOneOccurancesLoopsOverStr(1, 99_999_999)}");
            //stopwatch.Stop();

            //Console.WriteLine($"Time elapsed in millisecond using LoopsOverStr: {stopwatch.Elapsed}");
            //Console.WriteLine("=====================================================");



            //stopwatch.Restart();
            //Console.WriteLine($"Number of ones : {CountOnesOccurancesMathematically(1, 99_999_999)}");
            //stopwatch.Stop();

            //Console.WriteLine($"Time elapsed in millisecond using integers: {stopwatch.Elapsed}");
            //Console.WriteLine("=====================================================");

            //stopwatch.Restart();
            //Console.WriteLine($"Number of ones : {CountOnesOccurancesMathematicEquation(8)}");
            //stopwatch.Stop();

            //Console.WriteLine($"Time elapsed in millisecond using Equation: {stopwatch.Elapsed}");
            //Console.WriteLine("=====================================================");
            #endregion
        }


        static int LongestDistance(int[] arr)
        {
            int maxDis = -1;

            for(int i = 0; i < arr.Length-1; i++)
                for(int j = i+1;j<arr.Length;j++)
                {
                    if (arr[i] == arr[j])
                        maxDis = Math.Max(maxDis, j - i-1);

                }
            return maxDis;
        }

        static void ReverseWords(string sentence)
        {
            string[]splitedWords = sentence.Split(' ');
            Array.Reverse(splitedWords);

            StringBuilder Reversed=new StringBuilder();
            for (int i = 0; i < splitedWords.Length; i++)
            {
                Reversed.Append(splitedWords[i] );
                if(i!= splitedWords.Length-1)
                    Reversed.Append(' ');
            }

            Console.WriteLine(Reversed);
        }

        static int CountOneOccurancesUsingSplit(int startNumber, int endNumber)
        {
            int count = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                string value = Convert.ToString(i);
                count += (value.Split('1').Length-1);

            }
            return count;
        }

        #region IndexOfTest
        //static int CountOneOccurancesUsingIndexOf(int startNumber, int endNumber)
        //{
        //    int count = 0,st_index=0;
        //    for (int i = startNumber; i <= endNumber; i++)
        //    {
        //        string value = Convert.ToString(i);
        //        do
        //        {
        //            st_index = value.IndexOf('1', st_index);
        //            if (st_index != -1) { count++; st_index++; }
        //        } while (st_index!=-1 || st_index>value.Length);

        //    }
        //    return count;
        //}
        #endregion
        static int CountOneOccurancesLoopsOverStr(int startNumber, int endNumber)
        {
            int count = 0;
            for (int i = startNumber; i < endNumber; i++)
            {
                string value = Convert.ToString(i);
                for (int j = 0; j < value.Length; j++)
                    if (value[j] == '1') count++;
            }
            return count;
        }

        static int CountOnesOccurancesMathematically(int startNumber, int endNumber)
        {
            int count = 0;
            for(int i = startNumber;i <= endNumber;i++)
            {
                int temp = i;
                while(temp > 0)
                {
                    int mod = temp % 10;
                    if(mod == 1) count++;
                    temp /= 10;
                }
            }
            return count;
        }

        static double CountOnesOccurancesMathematicEquation(int NumOfDigits)
        {
            double count = NumOfDigits * Math.Pow(10, NumOfDigits - 1);

            return count;
        }
    }

    
}
