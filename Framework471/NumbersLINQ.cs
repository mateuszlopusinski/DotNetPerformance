﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using FrameworkResourceMeter;

namespace Framework471
{
    [RPlotExporter, RankColumn]
    public class NumbersLINQ
    {
        private List<int> Numbers;

        [GlobalSetup]
        public void Setup()
        {
            ResourceMeterClass rmc = new ResourceMeterClass($"Net471.NumbersLINQ");
            rmc.InvokerResourceMeters();
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
        public void MinimumFinder()
        {
            FindMinimum();
        }

        private int FindMinimum()
        {
            int minimum = Numbers.Min();
            return minimum;
        }
    }
}
