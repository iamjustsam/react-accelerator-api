using System;

namespace react_accelerator_api.Services
{
    public class ClientService : Service<Client>, IClientService
    {
        public ClientService()
        {
            Create(new Client
            {
                Id = Guid.NewGuid(),
                FirstName = "Bobby",
                LastName = "Tables",
                Birthday = "10/10/2007",
                City = string.Empty,
                Email = "bobby.tables@xkcd.com",
                Zip = string.Empty
            });
        }
    }
}
