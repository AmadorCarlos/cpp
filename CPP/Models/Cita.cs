using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Citas")]
    public class Cita
    {
        [Key]
        public int citaId { get; set; }

        [Required(ErrorMessage = "Se requiere la fecha de la cita")]
        [Display(Name = "Fecha")]
        public DateTime fechaCita { get; set; }
        
        //////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int idPaciente { get; set; }

        [ForeignKey("Medicos")]
        public int idMedico { get; set; }

        [ForeignKey("Consultas")]
        public int idConsulta { get; set; }

        public virtual Paciente Pacientes { get; set; }
        public virtual Medico Medicos { get; set; }
        public virtual Consulta Consultas { get; set; }
    }
}