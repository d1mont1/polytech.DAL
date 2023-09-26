using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using polytech.DAL.model;


namespace polytech.DAL
{
    public class ReturnResultClient
    {
        public bool IsError { get; set; }
        string Message { get; set; }
        public Exception Exception { get; set; }
        public Client Client{ get; set; }
        public List<Client> Clients { get; set; }
    }
}
