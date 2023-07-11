using Microsoft.AspNetCore.Mvc;
using SugerenciasMacEV.Models;
using SugerenciasMacEV.Services;
using System;
using System.Diagnostics;

namespace SugerenciasMacEV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISugerenciaService _sugerenciaService;

        public HomeController(ISugerenciaService sugerenciaService)
        {
            _sugerenciaService = sugerenciaService; // Inyección de dependencias en el constructor
        }

        public IActionResult IngresarDatos()
        {
            var modelos = _sugerenciaService.ObtenerMotosEnStock(); // Uso de la dependencia inyectada
            return View(modelos);
        }




        public IActionResult Index()
        {
            var modelos = _sugerenciaService.ObtenerMotosEnStock(); // Uso de la dependencia inyectada
            return View(modelos);
        }

        [HttpPost]
        public IActionResult Sugerir(double recorridoDiario, double pesoNecesitado, int modeloId)
        {
            var mejorSugerencia = _sugerenciaService.ObtenerMejorSugerencia(recorridoDiario, pesoNecesitado, modeloId);  // Uso de la dependencia inyectada

            return View(mejorSugerencia);
        }

        [HttpGet]
        public IActionResult MostrarInformes(DateTime fechaInicio, DateTime fechaFin)
        {
            var informes = _sugerenciaService.ObtenerInformesPorRangoDeFechas(fechaInicio, fechaFin);  // Uso de la dependencia inyectada
            return View("MostrarReportes", informes);
        }

        [HttpPost]
        public IActionResult AgregarInforme(Informe informe)
        {
            try
            {
                _sugerenciaService.AgregarInforme(informe);  // Uso de la dependencia inyectada
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                var modelos = _sugerenciaService.ObtenerMotosEnStock();  // Uso de la dependencia inyectada
                ViewBag.Modelos = modelos;
                return View("IngresarDatos");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
