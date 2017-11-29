using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        public int facturaId { get; set; }

        ////////////////////////////////////////
        [ForeignKey("Pacientes")]
        public int pacienteId { get; set; }
        [ForeignKey("Medicos")]
        public int medicoId { get; set; }
        [ForeignKey("Servicios")]
        public int servicioId { get; set; }

        public virtual Paciente Pacientes { get; set; }
        public virtual Medico Medicos { get; set; }
        public virtual Servicio Servicios { get; set; }
        ////////////////////////////////////////

        [Required(ErrorMessage = "Se requiere la descripción de la factura")]
        [Display(Name = "Factura")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Se requiere el total de la factura")]
        [Display(Name = "total")]
        public double total { get; set; }
    }
}