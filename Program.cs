using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortByBinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new List<int>();
            var rnd = new Random();
            var toBeSortCollection2 = new BinaryHeapSort<int>();
            var timer = new Stopwatch();

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            timer.Start();

            for (int i = 0; i < 1000000; i++)
            {
                lst.Add(rnd.Next(-1000, 1000));
            }
            var toBeSortCollection = new BinaryHeapSort<int>(lst);

            var lst2 = toBeSortCollection.Sort();
            //foreach (var item in lst2)
            //{
            //    Console.Write(item + " ");
            //}
            timer.Stop();
            Console.WriteLine($"\n{timer.Elapsed}");

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            timer.Reset();
            timer.Start();

            for (int i = 0; i < 1000000; i++)
            {
                toBeSortCollection2.Add(rnd.Next(-1000, 1000));
            }

            var lst3 = toBeSortCollection2.Sort();
            //foreach (var item in lst3)
            //{
            //    Console.Write(item + " ");
            //}
            timer.Stop();
            Console.WriteLine($"\n{timer.Elapsed}");
            
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            //timer.Reset();
            //timer.Start();

            //int temp;
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    for (int j = i; j < lst.Count; j++)
            //    {
            //        if (lst[i] < lst[j])
            //        {
            //            temp = lst[i];
            //            lst[i] = lst[j];
            //            lst[j] = temp;
            //        }
            //    }
            //}
            ////foreach (var item in lst)
            ////{
            ////    Console.Write(item + " ");
            ////}
            //timer.Stop();
            //Console.WriteLine($"\n{timer.Elapsed}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.ReadLine();
        }
    }
}
