using System.ComponentModel.DataAnnotations;

namespace SugerenciasMacEV.Models
{
    public class Informe
    {
        [Key]
        public int InformeId { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        public string Detalles { get; set; }

        public int ModeloId { get; set; } // Propiedad para la clave foránea

        public Modelo Modelo { get; set; } // Propiedad de navegación

    }
}
