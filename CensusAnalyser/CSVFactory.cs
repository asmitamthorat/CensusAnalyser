using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class CSVFactory
    {
        public List<USCensusAnalyserDAO> USCensusAnalyserlist = new List<USCensusAnalyserDAO>();
        public Dictionary<String, List<USCensusAnalyserDAO>> mapUSCensusAnalyser = new Dictionary<string, List<USCensusAnalyserDAO>>();
        public List<IndiaStateCodeDAO> IndiaStateCodelist = new List<IndiaStateCodeDAO>();
        public Dictionary<String, List<IndiaStateCodeDAO>> mapIndiaStateCodelist = new Dictionary<string, List<IndiaStateCodeDAO>>();
        public List<StateCensusDataDAO> StateCensusAnalyserlist = new List<StateCensusDataDAO>();
        public Dictionary<String, List<StateCensusDataDAO>> mapStateCensusAnalyser = new Dictionary<string, List<StateCensusDataDAO>>();

        public void CSVBuilder(string path, string name)
        {
            var file = new System.IO.StreamReader(path);
            switch (name) {
                case "StateCensusAnalyser":
                    StateCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture).GetRecords<StateCensusDataDAO>().ToList();
                    mapStateCensusAnalyser.Add("StateCensusAnalyser", StateCensusAnalyserlist);
                    break;
                

            }

        }

    }
}
