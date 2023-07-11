using System;
using System.Collections.Generic;
using SugerenciasMacEV.Models;

namespace SugerenciasMacEV.Services
{
    public interface ISugerenciaService
    {
        List<Modelo> ObtenerMotosEnStock();

        List<Informe> ObtenerInformesEnStock();
        Modelo ObtenerMejorSugerencia(double recorridoDiario, double pesoNecesitado, int modeloId);

        void AgregarInforme(Informe informe);

        List<Informe> ObtenerInformesPorRangoDeFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}
