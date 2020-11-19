using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class IndiaStateCodeCensusAnalyser
    {
        static private List<IndiaStateCodeDAO> IndiaStateCodeCsvList = new List<IndiaStateCodeDAO>();
        public List<IndiaStateCodeDAO> loadingStateCensusCSV(string path)
        {

            using (var file = new System.IO.StreamReader(path))
            {
                IndiaStateCodeCsvList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<IndiaStateCodeDAO>().ToList();
            }
            return IndiaStateCodeCsvList;
        }

        public List<IndiaStateCodeDAO> sortingByStateCode(string path)
        {
            List<IndiaStateCodeDAO> list = loadingStateCensusCSV(path);
            list.Sort(delegate (IndiaStateCodeDAO object1, IndiaStateCodeDAO object2) { return object1.StateCode.CompareTo(object2.StateCode); });
            return list;
        }
    }
}
