using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Familiar")]
    public class Familiar
    {
        [Key]
        public int familiarId { get; set; }

        [Required(ErrorMessage ="Se requiere el nombre del familiar")]
        [Display(Name ="Familiar")]
        public string nombre { get; set; }

        [Required(ErrorMessage ="Se requiere el apellido del familiar")]
        [Display(Name ="Familiar")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Se requiere la cédula del familiar")]
        [Display(Name = "Familiar")]
        public string cedula { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int pacienteId { get; set; }

        public virtual Paciente Pacientes { get; set; }
    }
}