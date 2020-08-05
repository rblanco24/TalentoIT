using System;
using System.ComponentModel.DataAnnotations;

namespace TalentoIT.Data.Entities
{
    public class EntrevistaEntity
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "El {0} no puede ser menor a un {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaHora { get; set; }

        public string Tipo { get; set; }
    }
}
