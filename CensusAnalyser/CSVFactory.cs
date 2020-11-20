using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class CSVFactory
    {

        public  List<USCensusAnalyserDAO> USCensusAnalyzerList = new List<USCensusAnalyserDAO>();
        public Dictionary<string, List<USCensusAnalyserDAO>> map_USCensusAnalyzer = new Dictionary<string, List<USCensusAnalyserDAO>>();
        public List<IndiaStateCodeDAO> IndiaStateCodeCsvList = new List<IndiaStateCodeDAO>();
        public Dictionary<string, List<IndiaStateCodeDAO>> map_IndiaStateCodeCsv = new Dictionary<string, List<IndiaStateCodeDAO>>();
        public List<StateCensusDataDAO> StateCensusAnalyserlist = new List<StateCensusDataDAO>();
        public Dictionary<string, List<StateCensusDataDAO>> mapStateCensusAnalyser = new Dictionary<string, List<StateCensusDataDAO>>();

        public void CSVBuilder(string path, string name)
        {
            var file = new System.IO.StreamReader(path);
            switch (name) {
                case "StateCensusAnalyser":
                    StateCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture).GetRecords<StateCensusDataDAO>().ToList();
                    mapStateCensusAnalyser.Add("StateCensusAnalyser", StateCensusAnalyserlist);
                    break;

                case "USCensusAnalyser":
                    USCensusAnalyzerList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                   .GetRecords<USCensusAnalyserDAO>().ToList();
                    map_USCensusAnalyzer.Add("USCensusAnalyser", USCensusAnalyzerList);
                    break;

                case "IndiaStateCodeCensusAnalyser":
                    IndiaStateCodeCsvList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<IndiaStateCodeDAO>().ToList();
                    map_IndiaStateCodeCsv.Add("IndiaStateCodeCensusAnalyser", IndiaStateCodeCsvList);
                    break;
            }

        }

    }
}
