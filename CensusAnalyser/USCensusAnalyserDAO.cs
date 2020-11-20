

namespace CensusAnalyser
{
    public class USCensusAnalyserDAO
    {
        public string StateId;

        public string State;

        public int Population;
        public int HousingUnits;

        public float TotalArea;

        public float WaterArea;
        public float LandArea;

        public float PopulationDensity;
        public float HousingDensity;

        public USCensusAnalyserDAO(USCensusAnalyserDTO uSCensusAnalyserDTO) {

            this.StateId = uSCensusAnalyserDTO.StateId;
            this.State = uSCensusAnalyserDTO.State;
            this.Population = uSCensusAnalyserDTO.Population;
            this.HousingUnits = uSCensusAnalyserDTO.HousingUnits;
            this.TotalArea = uSCensusAnalyserDTO.TotalArea;
            this.WaterArea = uSCensusAnalyserDTO.WaterArea;
            this.LandArea = uSCensusAnalyserDTO.LandArea;
            this.PopulationDensity = uSCensusAnalyserDTO.PopulationDensity;
            this.HousingDensity = uSCensusAnalyserDTO.HousingDensity;

        }
    }
}
