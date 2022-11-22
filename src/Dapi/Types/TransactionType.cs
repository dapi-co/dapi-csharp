using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
     [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionType {
            credit,
            debit
        }
}
