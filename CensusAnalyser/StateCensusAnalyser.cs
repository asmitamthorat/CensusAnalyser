using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
      //  List<StateCensusDataDAO> StateCensusAnalyserlist = new List<StateCensusDataDAO>();
      //  public Dictionary<String, List<StateCensusDataDAO>> Dictionary = new Dictionary<string, List<StateCensusDataDAO>>();
        public List<StateCensusDataDAO> loadStateCensusData(string path) {
            CSVFactory csvFactory = new CSVFactory();
            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE, "provided file is not a csv file");
            }

              //  var file = new System.IO.StreamReader(path);
            // StateCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
            //       .GetRecords<StateCensusDataDAO>().ToList();

            //Dictionary.Add("StateCensusAnalyzer", StateCensusAnalyserlist);
            //var matchKey = "StateCensusAnalyzer";
            csvFactory.CSVBuilder(path, "StateCensusAnalyser");
            return csvFactory.mapStateCensusAnalyser["StateCensusAnalyser"];

        }

        public List<StateCensusDataDAO> sortByName(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.State.CompareTo(object2.State); });
            Console.WriteLine(list[0].State);
            return list;

        }
    }
}
