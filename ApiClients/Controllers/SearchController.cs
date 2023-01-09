using ApiClients.Models;
using ApiClients.Services;
using ApiClients.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private IClientsRepository clientsRepository;

        public SearchController(IClientsRepository clientRepository)
        {
            this.clientsRepository = clientRepository;
        }


        [HttpGet("{name}")]
        [ActionName(nameof(GetClientByName))]
        public IEnumerable<Client> GetClientByName(string name)
        {
            var clientByID = this.clientsRepository.GetClientByName(name);
            if (clientByID == null)
            {
                return (IEnumerable<Client>)NotFound();
            }
            return clientByID;
        }
    }
}
