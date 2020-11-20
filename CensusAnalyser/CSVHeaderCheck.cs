using CsvHelper;
using System;
using System.IO;

namespace CensusAnalyser
{
    public class CSVHeaderCheck
    {
        public void loadFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                if (!csv.Configuration.HasHeaderRecord)
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVAILD_HEADER, "csv file doesn't have header");
                }

            }
        }
    }
}
