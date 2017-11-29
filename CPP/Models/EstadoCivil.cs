using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("EstadosCiviles")]
    public class EstadoCivil
    {
        [Key]
        public int estadoCivilId { get; set; }

        [Required(ErrorMessage="Se requiere el estado civil")]
        [Display(Name = "Estado Civil")]
        public string nombre { get; set; }
    }
}