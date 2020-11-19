using System;
using System.Collections.Generic;

namespace CensusAnalyser
{
    class Program
    {
     string IndiaCensusDataFilePath1 = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\IndiaStateCensusData.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
          //  List<StateCensusDataDTO> list = stateCensusAnalyser.sortByName(IndiaCensusDataFilePath1);
        }
    }
}
