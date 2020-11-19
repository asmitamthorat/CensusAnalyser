using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class Delimiter
    {
        static private List<StateCensusDataDTO> StateCensusAnalyserlist = new List<StateCensusDataDTO>();
        public void loadData(String path)
        {
            using (StreamReader reader = new StreamReader(path)) 
            {

                String data = reader.ReadLine();
                if (!data.Contains(","))
                {

                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DILIMINATOR, "dilimiter issue");
                }
            }

        }
    }
}


