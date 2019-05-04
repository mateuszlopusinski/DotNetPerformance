using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CsProj;

namespace Core11
{
    public class Program
    {


        public class MultipleRuntimes : ManualConfig
        {
            public MultipleRuntimes()
            {
                Add(Job.Default.With(CsProjCoreToolchain.NetCoreApp11)); // .NET Core 2.1

                Add(Job.Default.With(CsProjClassicNetToolchain.Net46)); // NET 4.6.2
            }
        }

        [Config(typeof(MultipleRuntimes))]
        [ClrJob, CoreJob]
        public class Md5VsSha256
        {

            [Params(1000, 10000)]
            public int N;

            [GlobalSetup]
            public void Setup()
            {
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
        #region Private methods

        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }

        #endregion
    }
}