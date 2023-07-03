using Microsoft.AspNetCore.Mvc;
using SugerenciasMacEV.Services;

[ApiController]
[Route("api/modelo")]
public class ModeloController : ControllerBase
{
    private readonly ISugerenciaService _sugerenciaService;

    public ModeloController(ISugerenciaService sugerenciaService)
    {
        _sugerenciaService = sugerenciaService;
    }

    [HttpGet]
    public IActionResult GetModelos()
    {
        var modelos = _sugerenciaService.ObtenerMotosEnStock();
        return Ok(modelos);
    }
}
