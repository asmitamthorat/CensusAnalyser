using System;

namespace CensusAnalyser
{
    public class CensusAnalyserException:Exception
    {
        public enum ExceptionType { 
        
        INVAILD_HEADER,INVALID_FILE,INVALID_DILIMINATOR
        }

        public readonly ExceptionType type;
        public CensusAnalyserException(ExceptionType type, string message) : base(message) {
            this.type = type;
        }
    }
}
