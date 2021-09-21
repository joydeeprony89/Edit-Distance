using System;

namespace Edit_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "intention", word2 = "execution";
            Console.WriteLine(MinDistance(word1, word2));
        }

        static int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;

            if (m * n == 0)
                return m + n;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j])) + 1;
                    }
                }
            }

            return dp[m, n];
        }
    }
}
