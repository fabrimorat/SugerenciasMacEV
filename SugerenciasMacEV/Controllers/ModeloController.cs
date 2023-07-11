using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SugerenciasMacEV.Services;

[ApiController]
[Route("api/informe")]

[EnableCors("AllowOrigin")]
public class ModeloController : ControllerBase
{
    private readonly ISugerenciaService _sugerenciaService;

    public ModeloController(ISugerenciaService sugerenciaService)
    {
        _sugerenciaService = sugerenciaService;
    }

    [HttpGet]
    public IActionResult GetInformes()
    {
        var informes = _sugerenciaService.ObtenerInformesEnStock();
        return Ok(informes);
    }
}
