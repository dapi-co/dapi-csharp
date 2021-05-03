namespace Dapi.Types {
    public class CreateBeneficiaryValidator {
        public CreateBeneficiaryValidatorProps local { get; }
        public CreateBeneficiaryValidatorProps same { get; }

        public CreateBeneficiaryValidator(CreateBeneficiaryValidatorProps local, CreateBeneficiaryValidatorProps same) {
            this.local = local;
            this.same = same;
        }
    }
}
