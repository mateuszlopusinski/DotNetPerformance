using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using CoreResourceMeter;

namespace Core21
{
    [RPlotExporter, RankColumn]
    public class LoopBenchmark
    {

        [GlobalSetup]
        public void Setup()
        {
            ResourceMeterClass rmc = new ResourceMeterClass($"Core21.LoopBenchmark");
            rmc.InvokerResourceMeters();
        }

        [Benchmark]
        public void Loop()
        {
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
