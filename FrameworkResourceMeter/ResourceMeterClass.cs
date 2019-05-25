using System;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkResourceMeter
{
    public static class ResourceMeterClass
    {
        #region Public static methods

        public static void InvokerResourceMeters()
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

            Thread.Sleep(5000);

            dynamic result = new ExpandoObject();

            // If system has multiple cores, that should be taken into account
            result.CPU = Math.Round(theCPUCounter.NextValue() / Environment.ProcessorCount, 2);
            Console.WriteLine("CPU: " + result.CPU);
            theCPUCounter.Close();
            theCPUCounter.Dispose();
        }

        private static async Task MemoryUsage()
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

        private static async Task CpuUsage2()
        {
            while (true)
            {
                DateTime startTime = DateTime.UtcNow;
                TimeSpan startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
                Thread.Sleep(5000);

                DateTime endTime = DateTime.UtcNow;
                TimeSpan endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
                double cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
                double totalMsPassed = (endTime - startTime).TotalMilliseconds;
                double cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
                Console.WriteLine("CPU: " + cpuUsageTotal * 100);
            }
        }
        private static async Task MemoryUsage2()
        {
            while (true)
            {
                DateTime startTime = DateTime.UtcNow;
                long startCpuUsage = Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024;
                Thread.Sleep(5000);

                DateTime endTime = DateTime.UtcNow;
                Process process = Process.GetCurrentProcess();
                long endCpuUsage = Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024;
                Console.WriteLine("Memory: " + startCpuUsage);
            }
        }

        #endregion
    }
}