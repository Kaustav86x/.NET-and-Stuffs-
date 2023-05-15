using AdvocateAPI.Models;

namespace AdvocateAPI.Repository
{
    public class StaticData
    {
        public static List<Client> IsClients = new List<Client> 
        { 
            new Client
            {
                CaseId = 10001,
                CaseDescription="Damage to Property",
                CaseDate="15/10/2022",
                Name="Rajkumar",
                PhoneNumber="123456789",
                EmailId="user1@test.com"
            },
            new Client 
            {
                CaseId = 10002,
                CaseDescription="landlord and tanents disputes",
                CaseDate="25/10/2022",
                Name="ArvindSwamy",
                PhoneNumber="2334567890",
                EmailId="user2@test.com"
            },
            new Client 
            {
                CaseId = 10003,
                CaseDescription="Back rent",
                CaseDate="30/10/2022",
                Name="RahulDravid",
                PhoneNumber="3234567890",
                EmailId="user3@test.com"
            },
            new Client
            {
                CaseId = 10004,
                CaseDescription="Damage to Property",
                CaseDate="15/10/2022",
                Name="PreethiSingh",
                PhoneNumber="4123567890",
                EmailId="user4@test.com"
            },
            new Client
            {
                CaseId = 10005,
                CaseDescription="Unpaid personal loans",
                CaseDate="15/10/2022",
                Name="laxmiDevi",
                PhoneNumber="2345167890",
                EmailId="user4@test.com"
            }
        };
    }
}
