using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    public class Beneficiary {
        public string name { get; }
        public string id { get; }
        public BeneficiaryType type { get; }
        public BeneficiaryStatus status { get; }
        public string iban { get; }
        public string accountNumber { get; }

        public Beneficiary(string name, string id, BeneficiaryType type, BeneficiaryStatus status, string iban, string accountNumber) {
            this.name = name;
            this.id = id;
            this.type = type;
            this.status = status;
            this.iban = iban;
            this.accountNumber = accountNumber;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum BeneficiaryType {
            own,
            same,
            local,
            intl
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum BeneficiaryStatus {
            approved,
            rejected,
            cancelled,
            waiting_for_confirmation,
            modified_for_pending_approval
        }
    }
}
