using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dapi.Types {
    public class UserInput {
        /// <summary>
        /// returns the id of this UserInput, which is the type of input required.
        /// </summary>
        public UserInputID id { get; }

        /// <summary>
        /// returns the index of this UserInput, starting from 0.
        /// will always be 0 if only one input is requested.
        /// </summary>
        public int index { get; }

        /// <summary>
        /// returns the textual description of what is required from the user side by this UserInput.
        /// </summary>
        public string query { get; }

        /// <summary>
        /// returns the UserInput that must be submitted.
        /// in the response it will always be empty.
        /// </summary>
        public string answer { get; }

        /// <summary>
        /// Creates a UserInput object with all of its info.
        /// </summary>
        ///
        /// <param name="id">type of input required.</param>
        /// <param name="index">the index of this UserInput object, starting from 0.
        /// it's used in case more than one user input is requested.
        /// will always be 0 if only one input is requested.</param>
        /// <param name="query">textual description of what is required from the user side.</param>
        /// <param name="answer">user input that must be submitted.</param>
        public UserInput(UserInputID id, int index, string query, string answer) {
            this.id = id;
            this.index = index;
            this.query = query;
            this.answer = answer;
        }

        /// <summary>
        /// Creates a UserInput object with only the fields that's needed for submitting
        /// a user input in the request.
        /// </summary>
        ///
        /// <param name="id">type of input required.</param>
        /// <param name="index">the index of this UserInput object, starting from 0.
        /// it's used in case more than one user input is requested.
        /// will always be 0 if only one input is requested.</param>
        /// <param name="answer">user input that must be submitted.</param>
        public UserInput(UserInputID id, int index, string answer) {
            this.id = id;
            this.index = index;
            this.query = null;
            this.answer = answer;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum UserInputID {
            otp,
            secret_question,
            captcha,
            pin,
            confirmation,
            token
        }
    }
}
