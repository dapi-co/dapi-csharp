using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products.Constants.payments
{
    public class CreateBeneficiaryResponse
    {
        public string jobID;
        public Boolean success;
        public string status;


        public List<UserInputs> userInputs;

        public CreateBeneficiaryResponse()
        {
            userInputs = new List<UserInputs>();
        }
    }
    public class UserInputs
    {
        public string id;
        public string query;
    }

}
