using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Examenes")]
    public class Examen
    {
        [Key]
        public int examenId { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int pacienteId { get; set; }

        public virtual Paciente Pacientes { get; set; }
        ////////////////////////////////////////

        [Required(ErrorMessage = "Se requiere la fecha del examen")]
        [Display(Name = "Examen")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre del examen")]
        [Display(Name = "Examen")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Se requiere el tipo de examen")]
        [Display(Name = "Examen")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "Se requiere el resultado del examen")]
        [Display(Name = "Examen")]
        public string resultado { get; set; }
    }
}