using System;
using System.Collections.Generic;

namespace TestCsharplibrary.Products.Constants
{
    public class accountsMetaDataResponse
    {
        public string swiftCode;
        public string sortCode;
        public string bankName;
        public string branchName;
        public string branchAddress;
        public AddressMetaData address;


        public List<TransferBounds> transferBounds;

        public Boolean isCreateBeneficiaryEndpointRequired;
        public Boolean willNewlyAddedBeneficiaryExistBeforeCoolDownPeriod;
        public Country country;
    }

    public class AddressMetaData
    {
        public string line1;
        public string line2;
        public string line3;
    }
    public class BeneficiaryCoolDownPeriod
    {
        public int value;
        public string unit;
    }
    public class TransactionRange
    {
        public int value;
        public string unit;
    }
    public class TransferBounds
    {
        public int minimum;
        public Currency currency;
        public string type;
    }


    public class Country
    {
        public string code;
        public string name;
    }
}
