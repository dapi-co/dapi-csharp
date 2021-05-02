namespace Dapi.Types {
    public class Validators {
        public CreateBeneficiaryValidator createBeneficiary { get; }
        public CreateTransferValidator createTransfer { get; }

        public Validators(CreateBeneficiaryValidator createBeneficiary, CreateTransferValidator createTransfer) {
            this.createBeneficiary = createBeneficiary;
            this.createTransfer = createTransfer;
        }
    }
}
