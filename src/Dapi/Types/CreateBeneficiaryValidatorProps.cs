namespace Dapi.Types {
    public class CreateBeneficiaryValidatorProps {
        public ValidatorProps name { get; }
        public ValidatorProps nickname { get; }
        public ValidatorProps swiftCode { get; }
        public ValidatorProps iban { get; }
        public ValidatorProps accountNumber { get; }
        public ValidatorProps address { get; }
        public ValidatorProps branchAddress { get; }
        public ValidatorProps branchName { get; }
        public ValidatorProps country { get; }
        public ValidatorProps phoneNumber { get; }
        public ValidatorProps sortCode { get; }

        public CreateBeneficiaryValidatorProps(ValidatorProps name, ValidatorProps nickname, ValidatorProps swiftCode, ValidatorProps iban, ValidatorProps accountNumber,
            ValidatorProps address, ValidatorProps branchAddress, ValidatorProps branchName, ValidatorProps country, ValidatorProps phoneNumber, ValidatorProps sortCode) {
            this.name = name;
            this.nickname = nickname;
            this.swiftCode = swiftCode;
            this.iban = iban;
            this.accountNumber = accountNumber;
            this.address = address;
            this.branchAddress = branchAddress;
            this.branchName = branchName;
            this.country = country;
            this.phoneNumber = phoneNumber;
            this.sortCode = sortCode;
        }
    }
}
