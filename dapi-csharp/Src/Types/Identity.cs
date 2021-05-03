namespace Dapi.Types {
    public class Identity {
        public string name { get; }
        public string nationality { get; }
        public string dateOfBirth { get; }
        public string emailAddress { get; }
        public PhoneNumber[] numbers { get; }
        public IdentityAddress address { get; }
        public Identification[] identification { get; }

        public Identity(string name, string nationality, string dateOfBirth, string emailAddress, PhoneNumber[] numbers, IdentityAddress address, Identification[] identification) {
            this.name = name;
            this.nationality = nationality;
            this.dateOfBirth = dateOfBirth;
            this.emailAddress = emailAddress;
            this.numbers = numbers;
            this.address = address;
            this.identification = identification;
        }
    }
}
