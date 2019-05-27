using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CoreResourceMeter;

namespace Core21
{

    internal class Program
    {
        #region Public static methods

        public static void Main(string[] args)
        {
            Summary loop = BenchmarkRunner.Run<LoopBenchmark>();
            //Summary file = BenchmarkRunner.Run<FileBenchmark>();
            //Summary md5 = BenchmarkRunner.Run<Md5Benchmark>();
            //Summary minumum = BenchmarkRunner.Run<NumbersLINQ>();
            //Summary objects = BenchmarkRunner.Run<LINQObjects>();
        }

        #endregion
    }
}