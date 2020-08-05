﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TalentoIT.Data.Entities
{
    public class CandidatoEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        
        public string phone { get; set; }
        public string website { get; set; }
       

    }
}
