using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class USCensusAnalyserDTO
    {
        public string StateId { get; set; }

        public string State { get; set; }

        public int Population { get; set; }
        public int HousingUnits { get; set; }

        public float TotalArea { get; set; }

        public float WaterArea { get; set; }
        public float LandArea { get; set; }

        public float PopulationDensity { get; set; }
        public float HousingDensity { get; set; }
    }
}
