using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Medicos")]
    public class Medico
    {
        [Key]
        public int medicoId { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre del médico")]
        [Display(Name = "Nombre Medico")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Se requiere el apellido del médico")]
        [Display(Name = "Apellidos Medico")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Se requiere la especialidad del médico")]
        [Display(Name = "Especialidad")]
        public string especialidad { get; set; }

        [Required(ErrorMessage = "Se requiere el código MINSA del médico")]
        [Display(Name = "Código MINSA")]
        public string codigoMinsa { get; set; }

    }
}