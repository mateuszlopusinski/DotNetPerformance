using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using CoreResourceMeter;

namespace Core21
{
    [RPlotExporter, RankColumn]
    public class NumbersLINQ
    {
        private static List<int> Numbers;

        [GlobalSetup]
        public void Setup()
        {
            Random random = new Random();
            Numbers = new List<int>();
            const int Billion = 1000000000;
            const int Million = 1000000;
            for (int i = 0; i < Million; i++)
            {
                int number = random.Next(1, Billion);
                Numbers.Add(number);
            }
        }

        [Benchmark]
        public static void Loop()
        {
            ResourceMeterClass.InvokerResourceMeters();
            FindMinimum();
        }

        private static int FindMinimum()
        {
            int minimum = Numbers.Min();
            return minimum;
        }
    }
}
