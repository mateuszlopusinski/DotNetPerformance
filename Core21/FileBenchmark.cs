using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using CoreResourceMeter;

namespace Core21
{
    [RPlotExporter, RankColumn]
    public class FileBenchmark
    {
        private static string[] Words;


        [GlobalSetup]
        public void Setup()
        {
            Words = GenearateWords();
        }

        [Benchmark]
        public void FileOperation()
        {
            ResourceMeterClass.InvokerResourceMeters();
            WriteFile();
        }

        private static void WriteFile()
        {
            Words = GenearateWords();
            var path = "D:\\PWr\\Studia\\Magisterka\\Semestr 3\\Praca magisterska";
            var fullPath = Path.Combine(path, "test.txt");
            using (StreamWriter outputFile = new StreamWriter(fullPath))
            {
                foreach (string word in Words)
                {
                    outputFile.WriteLine(word);
                }
            }
            File.Delete(fullPath);
        }

        private static string[] GenearateWords()
        {
            var stringList = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[10];
                var random = new Random();
                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                stringList.Add(finalString);
            }
            return stringList.ToArray();
        }
    }
}
