using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Servicios")]
    public class Servicio
    {
        [Key]
        public int servicioId { get; set; }

        [Required(ErrorMessage="Se requiere el nombre del servicio")]
        [Display(Name="Nombre")]
        public string nombre { get; set; }
        
    }
}