using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("OcupacionesPaciente")]
    public class OcupacionPaciente
    {
        [Key]
        public int ocupacionId { get; set; }

        [Required(ErrorMessage ="Se requiere el nombre de la ocupación")]
        [Display(Name ="Ocupación")]
        public string nombre { get; set; }
    }
}