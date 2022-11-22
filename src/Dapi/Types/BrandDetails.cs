namespace Dapi.Types {
    public class BrandDetails {
        public string logo { get; }
        public string name { get; }

        public BrandDetails(string logo, string name) {
            this.logo = logo;
            this.name = name;
        }
    }
}
