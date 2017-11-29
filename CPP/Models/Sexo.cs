using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Sexo")]
    public class Sexo
    {
        [Key]
        public int sexoId { get; set; }

        [Required(ErrorMessage = "Se requiere el sexo")]
        [Display(Name = "Sexo")]
        public string nombre { get; set; }
    }
}