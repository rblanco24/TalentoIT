using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TalentoIT.Data.Entities
{
    public class CandidatoEntity
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "El {0} no puede ser menor a un {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "El {0} no puede ser menor a un {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "El {0} no puede ser menor a un {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Correo { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "El {0} no puede ser menor a un {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string SitioWeb { get; set; }
        public string Compañia { get; set; }

    }
}
