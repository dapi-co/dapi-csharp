using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum APIStatus {
        initialized,
        failed,
        user_input_required,
        done
    }
}
