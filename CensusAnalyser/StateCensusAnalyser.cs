using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
     
        public List<StateCensusDataDAO> loadStateCensusData(string path) {
            CSVFactory csvFactory = new CSVFactory();
            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE, "provided file is not a csv file");
            }

            csvFactory.CSVBuilder(path, "StateCensusAnalyser");
            return csvFactory.mapStateCensusAnalyser["StateCensusAnalyser"];

        }

        public List<StateCensusDataDAO> sortByName(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.State.CompareTo(object2.State); });
            Console.WriteLine(list[0].State);
            return list;

        }

        public List<StateCensusDataDAO> sortByPopulation(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.Population.CompareTo(object2.Population); });
            return list;
        }


        public List<StateCensusDataDAO> sortByPopulationDensity(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.DensityPerSqKm.CompareTo(object2.DensityPerSqKm); });
            return list;

        }
    }
}
