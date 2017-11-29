using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        public int pacienteId { get; set; }

        [Required(ErrorMessage= "Se requiere el nombre del paciente")]
        [Display(Name="Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Se requiere el apellido del paciente")]
        [Display(Name = "Apellidos")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Se requiere la edad del paciente")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNac{ get; set; }

        [ForeignKey("Sexo")]
        public int idSexo { get; set; }
        public virtual Sexo Sexo { get; set; }
        ////////////////////////////////////////

        [Required(ErrorMessage = "Se requiere la cédula del paciente")]
        [Display(Name = "Cédula de Identidad")]
        public string cedula { get; set; }

        [ForeignKey("OcupacionesPaciente")]
        public int idOcupacion { get; set; }
        public virtual OcupacionPaciente OcupacionesPaciente { get; set; }
        ////////////////////////////////////////

        [Required(ErrorMessage = "Se requiere el teléfono del paciente")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [ForeignKey("EstadosCiviles")]
        public int idEstadoCivil { get; set; }
        public virtual EstadoCivil EstadosCiviles { get; set; }
        ////////////////////////////////////////

        [ForeignKey("Departamentos")]
        public int idDepartamento { get; set; }
        public virtual Departamento Departamentos { get; set; }

        [ForeignKey("Municipios")]
        public int idMunicipio { get; set; }
        public virtual Municipio Municipios { get; set; }

        [ForeignKey("TiposdeSangre")]
        public int idTipoSangre { get; set; }
        public virtual TipodeSangre TiposdeSangre { get; set; }
        ////////////////////////////////////////

        [Required(ErrorMessage = "Se requiere el domicilio del paciente")]
        [Display(Name = "Domicilio")]
        public string domicilio { get; set; }

        public string observaciones { get; set; }
    }
}