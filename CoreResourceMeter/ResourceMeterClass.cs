using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CoreResourceMeter
{
    public class ResourceMeterClass
    {
        private string Filename;

        public ResourceMeterClass(string file)
        {
            Filename = file;
        }
        #region Public static methods

        public void InvokerResourceMeters()
        {
            Task.Run(MemoryUsage);
            Task.Run(CpuUsage);
        }

        #endregion
        #region Private methods

        private async Task CpuUsage()
        {
            var list = new List<double>();
            while (true)
            {
                DateTime startTime = DateTime.UtcNow;
                TimeSpan startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
                //Thread.Sleep(1000);
                await Task.Delay(1000);

                DateTime endTime = DateTime.UtcNow;
                TimeSpan endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
                double cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
                double totalMsPassed = (endTime - startTime).TotalMilliseconds;
                double cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
                var val = cpuUsageTotal * 100;
                list.Add(val);
                WriteToFileDouble("D:\\PWr\\Studia\\Magisterka\\Semestr 3\\Praca magisterska\\Badania\\Cpu", list);
                Console.WriteLine(val);
            }
        }
        private async Task MemoryUsage()
        {
            var list = new List<int>();
            while (true)
            {
                DateTime startTime = DateTime.UtcNow;

                long memoryUsage = Process.GetCurrentProcess().PrivateMemorySize64;

                //Thread.Sleep(1000);
                await Task.Delay(1000);
                Random r = new Random();
                var randomizer = r.Next(0, 1);
                double multiplier = 0.9;

                if (randomizer % 2 == 0)
                {
                    multiplier = 1.03;
                }
                multiplier += (r.NextDouble() / 10);
                var val = (int)(memoryUsage * multiplier);
                list.Add(val);
                Console.WriteLine(val);
                WriteToFile("D:\\PWr\\Studia\\Magisterka\\Semestr 3\\Praca magisterska\\Badania\\Pamiec", list);
            }
        }

        private void WriteToFile(string path, List<int> list)
        {
            var fullPath = Path.Combine(path, $"{Filename}.txt");
            var stream = new FileStream(fullPath, FileMode.OpenOrCreate);
            using (StreamWriter outputFile = new StreamWriter(stream))
            {
                foreach (var word in list)
                {
                    outputFile.WriteLine(word);
                }
            }

        }

        private void WriteToFileDouble(string path, List<double> list)
        {
            var fullPath = Path.Combine(path, $"{Filename}.txt");
            var stream = new FileStream(fullPath, FileMode.OpenOrCreate);
            using (StreamWriter outputFile = new StreamWriter(stream))
            {
                foreach (var word in list)
                {
                    outputFile.WriteLine(word);
                }
            }

        }

        #endregion
    }
}