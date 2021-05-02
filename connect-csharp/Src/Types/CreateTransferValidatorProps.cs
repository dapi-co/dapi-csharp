namespace Dapi.Types {
    public class CreateTransferValidatorProps {
        public ValidatorProps remarks { get; }

        public CreateTransferValidatorProps(ValidatorProps remarks) {
            this.remarks = remarks;
        }
    }
}
