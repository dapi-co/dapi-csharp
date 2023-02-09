namespace Dapi.Types {
    public class ACHGetTransfer {
        public number amount { get; }
        public Currency currency { get; }
        public string status { get; }

        public ACHGetTransfer(number amount, Currency currency, string status) {
            this.amount = amount;
            this.currency = currency;
            this.status = status;
        }
    }
}