
using Newtonsoft.Json;
using System.Collections.Generic;


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


        public string sortByPopulation(string path) {
            List<USCensusAnalyserDAO> list = loadStateCensusData(path);
            list.Sort(delegate (USCensusAnalyserDAO object1, USCensusAnalyserDAO object2) { return object1.Population.CompareTo(object2.Population); });
            string json = JsonConvert.SerializeObject(list);
            return json;
        }



        public string sortByPopulationDensity(string path)
        {
            List<USCensusAnalyserDAO> list = loadStateCensusData(path);
            list.Sort(delegate (USCensusAnalyserDAO object1, USCensusAnalyserDAO object2) { return object1.PopulationDensity.CompareTo(object2.PopulationDensity); });
            string json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string sortByArea(string path)
        {
            List<USCensusAnalyserDAO> list = loadStateCensusData(path);
            list.Sort(delegate (USCensusAnalyserDAO object1, USCensusAnalyserDAO object2) { return object1.LandArea.CompareTo(object2.LandArea); });
            string json = JsonConvert.SerializeObject(list);
            return json;
        }
    }
}
