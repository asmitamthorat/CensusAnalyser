using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class USCensusAnalyser
    {
        List<USCensusAnalyserDAO> IndiaStateCodeCsvList = new List<USCensusAnalyserDAO>();
        public List<USCensusAnalyserDAO> loadStateCensusData(string path)
        {
            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE, "provided file is not a csv file");
            }
            using (var file = new System.IO.StreamReader(path))
            {
                IndiaStateCodeCsvList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<USCensusAnalyserDAO>().ToList();
            }
            return IndiaStateCodeCsvList;


        }
    }
}
