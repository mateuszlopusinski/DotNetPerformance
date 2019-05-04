using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CoreResourceMeter;

namespace Core21
{
    //[ClrJob(true), CoreJob]
    //[RPlotExporter, RankColumn]
    public class Benchmark
    {
        #region Private fields

        [Params(1000, 10000)]
        public int N;

        #endregion
        #region Public static methods

        //[Benchmark]
        //public byte[] Sha256() => sha256.ComputeHash(data);

        //[Benchmark]
        //public byte[] Md5() => md5.ComputeHash(data);

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

        #endregion
    }

    internal class Program
    {
        #region Public static methods

        public static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<Benchmark>();
        }

        #endregion
    }
}