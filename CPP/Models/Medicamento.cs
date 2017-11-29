using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        [Key]
        public int medicamentoId { get; set; }

        [Required(ErrorMessage="Se requiere el nombre del medicamento")]
        [Display(Name="Medicamento")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Se requiere la dosis del medicamento")]
        [Display(Name = "Medicamento")]
        public string dosis { get; set; }
    }
}