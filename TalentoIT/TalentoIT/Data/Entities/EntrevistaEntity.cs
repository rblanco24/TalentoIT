using System;
using System.ComponentModel.DataAnnotations;

namespace TalentoIT.Data.Entities
{
    public class EntrevistaEntity
    {
        public int Id { get; set; }

 
        public DateTime FechaHora { get; set; }

        public string Tipo { get; set; }
    }
}
