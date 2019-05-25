using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using FrameworkResourceMeter;

namespace Framework471
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Summary loop = BenchmarkRunner.Run<LoopBenchmark>();
            //Summary file = BenchmarkRunner.Run<FileBenchmark>();
            //Summary md5 = BenchmarkRunner.Run<Md5Benchmark>();
            Summary minumum = BenchmarkRunner.Run<NumbersLINQ>();
            Summary objects = BenchmarkRunner.Run<LINQObjects>();
        }
    }
}