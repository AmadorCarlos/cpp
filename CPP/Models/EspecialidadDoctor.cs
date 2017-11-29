using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("EspecialidadesDoctor")]
    public class EspecialidadDoctor
    {
        [Key]
        public int especialidadId { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre de la especialidad")]
        [Display(Name = "Especialidad")]
        public string nombre { get; set; }
    }
}