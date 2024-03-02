namespace Day2Bonus
{
    internal class Program
    {
        static void Main(string[] args)
        {

            float budget = 183.23f;
            float bagVolume = 64.11f;
            int people = 7;
            int Npresents = 12;
            float[] presentVolume = { 4.53f, 9.11f, 4.53f, 6.00f, 1.04f, 0.87f, 2.57f, 19.45f, 65.59f, 14.14f, 16.66f, 13.53f };
            float[] presentPrice  = { 12.23f, 45.03f, 12.23f, 32.93f, 6.99f, 0.46f, 7.34f, 65.98f, 152.13f, 7.23f, 10.00f, 25.25f };

            float Result = PresentList(budget, bagVolume, people, Npresents, presentVolume, presentPrice);
            
            Console.WriteLine($"Maximum price : {Result}");


            //Console.WriteLine(BackTrack(budget, bagVolume, people, Npresents, 0, presentVolume, presentPrice)); 
        }


        public static float PresentList(float budget, float bagVolume, int people, int
            Npresents, float[] presentVolume, float[] presentPrice)
        {
            float[,] dp = new float[Npresents + 1, (int)Math.Ceiling(bagVolume) + 1];
            int[,] NumberOfPresentsTaken = new int[Npresents + 1, (int)Math.Ceiling(bagVolume) + 1];
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    if (i == 0 || j == 0) { dp[i, j] = 0; NumberOfPresentsTaken[i, j] = 0; }

                    else if (presentVolume[i - 1] <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], presentPrice[i - 1] + dp[i - 1, j - (int)Math.Ceiling(presentVolume[i - 1])]);
                        if (dp[i, j] > presentPrice[i - 1])
                            NumberOfPresentsTaken[i, j] = 1 + NumberOfPresentsTaken[i - 1, j - (int)Math.Ceiling(presentVolume[i - 1])];
                    }

                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                        NumberOfPresentsTaken[i, j] = NumberOfPresentsTaken[i - 1, j];
                    }

                }
            }
            float maxPrice = 0.0f;
            int presentNum = 0;
            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    if (dp[i, j] <= budget && NumberOfPresentsTaken[i, j] % people == 0 && NumberOfPresentsTaken[i, j] != 0)
                    {

                        maxPrice = Math.Max(maxPrice, dp[i, j]);
                        presentNum = NumberOfPresentsTaken[i, j];
                        //Console.WriteLine($"i={i} , j={j} -> maxPrice= {maxPrice} , presentNum={presentNum}");
                    }
                }
            }


            Console.WriteLine($"Number of Presents : {presentNum}");
            return maxPrice;
        }

        #region BackTrack
        //static float Mainbudget = 183.23f;
        //static float BackTrack(float budget, float bagVolume, int people, int
        //Npresents, int index, float[] presentVolume, float[] presentPrice)
        //{
        //    if (budget == 0 || bagVolume == 0 || index == Npresents)
        //    {
        //        if (index % people == 0)
        //            return Mainbudget - budget;
        //        return 0;
        //    }
        //    if (presentVolume[index]<=bagVolume && presentPrice[index]<=budget)
        //    {
        //        float withPresent = BackTrack(budget - presentPrice[index], bagVolume - presentVolume[index], people, Npresents, index + 1, presentVolume, presentPrice);
        //        float withoutPresent= BackTrack(budget, bagVolume, people, Npresents, index + 1, presentVolume, presentPrice);
        //        return Math.Max(withPresent, withoutPresent);
        //    }
        //    return BackTrack(budget, bagVolume, people, Npresents, index + 1, presentVolume, presentPrice);
        //}
        #endregion

    }
}

