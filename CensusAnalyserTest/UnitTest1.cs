using CensusAnalyser;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class Tests
    {
        string IndiaStateCodeCensusFilePath = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\IndiaStateCode.csv";
        string IndiaCensusDataWithDelimiter = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\DelimiterIndiaStateCensusData.csv";
        string IndiaCensusDataWithWrongFile = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\IndiaStateCode.txt";
        string IndiaStateCensusWithoutHeader = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\WrongHeaderIndiaStateCensusData.csv";
        string IndiaCensusAnalyserWithWrong_File = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\IndiaCensusAnalyser.txt";
        string IndiaStateCodeWithDelimiter = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\IndiaStateCode_withDelimiterIssue.csv";
        string USCensusData = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\USCensusData.csv";
        string IndiaCensusDataFilePath1 = @"C:\\Users\\com\\source\\repos\\CensusAnalyserProject\\CensusAnalyserTest\\utilities\\IndiaStateCensusData.csv";

        [Test]
        public void voidgivenStateCensusData_ifHasCorrectNumberOfRecord_ShouldReturnTrue()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
           List<StateCensusDataDTO> list= stateCensusAnalyser.loadStateCensusData(IndiaCensusDataFilePath1);
            Assert.AreEqual(29, list.Count);
        }
    }
}