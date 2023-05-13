using System.ComponentModel;
using System.Runtime.Serialization;

namespace AC.Project.Domain.Entities.Enums
{
    public enum Status
    {
        [Description("Alive")]
        [EnumMember(Value = "Alive")]
        Alive,

        [Description("Dead")]
        [EnumMember(Value = "Dead")]
        Dead,

        [Description("unknown")]
        [EnumMember(Value = "unknown")]
        unknown
    }
}
