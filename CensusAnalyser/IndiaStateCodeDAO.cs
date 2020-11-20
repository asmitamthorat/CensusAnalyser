
namespace CensusAnalyser
{
    public class IndiaStateCodeDAO
    {
        public int SrNo;
        public string StateName;
        public string TIN;
        public string StateCode;

        public IndiaStateCodeDAO(IndiaStateCodeDTO indiaStateCode)
        {
            this.SrNo = indiaStateCode.SrNo;
            this.StateName = indiaStateCode.StateName;
            this.TIN = indiaStateCode.TIN;
            this.StateCode = indiaStateCode.StateCode;


        }
    }
}
