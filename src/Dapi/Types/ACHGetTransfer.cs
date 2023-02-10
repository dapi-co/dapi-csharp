namespace Dapi.Types {
    public class ACHPullTransferInfo {
        public float amount { get; }
        public Currency currency { get; }
        public string status { get; }

        public ACHPullTransferInfo(float amount, Currency currency, string status) {
            this.amount = amount;
            this.currency = currency;
            this.status = status;
        }
    }
}
