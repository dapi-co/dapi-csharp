namespace Dapi.Types {
    public class BeneficiaryAddress {
        public string line1 { get; }
        public string line2 { get; }
        public string line3 { get; }

        public BeneficiaryAddress(string line1, string line2, string line3) {
            this.line1 = line1;
            this.line2 = line2;
            this.line3 = line3;
        }
    }
}
