﻿using System;
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

        private MD5 md5;

        private byte[] data;


        private static byte[] CreateByteArray()
        {
            var data = new byte[10000];
            new Random(42).NextBytes(data);
            return data;
        }

        [GlobalSetup]
        public void Setup()
        {
            ResourceMeterClass rmc = new ResourceMeterClass($"Core11.Md5Benchmark");
            rmc.InvokerResourceMeters();

            data = CreateByteArray();
            md5 = MD5.Create();
        }

        [Benchmark]
        public byte[] Md5()
        {
            return CalculateMd5Hash();
        }

        private byte[] CalculateMd5Hash()
        {
            return md5.ComputeHash(data);
        }
    }
}
