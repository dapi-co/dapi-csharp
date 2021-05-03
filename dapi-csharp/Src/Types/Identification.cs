using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    public class Identification {
        private string value;
        private IdentificationType type;

        public Identification(string value, IdentificationType type) {
            this.value = value;
            this.type = type;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum IdentificationType {
            passport,
            national_id,
            visa_number
        }
    }
}
