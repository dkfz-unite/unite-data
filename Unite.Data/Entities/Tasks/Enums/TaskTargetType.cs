using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums
{
    public enum TaskTargetType
    {
        [EnumMember(Value = "Donor")]
        Donor = 1,

        [EnumMember(Value = "Specimen")]
        Specimen = 2,

        [EnumMember(Value = "Mutation")]
        Mutation = 3        
    }
}
