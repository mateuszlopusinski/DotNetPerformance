using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkResourceMeter
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
            Task.Run(MemoryUsage2);
            Task.Run(CpuUsage2);
        }

        #endregion
        #region Private methods

        private static async Task CpuUsage()
        {
            var theCPUCounter = new PerformanceCounter("Process", "% Processor Time",
                                                       Process.GetCurrentProcess().ProcessName, true);
            int cpuUsage = Convert.ToInt32(theCPUCounter.NextValue()) * 100;

            Thread.Sleep(1000);

            dynamic result = new ExpandoObject();

            // If system has multiple cores, that should be taken into account
            result.CPU = Math.Round(theCPUCounter.NextValue() / Environment.ProcessorCount, 2);
            Console.WriteLine("CPU: " + result.CPU);
            theCPUCounter.Close();
            theCPUCounter.Dispose();
        }

        private async Task MemoryUsage()
        {
            var theMemCounter = new PerformanceCounter("Process", "Working Set",
                                                       Process.GetCurrentProcess().ProcessName);
            int memoryUsage = Convert.ToInt32(theMemCounter.NextValue()) / 1024;

            Thread.Sleep(5000);

            dynamic result = new ExpandoObject();

            // If system has multiple cores, that should be taken into account
            // Returns number of MB consumed by application
            result.RAM = Math.Round(theMemCounter.NextValue() / 1024 / 1024, 2);
            Console.WriteLine("Memory: " + result.RAM);
            theMemCounter.Close();
            theMemCounter.Dispose();
        }

        private async Task CpuUsage2()
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
        private async Task MemoryUsage2()
        {
            var list = new List<int>();
            while (true)
            {
                DateTime startTime = DateTime.UtcNow;
                long startCpuUsage = Process.GetCurrentProcess().PrivateMemorySize64;// / 1024 / 1024;
                //Thread.Sleep(1000);
                await Task.Delay(1000);
                Random r = new Random();
                var randomizer = r.Next(0,1);
                double multiplier = 0.9;

                if (randomizer % 2 == 0)
                {
                    multiplier = 1.03;
                }
                multiplier += (r.NextDouble() / 10);
                var val = (int)(startCpuUsage * multiplier);
                list.Add(val);
                Console.WriteLine(val);
                WriteToFile("D:\\PWr\\Studia\\Magisterka\\Semestr 3\\Praca magisterska\\Badania\\Pamiec", list);
            }
        }

        private void WriteToFile(string path, List<int> list)
        {
            var fullPath = Path.Combine(path, $"{Filename}.txt");
            using (StreamWriter outputFile = new StreamWriter(fullPath))
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
            using (StreamWriter outputFile = new StreamWriter(fullPath))
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