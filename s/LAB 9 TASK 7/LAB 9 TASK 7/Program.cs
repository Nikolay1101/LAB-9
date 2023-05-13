using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
        List<int> list2 = new List<int> { 5, 4, 3, 2, 1 };

        bool isReversed = IsReversed(list1, list2);

        if (isReversed)
        {
            Console.WriteLine("Один список является реверсией другого.");
        }
        else
        {
            Console.WriteLine("Один список не является реверсией другого.");
        }
    }

    static bool IsReversed(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[list2.Count - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}
