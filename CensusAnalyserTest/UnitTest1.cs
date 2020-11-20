using CensusAnalyser;
using Newtonsoft.Json;
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
            String StateCensusData= stateCensusAnalyser.sortByName(IndiaCensusDataFilePath1);
            StateCensusDataDTO[] census = JsonConvert.DeserializeObject<StateCensusDataDTO[]>(StateCensusData);
            Assert.AreEqual("Andhra Pradesh", census[0].State);

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
            string StateCensusData = stateCensusAnalyser.sortByPopulation(IndiaCensusDataFilePath1);
            StateCensusDataDTO[] census = JsonConvert.DeserializeObject<StateCensusDataDTO[]>(StateCensusData);
            Assert.AreEqual("Uttar Pradesh", census[census.Length-1].State);
        }

        [Test]
        public void givenStateAnalyserCSVFile_whenSortedWithPopulationDensity_ShouldReturnSortedList() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string StateCensusData = stateCensusAnalyser.sortByPopulationDensity(IndiaCensusDataFilePath1);
            StateCensusDataDTO[] census = JsonConvert.DeserializeObject<StateCensusDataDTO[]>(StateCensusData);
            Assert.AreEqual("West Bengal", census[0].State);

        }

        [Test]
        public void givenIndiaStateCodeCSVFile_WhenSortedWithsStateArea_ShoudlReturnSortedList() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string StateCensusData = stateCensusAnalyser.sortByArea(IndiaCensusDataFilePath1);
            StateCensusDataDTO[] census = JsonConvert.DeserializeObject<StateCensusDataDTO[]>(StateCensusData);
            Assert.AreEqual("Tripura", census[0].State);
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
            string usCensusData = uSCensusAnalyser.sortByPopulation(USCensusData);
            USCensusAnalyserDTO[] census = JsonConvert.DeserializeObject<USCensusAnalyserDTO[]>(usCensusData);
            Assert.AreEqual("California", census[census.Length - 1].State);
        }

        [Test]

        public void givenUSCensusCSV_WhenSortedBasedONPopulationDensity_ShouldRetrunSortedList()
        {
            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            string usCensusData = uSCensusAnalyser.sortByPopulationDensity(USCensusData);
            USCensusAnalyserDTO[] census = JsonConvert.DeserializeObject<USCensusAnalyserDTO[]>(usCensusData);
            Assert.AreEqual("District of Columbia", census[census.Length - 1].State);
        }

        [Test]
        public void givenUSCensusCSV_WhenSortedBasedOnArea_ShouldRetrunSortedList() {

            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            string usCensusData  = uSCensusAnalyser.sortByArea(USCensusData);
            USCensusAnalyserDTO[] census = JsonConvert.DeserializeObject<USCensusAnalyserDTO[]>(usCensusData);
            Assert.AreEqual("Alaska", census[census.Length - 1].State);

        }

        
    }
}