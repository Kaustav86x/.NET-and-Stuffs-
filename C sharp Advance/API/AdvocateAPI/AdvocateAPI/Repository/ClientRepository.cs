using AdvocateAPI.Interface;
using AdvocateAPI.Models;

namespace AdvocateAPI.Repository
{
    // implementing the interface
    public class ClientRepository : IClient
    {
        List<Client> IsClients = StaticData.IsClients;
        public bool AddClient(Client client)
        {
            var isData = IsClients.Where(u =>  u.CaseId == client.CaseId).Any();
            if(isData) 
            {
                return false;
            }
            IsClients.Add(client);
            return true;
        }
    }
}
