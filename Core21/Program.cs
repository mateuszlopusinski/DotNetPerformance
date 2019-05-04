using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;

namespace Core21
{
    //[ClrJob(true), CoreJob]
    //[RPlotExporter, RankColumn]
    public class Md5VsSha256
    {
        private SHA256 sha256 = SHA256.Create();
        private MD5 md5 = MD5.Create();
        private byte[] data;

        [Params(1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        //[Benchmark]
        //public byte[] Sha256() => sha256.ComputeHash(data);

        //[Benchmark]
        //public byte[] Md5() => md5.ComputeHash(data);
        

        [Benchmark]
        public static int Calculate()
        {
            int res = 123;
            for (int i = 0; i < 10000; i++)
            {
                if (i % 2 == 0)
                {
                    res = res * res;
                }
                else
                {
                    res = res + 1;
                }
            }
            return res;
        }
    }


    internal class Program
    {
        #region Private methods

        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
            Console.ReadLine();
        }

        #endregion
    }
}