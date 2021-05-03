namespace Dapi.Types {
    public class IdentityAddress {
        public string flat { get; }
        public string building { get; }
        public string full { get; }
        public string area { get; }
        public string poBox { get; }
        public string city { get; }
        public string state { get; }
        public string country { get; }

        public IdentityAddress(string flat, string building, string full, string area, string poBox, string city, string state, string country) {
            this.flat = flat;
            this.building = building;
            this.full = full;
            this.area = area;
            this.poBox = poBox;
            this.city = city;
            this.state = state;
            this.country = country;
        }
    }
}
