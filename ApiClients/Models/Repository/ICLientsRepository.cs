namespace ApiClients.Models.Repository
{
    public interface IClientsRepository
    {

        Task<Client> CreateClient(Client product);
        Task<bool> DeleteClient(Client product);
        Client GetClientById(int id);
        IEnumerable<Client> GetClientByName(string name);
        IEnumerable<Client> GetClients();
        Task<bool> UpdateClient(Client product);
    }
}
