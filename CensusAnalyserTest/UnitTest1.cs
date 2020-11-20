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
            List<StateCensusDataDAO> list = stateCensusAnalyser.loadStateCensusData(IndiaCensusDataFilePath1);
            Assert.AreEqual(29, list.Count);
        }

        [Test]
        public void givenWrongIndiaCensusCode_InputFile_ShouldThrowWxception() {
            try {
                StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
                List<StateCensusDataDAO> list = stateCensusAnalyser.loadStateCensusData(IndiaCensusDataWithWrongFile);
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
            List<IndiaStateCodeDAO> list = indiaStateCodeCensusAnalyser.loadingStateCensusCSV(IndiaStateCodeCensusFilePath);
            Assert.AreEqual(37, list.Count);
        }

        [Test]
        public void givenWrongIndiaStateCode_InputFile_ShouldThrowWxception()
        {
            try
            {
                StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
                List<StateCensusDataDAO> list = stateCensusAnalyser.loadStateCensusData(IndiaCensusAnalyserWithWrong_File);
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
            List<StateCensusDataDAO> list= stateCensusAnalyser.sortByName(IndiaCensusDataFilePath1);
            Assert.AreEqual("Andhra Pradesh", list[0].State);

        }

        [Test]
        public void givenStateCodeCsvFile_whenSorted_ShouldRetrunSortedList()
        {
            IndiaStateCodeCensusAnalyser indiaStateCodeCensusAnalyser = new IndiaStateCodeCensusAnalyser();
            List<IndiaStateCodeDAO> list = indiaStateCodeCensusAnalyser.sortingByStateCode(IndiaStateCodeCensusFilePath);
            Assert.AreEqual("AD", list[0].StateCode);

        }


        [Test]
        public void givenStateAnalyserCSVFile_whenSortedwithPopulation_ShouldRetrunSortedList() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<StateCensusDataDAO> list=stateCensusAnalyser.sortByPopulation(IndiaCensusDataFilePath1);
            Assert.AreEqual("Uttar Pradesh", list[list.Count-1].State);
        }

        [Test]
        public void givenStateAnalyserCSVFile_whenSortedWithPopulationDensity_ShouldReturnSortedList() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<StateCensusDataDAO> list = stateCensusAnalyser.sortByPopulationDensity(IndiaCensusDataFilePath1);
            Assert.AreEqual("West Bengal", list[0].State);

        }

        [Test]
        public void givenIndiaStateCodeCSVFile_WhenSortedWithsStateArea_ShoudlReturnSortedList() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<StateCensusDataDAO> list = stateCensusAnalyser.sortByArea(IndiaCensusDataFilePath1);
            Assert.AreEqual("Tripura", list[0].State);
        }

        [Test]
        public void givenUSCensusData_ifHasCorrectNumberOfRecord_ShouldReturnTrue()
        {
            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            List<USCensusAnalyserDAO> list=uSCensusAnalyser.loadStateCensusData(USCensusData);
            Assert.AreEqual(51,list.Count);


        }

        [Test]

        public void givenUSCensusCSV_WhenSortedBasedONPopulation_ShouldRetrunSortedList() {
            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            List<USCensusAnalyserDAO> list = uSCensusAnalyser.sortByPopulation(USCensusData);
            Assert.AreEqual("California", list[list.Count - 1].State);
        }

        [Test]

        public void givenUSCensusCSV_WhenSortedBasedONPopulationDensity_ShouldRetrunSortedList()
        {
            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            List<USCensusAnalyserDAO> list = uSCensusAnalyser.sortByPopulationDensity(USCensusData);
            Assert.AreEqual("District of Columbia", list[list.Count - 1].State);
        }

        [Test]
        public void givenUSCensusCSV_WhenSortedBasedOnArea_ShouldRetrunSortedList() {

            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            List<USCensusAnalyserDAO> list = uSCensusAnalyser.sortByArea(USCensusData);
            Assert.AreEqual("Alaska", list[list.Count - 1].State);

        }

        
    }
}