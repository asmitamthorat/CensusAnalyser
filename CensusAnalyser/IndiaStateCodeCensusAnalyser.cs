using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class IndiaStateCodeCensusAnalyser
    {
        static private List<IndiaStateCodeDTO> IndiaStateCodeCsvList = new List<IndiaStateCodeDTO>();
        public List<IndiaStateCodeDTO> loadingStateCensusCSV(string path)
        {

            using (var file = new System.IO.StreamReader(path))
            {
                IndiaStateCodeCsvList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<IndiaStateCodeDTO>().ToList();
            }
            return IndiaStateCodeCsvList;
        }

        public List<IndiaStateCodeDTO> sortingByStateCode(string path)
        {
            List<IndiaStateCodeDTO> list = loadingStateCensusCSV(path);
            list.Sort(delegate (IndiaStateCodeDTO object1, IndiaStateCodeDTO object2) { return object1.StateCode.CompareTo(object2.StateCode); });
            return list;
        }
    }
}
