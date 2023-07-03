using Microsoft.AspNetCore.Mvc;
using SugerenciasMacEV.Models;
using SugerenciasMacEV.Services;

namespace SugerenciasMacEV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ISugerenciaService _sugerenciaService;

        public ApiController(ISugerenciaService sugerenciaService)
        {
            _sugerenciaService = sugerenciaService;
        }

    }
}
