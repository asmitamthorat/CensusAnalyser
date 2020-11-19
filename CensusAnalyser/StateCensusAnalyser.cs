using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        List<StateCensusDataDTO> StateCensusAnalyserlist = new List<StateCensusDataDTO>();
        public Dictionary<String, List<StateCensusDataDTO>> Dictionary = new Dictionary<string, List<StateCensusDataDTO>>();
        public List<StateCensusDataDTO> loadStateCensusData(string path) {
            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE, "provided file is not a csv file");
            }

                var file = new System.IO.StreamReader(path);
            StateCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<StateCensusDataDTO>().ToList();

            Dictionary.Add("StateCensusAnalyzer", StateCensusAnalyserlist);
            var matchKey = "StateCensusAnalyzer";
            return Dictionary[matchKey];

        }
    }
}
