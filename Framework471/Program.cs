using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Framework471
{
    public class Program
    {
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