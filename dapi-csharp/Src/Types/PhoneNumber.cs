using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    public class PhoneNumber {
        public string value { get; }
        public PhoneNumberType type { get; }

        public PhoneNumber(string value, PhoneNumberType type) {
            this.value = value;
            this.type = type;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum PhoneNumberType {
            mobile,
            home,
            office,
            fax
        }
    }
}
