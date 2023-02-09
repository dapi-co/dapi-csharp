namespace Dapi.Types {
    public class ACHGetTransfer {
        public float amount { get; }
        public Currency currency { get; }
        public string status { get; }

        public ACHGetTransfer(float amount, Currency currency, string status) {
            this.amount = amount;
            this.currency = currency;
            this.status = status;
        }
    }
}