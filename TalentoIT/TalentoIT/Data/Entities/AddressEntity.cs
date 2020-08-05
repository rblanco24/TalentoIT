using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentoIT.Data.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
    }
}
