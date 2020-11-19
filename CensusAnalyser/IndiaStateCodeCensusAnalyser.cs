using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class IndiaStateCodeCensusAnalyser
    {
        static private List<IndiaStateCodeDTO> IndiaStateCodeCsvList = new List<IndiaStateCodeDTO>();
        public List<IndiaStateCodeDTO> loadingStateCensusCSV(String path)
        {

            using (var file = new System.IO.StreamReader(path))
            {
                IndiaStateCodeCsvList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<IndiaStateCodeDTO>().ToList();
            }
            return IndiaStateCodeCsvList;
        }

    }
}
