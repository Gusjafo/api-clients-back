using ApiClients.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ApiClients.Models.Repository
{
    public class ClientRepository: IClientsRepository
    {
        protected readonly ConexionSql context;
        public ClientRepository(ConexionSql context)
        {
            this.context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return this.context.Data_clients.ToList();
        }

        public IEnumerable<Client> GetClientByName(string name)
        {
            //var clients = this.context.Data_clients.ToList();
            return this.context.Data_clients.ToList()
                .FindAll(p => Regex.IsMatch(p.Names, name, RegexOptions.IgnoreCase));
            //return this.context.Data_clients.ToList();
        }

        public Client GetClientById(int id)
        {
            return this.context.Data_clients.Find(id);
        }
        public async Task<Client> CreateClient(Client client)
        {
            await this.context.Set<Client>().AddAsync(client);
            await this.context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            this.context.Entry(client).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClient(Client client)
        {
            //var entity = await GetByIdAsync(id);
            if (client is null)
            {
                return false;
            }
            this.context.Set<Client>().Remove(client);
            await this.context.SaveChangesAsync();

            return true;
        }

    }
}
