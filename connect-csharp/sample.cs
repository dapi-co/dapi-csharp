

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using connect_csharp;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace TestCsharplibrary
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string appSecret = "5c0cff2086fdb13f6b495765fc98231a1ade673d175ef141c2159f0d23c51da2276c5db8e599c3ca8eb89232eafe27a0b9b72857d43971fe7b7e5ea7cae032e41a30b100ec5e42eb902e7f8af6118f22adabec0cae241a800a56c77b00ccc32294fbb75105782cf74b792573c17dcf5ccb426e85c24b0391a0ddc1ba0847eaae";
            //string accessCode = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzYWx0IjoiV2h6dnJoUEVuUjdLeTFWdHpLT2ZpK2xCVy9hNDgwa3pyM21UcW1hRlVQND0iLCJhcHBLZXkiOiI3ZGU3M2ExZGFhYTQzYWU1MTQ5MzllYjFhZGI1MzNiZDdhMzcxN2QwMjdhOWQxZTZiY2EzOTNmMzk0YzdhOWRmIiwidG9rZW5JRCI6IjM4YjhlNjU4LWU0NmUtNDM0OS1iNmNlLTMxMDc3ZDM1M2Y2YSIsImlhdCI6MTU5NjkzMDc0MCwiZXhwIjoxNTk2OTMxMDQwfQ.L1BvanFFpBeuB07z2_z78c440jeJ-aThDx3sDrg0Tgw";
            //string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzYWx0IjoiV2h6dnJoUEVuUjdLeTFWdHpLT2ZpK2xCVy9hNDgwa3pyM21UcW1hRlVQND0iLCJhcHBLZXkiOiI3ZGU3M2ExZGFhYTQzYWU1MTQ5MzllYjFhZGI1MzNiZDdhMzcxN2QwMjdhOWQxZTZiY2EzOTNmMzk0YzdhOWRmIiwidG9rZW5JRCI6IjFkOGU5MWRiLTcyMzItNDI4My04N2FiLTYyMzZiZWUxY2UyYSIsImF1dGhvcml6YXRpb25zIjp7ImF1dGhlbnRpY2F0aW9uIjp7ImNyZWF0ZSI6dHJ1ZX0sImlkZW50aXR5Ijp7ImdldCI6dHJ1ZX0sImFjY291bnRzIjp7ImdldCI6dHJ1ZX0sImJhbGFuY2UiOnsiZ2V0Ijp0cnVlfSwidHJhbnNhY3Rpb25zIjp7ImdldCI6dHJ1ZX0sImJlbmVmaWNpYXJpZXMiOnsiZ2V0Ijp0cnVlLCJjcmVhdGUiOnRydWV9LCJ0cmFuc2ZlciI6eyJjcmVhdGUiOnRydWV9LCJjYXJkcyI6eyJnZXQiOnRydWV9LCJzdGF0ZW1lbnRzIjp7ImdldCI6dHJ1ZX19LCJpYXQiOjE1OTY5NTAzMjd9.-x5mvDwLBGowroyqiW9ah0Ol1TvlwDNlsS_63Vdksnw";
            //string userSecret = "CWJsqshi6ztFno71NKLdkmFeRrKXOlou0Fgw1bFqwAZ0I7U/VJ/4uEP+TwtpWucrgUvM7Gc/Xh6NMyMQeQ3xu8vLstqDeMLawhIB2/Y3XfrQpyByy9lDpQCpkh3yS/vrf18pEn+V8FFICNpYoXTwipDnSdmPHaFDkh/kIkh5fAQWKH/tQvz9JPi/CRm7ga4sodC+h2S+it94gq28cJebeTsQ9DipmOycIjB6a7GPrqOMdbLLe/80pya2p8wOz6LA/i0IcYnzzmBZVhUu6io6AMfi0RIK6mfuZgOnBlMWiczZCGO025mcIT7fbtWWR0CTpE52qDgw7jbVEo8aqCPcsCVxRFYeGra1zV2ii4jPvZkQSFDeDG/gVEbR9x1s/fT/JjFF8l9bxIFR/l6kGxHIm/ouN4TieO2iQxARyeBhtXd6m2jQFQgM/k2U32cK5ZKpdKFeSGoauLuQq1wrSxq1ksZR3wbrmJcminmgvK07GRhGuphqNUOWf36ltgPotcLnpJ4dJX8Ua+cjAKVSF9HLwXGPKbG3gVrhE9uGcGO1mZpws9cNZU3r93gAFHwaWgiKbC+gKndYXzDBzBgUrSY9G6kfc2UQpn9UdjgrIAg9j24vv0Cj8DI5IX94vClFPbwqSjwGYdGFh3aQXhAqEgUEIcuq/OFVNZ9CqI28TItPi2w=";
            //string connectionID = "a777c3e0c988e05005502c09d47f430c9d247634";
            string accessCode = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzYWx0IjoiN3JlU2kwOGp5MXBEMno3djNBalcyUnhZMGNuWWhhU3RCYWViYTRlQnBoTT0iLCJhcHBLZXkiOiI3ZGU3M2ExZGFhYTQzYWU1MTQ5MzllYjFhZGI1MzNiZDdhMzcxN2QwMjdhOWQxZTZiY2EzOTNmMzk0YzdhOWRmIiwidG9rZW5JRCI6ImYzODViMGM1LTQzOWQtNDM0My04NGRjLTdkODU1YTFlZDlkOSIsImlhdCI6MTU5NzA0NzYxNSwiZXhwIjoxNTk3MDQ3OTE1fQ.HsMUa-bCkJHxVkK428_weZAeeoOMUo4OdvI9hDkpiIo";


            string connectionID = "7f8e380083692b5c4db52893e58cb4ef8fb095b6";
            string userID = "KEjXduQQVftTHvZZNdHml/aJGuIzVGtHHWQM80xungxMA7I0Mkzo0cgHgjZ/USj3OxpOuhR021mSbhzwqe2AtQ==";
            string userSecret = "QL0A5UbuXg7pBaxn2kI3CxtTJVxlJPTd857qkx7OPvs49vyD6K6ei1pCqrbwgTA2S3pFNU+zBq4sNb31j9DOKiqrkYJZhAOO9PPMO10r3Df3VnrRxi8MCzcJAG28Jf2xxSLJ9g3/v9CaFLl6GV8RRADp9NMeE9gfPQ6ihOCbxPO5C87BqdNW1R9Z89qqACKh3Y9aol7Hh+sSReIGtPoHKn9V8i4zChje3idvCCCBp9VLNbrrM5xKFZcdu90ywGP5eGQKpPqWj1LaldmVrNEfd6WIxrCcHmrPKmxSo+jnB3cTvTAjImuM+6DLjCvSypAxXZwsASZvJzDi+nilVtdT0mj9yPsMEAa7Wy7RXz2t9JOBTbErZcPPb+bAJ5/BrYly5cUkU03/IKuhNhmq/oJyIPb6LFGe3kYMLy2/9eW9BZh8Va5HiknWKFQrbxU3jVUN20YGmBEpQ981MrIcxLNd1SG5bjgMWdSe+nfwa8u0UlUEOgmE4qRXTsfeVOyv0aVqrLSiaDocTPyTn1esEz4LivqGigtlg0AnVdzi/amyYh8w5zJf1dyweQXM5TZFHE6Krkjg1XQfeHjO/ul9+IzUBOSblhZqK1fLFweU6OJZUEC+QZ4qcvsq0B39vPYG99nMtMeRaAeN1nXX/bDaSHsQeo2m914Hyti4f3ZJzXShdQI=";
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzYWx0IjoiN3JlU2kwOGp5MXBEMno3djNBalcyUnhZMGNuWWhhU3RCYWViYTRlQnBoTT0iLCJhcHBLZXkiOiI3ZGU3M2ExZGFhYTQzYWU1MTQ5MzllYjFhZGI1MzNiZDdhMzcxN2QwMjdhOWQxZTZiY2EzOTNmMzk0YzdhOWRmIiwidG9rZW5JRCI6ImYzODViMGM1LTQzOWQtNDM0My04NGRjLTdkODU1YTFlZDlkOSIsImF1dGhvcml6YXRpb25zIjp7ImF1dGhlbnRpY2F0aW9uIjp7ImNyZWF0ZSI6dHJ1ZX0sImlkZW50aXR5Ijp7ImdldCI6dHJ1ZX0sImFjY291bnRzIjp7ImdldCI6dHJ1ZX0sImJhbGFuY2UiOnsiZ2V0Ijp0cnVlfSwidHJhbnNhY3Rpb25zIjp7ImdldCI6dHJ1ZX0sImJlbmVmaWNpYXJpZXMiOnsiZ2V0Ijp0cnVlLCJjcmVhdGUiOnRydWV9LCJ0cmFuc2ZlciI6eyJjcmVhdGUiOnRydWV9LCJjYXJkcyI6eyJnZXQiOnRydWV9LCJzdGF0ZW1lbnRzIjp7ImdldCI6dHJ1ZX19LCJpYXQiOjE1OTcwNDc2NDZ9.ZCQ-Bd_cUrm4AzscECTl7DKdzsPtTXFp-AJfKwj1dsQ";

            DapiClient d = new DapiClient(appSecret);


            //********************TESTING***************************************
            //********************AUTH***************************************
            // Console.WriteLine(d.exchangeToken(appSecret, accessCode, connectionID));
            //Console.WriteLine(d.refreshAccessToken(appSecret, accessToken));



            //********************DATA***************************************
            Console.WriteLine("********************IDENTITY***************************************");
            Console.WriteLine(d.getIdentity(accessToken, userSecret));
            Console.WriteLine("********************ACCOUNTS***************************************");
            Console.WriteLine(d.getAccounts(accessToken, userSecret));
            Console.WriteLine("********************BALANCE***************************************");
            Console.WriteLine(d.getBalance(accessToken, userSecret, "1XEwNY4QbNC63OvrICO2yDOlaXCzAwhnb/divVFZmCAe456PcqqQANxqfW+v1AYf4ncIHkmeD1RHouVOVyCEsw=="));
            Console.WriteLine("********************TRANSACTIONS***************************************");
            Console.WriteLine(d.getTransactions(accessToken, userSecret, "1XEwNY4QbNC63OvrICO2yDOlaXCzAwhnb/divVFZmCAe456PcqqQANxqfW+v1AYf4ncIHkmeD1RHouVOVyCEsw==", "2020-06-01", "2020-05-01"));
            Console.WriteLine("********************GETMETADATA***************************************");
            Console.WriteLine(d.getMetaData(accessToken, userSecret));

            //********************PAYMENTS***************************************
            Console.WriteLine("********************GETBENEFICIARIES***************************************");
            //Console.WriteLine(d.getBeneficiary(accessToken, userSecret));
            string data = d.getBeneficiary(accessToken, userSecret);
            Console.WriteLine("********************CREATETRANSFER***************************************");
            //Console.WriteLine(d.createTransfer(accessToken, userSecret, "mJ0WOFcjOfWsDXZta/L1meyy9+YyyJ+s59+VWeEo1LxcAzBankFlhQzr9A4AWR2MwOYN/WS6kqQ91+cQHa/3fQ==", "1XEwNY4QbNC63OvrICO2yDOlaXCzAwhnb/divVFZmCAe456PcqqQANxqfW+v1AYf4ncIHkmeD1RHouVOVyCEsw==", "1"));
            Console.WriteLine("***************NEW************");

            JObject json = JObject.Parse(data);
            Console.WriteLine("JOBID" + json.GetValue("jobID"));
            string jobID = json.GetValue("jobID").ToString();
            //********************JOBS***************************************

            Console.WriteLine(d.getJobStatus(accessToken, userSecret, jobID));



        }
    }
}
