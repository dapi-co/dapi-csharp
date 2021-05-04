namespace Dapi.Types {
    public class ValidatorProps {
        public bool required { get; }
        public int length { get; }
        public string allowedCharacters { get; }
        public object[] attributes { get; }

        public ValidatorProps(bool required, int length, string allowedCharacters, object[] attributes) {
            this.required = required;
            this.length = length;
            this.allowedCharacters = allowedCharacters;
            this.attributes = attributes;
        }
    }
}
