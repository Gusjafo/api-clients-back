using ApiClients.Models;
using ApiClients.Services;
using ApiClients.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private IClientsRepository clientsRepository;

        public ClientsController(IClientsRepository clientRepository)
        {
            this.clientsRepository = clientRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetClients))]
        public IEnumerable<Client> GetClients()
        {
            return this.clientsRepository.GetClients();
        }

        [HttpGet("{id}")]        
        [ActionName(nameof(GetClientById))]
        public ActionResult<Client> GetClientById(int id)
        {
            var clientByID = this.clientsRepository.GetClientById(id);
            if (clientByID == null)
            {
                return NotFound();
            }
            return clientByID;
        }
        
        [HttpPost]
        [ActionName(nameof(CreateClient))]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            if (RegexUtilities.IsValidEmail(client.Email)
                && RegexUtilities.IsValidDate(client.Date_of_birth)
                && RegexUtilities.IsValidCuit(client.Cuit))
            {
                await this.clientsRepository.CreateClient(client);
                return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            await this.clientsRepository.UpdateClient(client);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteClient))]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = this.clientsRepository.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            await this.clientsRepository.DeleteClient(client);

            //return Content("Cliente Eliminado");
            return NoContent();
        }


    }

}
