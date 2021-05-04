namespace Dapi.Types {
    public class CreateTransferValidator {
        public CreateTransferValidatorProps local { get; }
        public CreateTransferValidatorProps same { get; }

        public CreateTransferValidator(CreateTransferValidatorProps local, CreateTransferValidatorProps same) {
            this.local = local;
            this.same = same;
        }
    }
}
