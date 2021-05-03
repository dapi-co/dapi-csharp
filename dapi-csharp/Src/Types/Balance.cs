namespace Dapi.Types {
    public class Balance {
        public string amount { get; }
        public string accountNumber { get; }
        public Currency currency { get; }

        public Balance(string amount, string accountNumber, Currency currency) {
            this.amount = amount;
            this.accountNumber = accountNumber;
            this.currency = currency;
        }
    }
}
