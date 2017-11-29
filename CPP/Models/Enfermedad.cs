using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Enfermedades")]
    public class Enfermedad
    {
        [Key]
        public int enfermedadId { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre de la enfermedad")]
        [Display(Name = "Enfermedad")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Se requiere la caracterización de la consulta")]
        [Display(Name = "Enfermedad")]
        public string caracterizacion { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int pacienteId { get; set; }

        public virtual Paciente Pacientes { get; set; }
    }
}