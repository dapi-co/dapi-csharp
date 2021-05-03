namespace Dapi.Types {
    public class Country {
        public string code { get; }
        public string name { get; }

        public Country(string code, string name) {
            this.code = code;
            this.name = name;
        }
    }
}
