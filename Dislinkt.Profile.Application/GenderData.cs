using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dislinkt.Profile
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GenderData
    {
        /// <summary>
        /// Male
        /// </summary>
        Male = 0,
        /// <summary>
        /// Female
        /// </summary>
        Female = 1
    }
}
