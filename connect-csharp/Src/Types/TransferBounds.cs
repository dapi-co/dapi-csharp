namespace Dapi.Types {
    public class TransferBounds {
        public int minimum { get; }
        public Beneficiary.BeneficiaryType type { get; }
        public Currency currency { get; }

        public TransferBounds(int minimum, Beneficiary.BeneficiaryType type, Currency currency) {
            this.minimum = minimum;
            this.type = type;
            this.currency = currency;
        }
    }
}
