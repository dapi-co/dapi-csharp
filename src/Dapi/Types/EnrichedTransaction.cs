using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    public class EnrichedTransaction {
        public float amount { get; }
        public string date { get; }
        public Dapi.Types.TransactionType type { get; }
        public string description { get; }
        public string details { get; }
        public Currency currency { get; }
        public float beforeAmount { get; }
        public float afterAmount { get; }
        public string reference { get; }
        public string category { get; }
        public BrandDetails brandDetails{ get; }

        public EnrichedTransaction(float amount, string date, TransactionType type, string description, string details, Currency currency, float beforeAmount, float afterAmount, string reference, string category, BrandDetails brandDetails) {
            this.amount = amount;
            this.date = date;
            this.type = type;
            this.description = description;
            this.details = details;
            this.currency = currency;
            this.beforeAmount = beforeAmount;
            this.afterAmount = afterAmount;
            this.reference = reference;
            this.category = category;
            this.brandDetails = brandDetails;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionType {
            credit,
            debit
        }
    }
}
