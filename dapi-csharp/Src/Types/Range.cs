namespace Dapi.Types {
    public class Range {
        public int value { get; }
        public string unit { get; }

        public Range(int value, string unit) {
            this.value = value;
            this.unit = unit;
        }
    }
}
