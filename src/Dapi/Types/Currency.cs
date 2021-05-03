namespace Dapi.Types {
    public class Currency {
        public string code { get; }
        public string name { get; }

        public Currency(string code, string name) {
            this.code = code;
            this.name = name;
        }
    }
}
