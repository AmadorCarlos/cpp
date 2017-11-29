using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Tratamientos")]
    public class Tratamiento
    {
        [Key]
        public int tratamientoId { get; set; }

        [Required(ErrorMessage = "Se requiere la descripción del tratamiento")]
        [Display(Name = "Tratamiento")]
        public string descripcion { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int idPaciente { get; set; }
        [ForeignKey("Medicos")]
        public int idMedico { get; set; }

        public virtual Paciente Pacientes { get; set; }
        public virtual Medico Medicos { get; set; }
    }
}