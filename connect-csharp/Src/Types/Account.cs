using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    public class Account {
        public string name { get; }
        public string iban { get; }
        public string number { get; }
        public AccountType type { get; }
        public string id { get; }
        public bool isFavourite { get; }
        public Currency currency { get; }

        public Account(string name, string iban, string number, AccountType type, string id, bool isFavourite, Currency currency, Balance balance) {
            this.name = name;
            this.iban = iban;
            this.number = number;
            this.type = type;
            this.id = id;
            this.isFavourite = isFavourite;
            this.currency = currency;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccountType {
            current,
            savings,
            loan,
            credit,
            deposit,
            other
        }
    }
}
