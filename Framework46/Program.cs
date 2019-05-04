using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using FrameworkResourceMeter;

namespace Framework46
{
    public class Program
    {
        #region Nested classes

        public class Benchmark
        {
            #region Private fields

            [Params(1000, 10000)]
            public int N;

            #endregion
            #region Public static methods

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
        #region Public static methods

        public static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<Benchmark>();
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
}