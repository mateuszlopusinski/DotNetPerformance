using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using FrameworkResourceMeter;

namespace Framework471
{
    [RPlotExporter, RankColumn]
    public class LoopBenchmark
    {

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public void Loop()
        {
            ResourceMeterClass.InvokerResourceMeters();
            LoopMethod();
        }

        private void LoopMethod()
        {
            var res = 123;
            for (var i = 0; i < 1000000; i++)
                if (i % 2 == 0)
                    res = res * res;
                else
                    res = res + 1;
        }
    }
}
