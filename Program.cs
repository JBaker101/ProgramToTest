using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    public static void Main(string[] args)
    {
        bool programEnd = false;
        
        while (programEnd == false)
        {
            List<int> number = new List<int>();

            Console.WriteLine("Enter the first number in the list:");
            number.Add(Convert.ToInt32(Console.ReadLine()));

            bool end = false;
            while (end == false)
            {
                Console.WriteLine("Current List: " + String.Join(", ", number));

                Console.WriteLine("Enter the next number in the list or enter \"stop\" to calculate result: ");
                string entry = Console.ReadLine();
                if (entry != "stop")
                {
                    number.Add(Convert.ToInt32(entry));
                }
                else
                {
                    int max = Max(number);

                    int min = Min(number);

                    double average = Average(number);

                    int mode = Mode(number);

                    Console.WriteLine(String.Join(", ", number));
                    Console.WriteLine("Max: " + max);
                    Console.WriteLine("Min: " + min);
                    Console.WriteLine("Average: " + average);
                    Console.WriteLine("Mode: " + mode);

                    end = true;
                }
            }

            Console.WriteLine("Do you want to calculate another summary? (y for yes, n for no)");
            if (Console.ReadLine() == "n")
            {
                programEnd = true;
            }
        }


        //Functions for calculating summaries
        int Max(List<int> list)
        {
            int max = list[0];

            foreach (int x in list)
            {
                if (x > max)
                {
                    max = x;
                }
            }
            return max;
        }

        int Min(List<int> list)
        {
            int min = list[0];

            foreach (int x in list)
            {
                if (x < min)
                {
                    min = x;
                }
            }
            return min;
        }

        double Average(List<int> list)
        {
            double listTotal = 0;

            foreach (int x in list)
            {
                listTotal += x;
            }

            double average = listTotal / list.Count();
            return average;
        }

        int Mode(IEnumerable<int> collection)
        {
            return
                collection
                    .GroupBy(value => value)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .First();
        }
    }
}
