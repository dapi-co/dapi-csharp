using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products.Constants
{
    public class identityResponse
    {

        public string jobID;
        public Boolean success;
        public string status;
        public Identity identity;

        public identityResponse()
        {
            identity = new Identity();
        }
    }
    public class Identity
    {
        public string name;

        public string nationality;
        public string dateOfBirth;
        public Identification identification;


        public string emailAddress;

        public Address address;
        public List<Numbers> numbers;
        public Identity()
        {
            address = new Address();
            numbers = new List<Numbers>();
        }


    }
    public class Address
    {
        public string flat;
        public string building;
        public string full;
        public string area;
        public string poBox;
        public string city;
        public string state;
        public string country;

    }

    public class Numbers
    {
        public string value;
        public string type;
    }
    public class Identification
    {
        public string type;
        public string value;
    }
}
