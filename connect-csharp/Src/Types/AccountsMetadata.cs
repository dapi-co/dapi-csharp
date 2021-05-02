namespace Dapi.Types {
    public class AccountsMetadata {
        public bool isCreateBeneficiaryEndpointRequired { get; }
        public bool willNewlyAddedBeneficiaryExistBeforeCoolDownPeriod { get; }
        public string swiftCode { get; }
        public string sortCode { get; }
        public string bankName { get; }
        public string branchName { get; }
        public string branchAddress { get; }
        public BeneficiaryAddress address { get; }
        public TransferBounds[] transferBounds { get; }
        public Range beneficiaryCoolDownPeriod { get; }
        public Range transactionRange { get; }
        public Country country { get; }
        public Validators validators { get; }

        public AccountsMetadata(bool isCreateBeneficiaryEndpointRequired, bool willNewlyAddedBeneficiaryExistBeforeCoolDownPeriod, string swiftCode, string sortCode, string bankName,
            string branchName, string branchAddress, BeneficiaryAddress address, TransferBounds[] transferBounds, Range beneficiaryCoolDownPeriod, Range transactionRange, Country country,
            Validators validators) {
            this.isCreateBeneficiaryEndpointRequired = isCreateBeneficiaryEndpointRequired;
            this.willNewlyAddedBeneficiaryExistBeforeCoolDownPeriod = willNewlyAddedBeneficiaryExistBeforeCoolDownPeriod;
            this.swiftCode = swiftCode;
            this.sortCode = sortCode;
            this.bankName = bankName;
            this.branchName = branchName;
            this.branchAddress = branchAddress;
            this.address = address;
            this.transferBounds = transferBounds;
            this.beneficiaryCoolDownPeriod = beneficiaryCoolDownPeriod;
            this.transactionRange = transactionRange;
            this.country = country;
            this.validators = validators;
        }
    }
}
