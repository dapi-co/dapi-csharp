namespace Dapi.Types {
    public class CategorizedTransaction {
        public float amount { get; }
        public string date { get; }
        public TransactionType type { get; }
        public string description { get; }
        public string details { get; }
        public Currency currency { get; }
        public float beforeAmount { get; }
        public float afterAmount { get; }
        public string reference { get; }
        public string category { get; }

        public CategorizedTransaction(float amount, string date, TransactionType type, string description, string details, Currency currency, float beforeAmount, float afterAmount, string reference, string category) {
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
        }
    }
}
