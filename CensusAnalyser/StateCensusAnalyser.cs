using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser:Adapter
    {
     
        public List<StateCensusDataDAO> loadStateCensusData(string path) {
            CSVFactory csvFactory = new CSVFactory();
            

            //            CSVFactory csvFactory = new CSVFactory();
            LoadCSVFile(path);
            csvFactory.CSVBuilder(path, "StateCensusAnalyser");
            return csvFactory.mapStateCensusAnalyser["StateCensusAnalyser"];

        }

        public List<StateCensusDataDAO> sortByName(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.State.CompareTo(object2.State); });
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


        public List<StateCensusDataDAO> sortByArea(string path) {

            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.AreaInSqKm.CompareTo(object2.AreaInSqKm); });
            return list;
        }
    }
}
