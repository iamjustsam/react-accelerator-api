using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using react_accelerator_api.Services;

namespace react_accelerator_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _clientService.Get();
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Client> GetClient(Guid id)
        {
            var client = _clientService.Get(id);

            return client != null ? Ok(client) : NotFound();
        }

        [HttpPost]
        public Client CreateClient(Client client)
        {
            return _clientService.Create(client);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<Client> UpdateClient(Guid id, Client client)
        {
            var newClient = _clientService.Update(id, client);

            return newClient != null ? Ok(newClient) : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public void DeleteClient(Guid id)
        {
            _clientService.Delete(id);
        }
    }
}
