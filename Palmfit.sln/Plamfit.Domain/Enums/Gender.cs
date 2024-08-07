using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Plamfit.Domain.Enums
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female = 2,

        [Description("Unknown")]
        Unknown = 3
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EligibilityGender
    {
        [EnumMember(Value = "M")] Male,
        [EnumMember(Value = "F")] Female,
    }
}
