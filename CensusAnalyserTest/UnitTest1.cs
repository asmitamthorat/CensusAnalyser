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
            List<StateCensusDataDTO> list = stateCensusAnalyser.loadStateCensusData(IndiaCensusDataFilePath1);
            Assert.AreEqual(29, list.Count);
        }

        [Test]
        public void givenWrongIndiaCensusCode_InputFile_ShouldThrowWxception() {
            try {
                StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
                List<StateCensusDataDTO> list = stateCensusAnalyser.loadStateCensusData(IndiaCensusDataWithWrongFile);
            }
            catch (CensusAnalyserException e) {

                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE, e.type);

            }
        }

        [Test]
        public void givenStateCensusData_ifhasInvalidDelimiter_ShouldThrowException()
        {
            try {
                Delimiter delimiter = new Delimiter();
                delimiter.loadData(IndiaCensusDataWithDelimiter);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DILIMINATOR, e.type);
            }

        }

        [Test]
        public void givenStateCensusAnalyser_WithoutHeader_ShouldThrowException() {
            try
            {
                CSVHeaderCheck csvHeaderCheck = new CSVHeaderCheck();
                csvHeaderCheck.loadFile(IndiaStateCensusWithoutHeader);
            }
            catch (CensusAnalyserException e) {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVAILD_HEADER, e.type);
            }
        }

        [Test]
        public void givenIndiaStateCodecsvFile_ifHasCorrectNumberOFRecord_ShouldReturnTrue() {
            IndiaStateCodeCensusAnalyser indiaStateCodeCensusAnalyser = new IndiaStateCodeCensusAnalyser();
            List<IndiaStateCodeDTO> list = indiaStateCodeCensusAnalyser.loadingStateCensusCSV(IndiaStateCodeCensusFilePath);
            Assert.AreEqual(37, list.Count);
        }

        [Test]
        public void givenWrongIndiaStateCode_InputFile_ShouldThrowWxception()
        {
            try
            {
                StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
                List<StateCensusDataDTO> list = stateCensusAnalyser.loadStateCensusData(IndiaCensusAnalyserWithWrong_File);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE, e.type);
            }
        }

        [Test]
        public void givenIndiaStateCodeCSVFile_withoutHeader_ShouldThrowWxception() {

            try
            {
                CSVHeaderCheck csvHeaderCheck = new CSVHeaderCheck();
                csvHeaderCheck.loadFile(IndiaStateCodeWithDelimiter);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVAILD_HEADER, e.type);
            }
        }


        [Test]
        public void givenIndiaSateCodeCsvFile_withDilimiterIssue_ShouldException() {
            try
            {
                Delimiter delimiter = new Delimiter();
                delimiter.loadData(IndiaStateCodeWithDelimiter);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DILIMINATOR, e.type);
            }

        }


        [Test]
        public void givenStateCensusCsv_sortOntheBasisOfStateName_ShouldReturnSortedList(){
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<StateCensusDataDTO> list= stateCensusAnalyser.sortByName(IndiaCensusDataFilePath1);
            Assert.AreEqual("Andhra Pradesh", list[0].State);

        }
    }
}