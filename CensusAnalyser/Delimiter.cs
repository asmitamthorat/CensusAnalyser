
using System.IO;

namespace CensusAnalyser
{
    public class Delimiter
    {
        public void loadData(string path)
        {
            using (StreamReader reader = new StreamReader(path)) 
            {

                string data = reader.ReadLine();
                if (!data.Contains(","))
                {

                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DILIMINATOR, "dilimiter issue");
                }
            }

        }
    }
}


