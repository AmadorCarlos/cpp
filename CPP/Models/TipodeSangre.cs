using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("TiposdeSangre")]
    public class TipodeSangre
    {
        [Key]
        public int tipoSangreId { get; set; }

        [Required(ErrorMessage ="Se requiere el tipo de sangre")]
        [Display(Name ="Tipo de Sangre")]
        public string nombre { get; set; }
    }
}