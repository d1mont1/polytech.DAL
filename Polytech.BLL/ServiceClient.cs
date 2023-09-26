using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using polytech.DAL.model;
using polytech.DAL;

namespace Polytech.BLL
{
    public class ServiceClient
    {
        private readonly string path = "";
        public ServiceClient(string path) {
            this.path = path;
        }
        public (bool IsError, string message) RegisterClient(Client client)
        {
            RepositoryClient repo = new RepositoryClient(path);

            ReturnResultClient result = repo.CreateClient(client);
            return (result.IsError, result.Exception!=null ? result.Exception.Message:"");
        }

        public Client AuthorizationClient(Client client)
        {
            RepositoryClient repo = new RepositoryClient(path);
            ReturnResultClient result = repo.GetClient(client.Email, client.Password);

            return result.Client;
        }
    }
}
