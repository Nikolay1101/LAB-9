using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> sums = new Dictionary<int, int>();

        for (int N = 1; N <= 50000; N++)
        {
            int count = 0;
            for (int a = 1; a <= N; a++)
            {
                for (int b = a; b <= N; b++)
                {
                    for (int c = b; c <= N; c++)
                    {
                        if (a * a * a + b * b * b == N && b * b * b + c * c * c == N && a * a * a + c * c * c == N)
                        {
                            count++;
                        }
                    }
                }
            }

            if (count > 2)
            {
                sums[N] = count;
            }
        }

        Console.WriteLine("Числа, для которых существует более двух комбинаций суммы кубов:");

        foreach (var pair in sums)
        {
            Console.WriteLine(pair.Key);
        }
    }
}