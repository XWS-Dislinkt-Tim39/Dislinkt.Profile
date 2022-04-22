using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dislinkt.Profile
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VisibilityStatusData
    {
        /// <summary>
        /// Private profile
        /// </summary>
        Private = 0,
        /// <summary>
        /// Public profile
        /// </summary>
        Public = 1
    }
}
