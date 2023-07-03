using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SugerenciasMacEV.Models;
using SugerenciasMacEV.Data;

namespace SugerenciasMacEV.Services
{
    public class SugerenciaService : ISugerenciaService
    {
        private readonly ApplicationDbContext _context;

        public SugerenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarInforme(Informe informe)
        {
            // Verificar si el modelo asociado existe en la base de datos
            var modeloExistente = _context.Modelos.Find(informe.ModeloId);
            if (modeloExistente == null)
            {
                throw new ArgumentException("El modelo asociado no existe");
            }

            _context.Informes.Add(informe);
            _context.SaveChanges();
        }

        public List<Modelo> ObtenerMotosEnStock()
        {
            return _context.Modelos.ToList();
        }

        public Modelo ObtenerMejorSugerencia(double recorridoDiario, double pesoNecesitado, int modeloId)
        {
            var motosFiltradas = _context.Modelos
                .Where(m => m.Autonomia >= recorridoDiario && m.PesoSoportado >= pesoNecesitado)
                .OrderBy(m => m.Autonomia);

            var mejorSugerencia = motosFiltradas.FirstOrDefault();

            var informe = new Informe
            {
                Fecha = DateTime.Now,
                Resultado = "Sugerencia encontrada",
                Detalles = $"Recorrido diario: {recorridoDiario}, Peso necesitado: {pesoNecesitado}",
                ModeloId = modeloId
            };

            _context.Informes.Add(informe);
            _context.SaveChanges();

            return mejorSugerencia;
        }

        public List<Informe> ObtenerInformesPorRangoDeFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Informes
                .Where(r => r.Fecha >= fechaInicio && r.Fecha <= fechaFin)
                .ToList();
        }
    }
}
