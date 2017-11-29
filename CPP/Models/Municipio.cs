using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Municipios")]
    public class Municipio
    {
        [Key]
        public int municipioId { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre del municipio")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
    }
}