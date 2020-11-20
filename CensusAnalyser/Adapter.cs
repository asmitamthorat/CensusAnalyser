using System;
using System.IO;

namespace CensusAnalyser
{
    public class Adapter
    {
        public void LoadCSVFile(string path)
        {

            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE, "provided file is not a csv file");
            } 
            
            }

        }
    }

