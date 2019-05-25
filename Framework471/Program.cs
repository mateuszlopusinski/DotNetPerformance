using System;
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
        #region Nested classes
        [RPlotExporter, RankColumn]
        public class Benchmark
        {
            #region Private fields


            #endregion
            #region Public static methods

            [Benchmark]
            public byte[] Md5()
            {
                return CalculateMd5Hash();
            }


            [Benchmark]
            public static void Loop()
            {
                ResourceMeterClass.InvokerResourceMeters();
                LoopMethod();
            }

            #endregion
            #region Public methods

            [GlobalSetup]
            public void Setup()
            {
            }

            #endregion
        }

        #endregion
        #region Private methods

        private static void LoopMethod()
        {
            var res = 123;
            for (var i = 0; i < 1000000; i++)
                if (i % 2 == 0)
                    res = res * res;
                else
                    res = res + 1;
        }

        private static byte[] CalculateMd5Hash()
        {
            MD5 md5 = MD5.Create();
            var data = new byte[1000];
            new Random(42).NextBytes(data);
            return md5.ComputeHash(data);
        }

        private static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<Benchmark>();
        }

        #endregion
    }
}