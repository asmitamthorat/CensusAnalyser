
namespace CensusAnalyser
{
    public class IndiaStateCodeDTO
    {
        public int SrNo { get; set; }
        public string StateName { get; set; }
        public string TIN { get; set; }
        public string StateCode { get; set; }

        public override string ToString()
        {
            return $"SrNo {SrNo},StateName {StateName},TIN {TIN},StateCode {StateCode}";
        }
    }
}
