using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CoreResourceMeter
{
    public static class ResourceMeterClass
    {
        #region Public static methods

        public static void InvokerResourceMeters()
        {
            Task.Run(MemoryUsage);
            Task.Run(CpuUsage);
        }

        #endregion
        #region Private methods

        private static async Task<double> CpuUsage()
        {
            while (true)
            {
                DateTime startTime = DateTime.UtcNow;
                TimeSpan startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
                Thread.Sleep(1000);

                DateTime endTime = DateTime.UtcNow;
                TimeSpan endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
                double cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
                double totalMsPassed = (endTime - startTime).TotalMilliseconds;
                double cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
                Console.WriteLine("CPU: " + cpuUsageTotal * 100);
            }
        }

        private static async Task MemoryUsage()
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