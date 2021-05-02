using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    public class Transaction {
        public float amount { get; }
        public string date { get; }
        public TransactionType type { get; }
        public string description { get; }
        public string details { get; }
        public Currency currency { get; }
        public float beforeAmount { get; }
        public float afterAmount { get; }
        public string reference { get; }

        public Transaction(float amount, string date, TransactionType type, string description, string details, Currency currency, float beforeAmount, float afterAmount, string reference) {
            this.amount = amount;
            this.date = date;
            this.type = type;
            this.description = description;
            this.details = details;
            this.currency = currency;
            this.beforeAmount = beforeAmount;
            this.afterAmount = afterAmount;
            this.reference = reference;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionType {
            credit,
            debit
        }
    }
}
