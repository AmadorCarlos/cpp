using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        public int consultaId { get; set; }

        [Required(ErrorMessage = "Se requiere la fecha de la consulta")]
        [Display(Name = "Fecha de consulta")]
        public DateTime fechaConsulta { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int idPaciente { get; set; }

        [ForeignKey("Medicos")]
        public int idMedico { get; set; }
        
        [ForeignKey("Examenes")]
        public int idExamen { get; set; }
        ////////////////////////////////////////

        [Required(ErrorMessage = "Se requiere un diagnostico")]
        [Display(Name = "Diagnóstico")]
        public string diagnostico { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Tratamientos")]
        public int IdTratamiento { get; set; }
        
        public virtual Paciente Pacientes { get; set; }
        public virtual Medico Medicos { get; set; }
        public virtual Examen Examenes { get; set; }
        public virtual Tratamiento Tratamientos { get; set; }
    }
}