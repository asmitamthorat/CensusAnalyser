using System.Collections.Generic;

namespace CensusAnalyser
{
    public class IndiaStateCodeCensusAnalyser:Adapter
    {
        public List<IndiaStateCodeDAO> loadingStateCensusCSV(string path)
        {
            CSVFactory csvFactory = new CSVFactory();
            LoadCSVFile(path);
            csvFactory.CSVBuilder(path, "IndiaStateCodeCensusAnalyser");
            return csvFactory.map_IndiaStateCodeCsv["IndiaStateCodeCensusAnalyser"];
        }

        public List<IndiaStateCodeDAO> sortingByStateCode(string path)
        {
            List<IndiaStateCodeDAO> list = loadingStateCensusCSV(path);
            list.Sort(delegate (IndiaStateCodeDAO object1, IndiaStateCodeDAO object2) { return object1.StateCode.CompareTo(object2.StateCode); });
            return list;
        }
    }
}
