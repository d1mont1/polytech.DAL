using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polytech.DAL.model
{
    public class Addres
    {
        public int Id;
        public DateTime CreationDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string StreetName { get; set; }
        public string House { get; set; }

    }
}
