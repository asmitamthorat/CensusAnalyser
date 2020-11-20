using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class USCensusAnalyser:Adapter
    {
       
        public List<USCensusAnalyserDAO> loadStateCensusData(string path)
        {
            CSVFactory csvFactory = new CSVFactory();
            LoadCSVFile(path);
            csvFactory.CSVBuilder(path, "USCensusAnalyser");
            return csvFactory.map_USCensusAnalyzer["USCensusAnalyser"];
        }


        public List<USCensusAnalyserDAO> sortByPopulation(string path) {
            List<USCensusAnalyserDAO> list = loadStateCensusData(path);
            list.Sort(delegate (USCensusAnalyserDAO object1, USCensusAnalyserDAO object2) { return object1.Population.CompareTo(object2.Population); });
            return list;
        }



        public List<USCensusAnalyserDAO> sortByPopulationDensity(string path)
        {
            List<USCensusAnalyserDAO> list = loadStateCensusData(path);
            list.Sort(delegate (USCensusAnalyserDAO object1, USCensusAnalyserDAO object2) { return object1.PopulationDensity.CompareTo(object2.PopulationDensity); }); 
            return list;
        }

        public List<USCensusAnalyserDAO> sortByArea(string path)
        {
            List<USCensusAnalyserDAO> list = loadStateCensusData(path);
            list.Sort(delegate (USCensusAnalyserDAO object1, USCensusAnalyserDAO object2) { return object1.LandArea.CompareTo(object2.LandArea); });
            return list;
        }
    }
}
