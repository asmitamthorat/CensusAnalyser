using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class Adapter
    {
        public void LoadCSVFile(string path) {

            CSVFactory csvFactory = new CSVFactory();
            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE, "provided file is not a csv file");
            } 
            
            }

        }
    }

