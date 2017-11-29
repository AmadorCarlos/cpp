using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPP.Models
{
    [Table("TiposExamen")]
    public class TipoExamen
    {
        [Key]
        public int tipoExamenId { get; set; }

        [Required(ErrorMessage = "Se requiere el tipo de examen")]
        [Display(Name = "Tipo de examen")]
        public string nombre { get; set; }
    

    public List<TipoExamen> Listar(int pageIndex, int pageSize, out int pageCount)
    {
        List<TipoExamen> tipos = new List<TipoExamen>();
        using (SqlConnection conexion = new SqlConnection("server=FRANCELLAZT;database=CPPCM;user=sa;password=123"))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand("TipoExamenListar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 0;
                comando.Parameters.AddWithValue("@pageIndex", pageIndex);
                comando.Parameters.AddWithValue("@pageSize", pageSize);
                comando.Parameters.AddWithValue("@pageCount", 0).Direction = ParameterDirection.Output;
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader != null)
                    {
                        TipoExamen tipo = null;
                        while (reader.Read())
                        {
                            tipo = new TipoExamen();
                            tipo.tipoExamenId = (int)reader["tipoExamenId"];
                            tipo.nombre = reader["nombre"].ToString();
                            tipos.Add(tipo);
                        }
                    }
                }

                pageCount = (int)comando.Parameters["@pageCount"].Value;
            }
        }
        return tipos;
    }
  }

}