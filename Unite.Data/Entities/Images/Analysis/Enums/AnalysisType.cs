using System.ComponentModel;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Images.Analysis.Enums;

public enum AnalysisType
{
    // Radiomics Feature Extraction.
    [EnumMember(Value = "RFE")]
    [Description("Radiomics Features Extraction")]
    RFE = 1
}
