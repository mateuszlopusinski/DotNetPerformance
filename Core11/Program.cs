using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CoreResourceMeter;

namespace Core11
{
    public class Program
    {
        #region Nested classes

        //public class MultipleRuntimes : ManualConfig
        //{
        //    public MultipleRuntimes()
        //    {
        //        Add(Job.Default.With(CsProjCoreToolchain.NetCoreApp11)); // .NET Core 2.1

        //        Add(Job.Default.With(CsProjClassicNetToolchain.Net46)); // NET 4.6.2
        //    }
        //}

        //[Config(typeof(MultipleRuntimes))]
        //[ClrJob]
        //[CoreJob]
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