using System.Runtime.Serialization;

namespace Unite.Data.Entities.Radiology.Enums
{
    public enum AnalysisType
    {
        // Radiomics Feature Extraction
        [EnumMember(Value = "RFE")]
        RFE = 1
    }
}
