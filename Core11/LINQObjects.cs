using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using CoreResourceMeter;

namespace Core11
{
    [RPlotExporter, RankColumn]
    //[SimpleJob(targetCount: 50)]
    public class LINQObjects
    {
        private class SampleObject
        {
            public string Text;
            public int Number;
            public bool Boolean;
        }

        private List<SampleObject> Objects;

        [GlobalSetup]
        public void Setup()
        {
            Random random = new Random();
            Objects = new List<SampleObject>();
            const int thousand100 = 1000000;
            for (int i = 0; i < thousand100; i++)
            {
                var obj = InitializeObject();
                Objects.Add(obj);
            }
            SampleObject searchObj = GetObjectToSearch();
            Objects[random.Next(thousand100)] = searchObj;
        }

        private static SampleObject GetObjectToSearch()
        {
            return new SampleObject
            {
                Number = 1234566,
                Text = "abcdf13245",
                Boolean = false
            };
        }

        private SampleObject InitializeObject()
        {
            int number = GenerateRandomNumber();
            string text = GenerateRandomString();
            bool boolean = number % 2 == 0;
            return new SampleObject
            {
                Boolean = boolean,
                Number = number,
                Text = text
            };
        }

        private int GenerateRandomNumber()
        {
            const int Billion = 10000;
            Random random = new Random();
            int number = random.Next(1, Billion);
            return number;
        }

        private string GenerateRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random = new Random();
            for (int j = 0; j < stringChars.Length; j++)
            {
                stringChars[j] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }

        [Benchmark]
        public void Search()
        {
            //ResourceMeterClass.InvokerResourceMeters();
            SearchForObject();
        }

        private IEnumerable<SampleObject> SearchForObject()
        {
            var objectToSearch = Objects.Where(o => o.Text.Equals("abcdf13245"));
            return objectToSearch;
        }
    }
}
