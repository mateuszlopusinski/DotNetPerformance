using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using CoreResourceMeter;

namespace Core11
{
    [RPlotExporter, RankColumn]
    public class Md5Benchmark
    {

        private static MD5 md5;

        private static byte[] data;


        private static byte[] CreateByteArray()
        {
            var data = new byte[10000];
            new Random(42).NextBytes(data);
            return data;
        }

        [GlobalSetup]
        public void Setup()
        {
            data = CreateByteArray();
            md5 = MD5.Create();
        }

        [Benchmark]
        public byte[] Md5()
        {
            ResourceMeterClass.InvokerResourceMeters();
            return CalculateMd5Hash();
        }

        private static byte[] CalculateMd5Hash()
        {
            return md5.ComputeHash(data);
        }
    }
}
