namespace Assistant.API.Controllers;

[ApiController]
[EnableCors("ReglasCors")]
[Route("v1/ai/assistant/")]
public class AIAssistantController(IAssistantSalesAnalysisService asistantSalesAnalysisService) : ControllerBase
{
  private readonly IAssistantSalesAnalysisService _asistantSalesAnalysisService = asistantSalesAnalysisService;

  /// <summary>
  /// Retrieves sales analysis based on the specified date range.
  /// </summary>
  /// <param name="dateInit">The start date of the analysis.</param>
  /// <param name="dateEnd">The end date of the analysis.</param>
  /// <returns>An asynchronous task that represents the operation and returns an IActionResult.</returns>
  /// <remarks> The response is an object that contains the sales analysis data.</remarks>
  [HttpGet("getSalesAnality", Name = "getSalesAnality")]
  [SwaggerResponse(200, Type = typeof(ResponseDataAnalysisDTO))]
  public async Task<IActionResult> GetSalesAnality([FromQuery] RequestSearchParametersDTO dto)
  {

    var result = await _asistantSalesAnalysisService.GetSaleAnalysis(dto.DateInit, dto.DateEnd);
 
    return Ok(result);
  }
}
