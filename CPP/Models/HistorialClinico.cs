using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("HistorialesClinicos")]
    public class HistorialClinico
    {
        [Key]
        public int historialId { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int idPaciente { get; set; }
        [ForeignKey("Enfermedades")]
        public int idEnfermedad { get; set; }
        [ForeignKey("Medicamentos")]
        public int idMedicamento { get; set; }
        [ForeignKey("Tratamientos")]
        public int idTratamiento { get; set; }
        [ForeignKey("Citas")]
        public int idCita { get; set; }

        public virtual Paciente Pacientes { get; set; }
        public virtual Enfermedad Enfermedades { get; set; }
        public virtual Medicamento Medicamentos { get; set; }
        public virtual Tratamiento Tratamientos { get; set; }
        public virtual Cita Citas { get; set; }
        ////////////////////////////////////////
        
        public string observaciones { get; set; }
        
    }
}