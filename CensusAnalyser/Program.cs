using System;
using System.Collections.Generic;

namespace CensusAnalyser
{
    class Program
    {

       static string path = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\IndiaStateCensusData.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StateCensusAnalyser a = new StateCensusAnalyser();

            a.loadStateCensusData(path);
        }
    }
}
