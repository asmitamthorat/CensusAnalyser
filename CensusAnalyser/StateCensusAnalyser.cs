using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace CensusAnalyser
{
    public class StateCensusAnalyser:Adapter
    {
     
        public List<StateCensusDataDAO> loadStateCensusData(string path) {
            CSVFactory csvFactory = new CSVFactory();
            
            LoadCSVFile(path);
            csvFactory.CSVBuilder(path, "StateCensusAnalyser");


            List<StateCensusDataDAO> list = csvFactory.mapStateCensusAnalyser["StateCensusAnalyser"];
           string json= JsonConvert.SerializeObject(list);
           
            Console.WriteLine(json);
          
            StateCensusDataDTO[] census = JsonConvert.DeserializeObject<StateCensusDataDTO[]>(json);
            Console.WriteLine("--------------");
            Console.WriteLine(census[0].State);

            
            return csvFactory.mapStateCensusAnalyser["StateCensusAnalyser"];

        }

        public string sortByName(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.State.CompareTo(object2.State); });
            string json = JsonConvert.SerializeObject(list);
            return json;

        }

        public string sortByPopulation(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.Population.CompareTo(object2.Population); });
            string json = JsonConvert.SerializeObject(list);
            return json;
        }


        public string sortByPopulationDensity(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.DensityPerSqKm.CompareTo(object2.DensityPerSqKm); });
            string json = JsonConvert.SerializeObject(list);
            return json;

        }


        public string sortByArea(string path) {
            List<StateCensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (StateCensusDataDAO object1, StateCensusDataDAO object2) { return object1.AreaInSqKm.CompareTo(object2.AreaInSqKm); });
            string json = JsonConvert.SerializeObject(list);
            return json;
        }
    }
}
