using System.ComponentModel.DataAnnotations;

namespace SugerenciasMacEV.Models
{
    public class Modelo
    {
        [Key]
        public int ModeloId { get; set; } // Clave primaria
        public int Serie { get; set; } // Variable de serie

        // Resto de las propiedades
        public string NombreModelo { get; set; }
        public int Autonomia { get; set; }
        public string Motor { get; set; }
        public double PesoSoportado { get; set; }

        public ICollection<Informe> Informes { get; set; } // Propiedad de navegación
    }
}
