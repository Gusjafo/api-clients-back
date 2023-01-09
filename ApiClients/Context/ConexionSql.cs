using ApiClients.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClients.Context
{
    public class ConexionSql:DbContext
    {
        public ConexionSql(DbContextOptions<ConexionSql> options): base(options)
        {
        }

        public DbSet<Client> Data_clients { get; set; }

    
    }
}
