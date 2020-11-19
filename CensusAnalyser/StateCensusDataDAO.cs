using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusDataDAO
    {
        public string State;
        public int Population;
        public string AreaInSqKm;
        public string DensityPerSqKm;

        public StateCensusDataDAO(StateCensusDataDTO censusDataDTO) {

            this.State = censusDataDTO.State;
            this.Population = censusDataDTO.Population;
            this.AreaInSqKm = censusDataDTO.AreaInSqKm;
            this.DensityPerSqKm = censusDataDTO.DensityPerSqKm;

        }
    }
}
