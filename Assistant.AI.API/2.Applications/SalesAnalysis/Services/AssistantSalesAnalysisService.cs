
namespace Assistant.Applications.Services;
/// <summary>
/// Provides services for interacting with the AI assistant and managing conversation threads.
/// It encapsulates the functionality for sending messages, retrieving conversation threads,
/// and deleting threads when necessary.
/// </summary>
/// <remarks>
/// This service uses an instance of IOpenAIConnector for interactions with the AI and IUnitOfWork for database operations.
/// It ensures that the conversation threads are managed efficiently and consistently across the application.
/// </remarks>
public partial class AssistantSalesAnalysisService(IOpenAICompletionConnector AIConector, ILogger<AssistantSalesAnalysisService> logger, ISalesRecordRepository salesRecordRepository, IJsonExtractor jsonExtractor) : IAssistantSalesAnalysisService
{
    private readonly IOpenAICompletionConnector _aIConnector = AIConector;

    private readonly ILogger<AssistantSalesAnalysisService> _logger = logger;

    private readonly ISalesRecordRepository _salesRecordRepository = salesRecordRepository;

    private readonly IJsonExtractor _jsonExtractor = jsonExtractor;

    /// <summary>
    /// Retrieves the sales analysis for a given date range.
    /// </summary>
    /// <param name="dateInit">The initial date of the range.</param>
    /// <param name="dateEnd">The end date of the range.</param>
    /// <returns>A <see cref="ResponseDataAnalysisDTO"/> object containing the analysis results and JSON data.</returns>
    /// <exception cref="ArgumentException">Thrown when the initial date is greater than the end date.</exception>
    /// <exception cref="Exception">Thrown when an error occurs while performing the sales analysis.</exception>
    public async Task<ResponseDataAnalysisDTO> GetSaleAnalysisAsync(string dateInit, string dateEnd)
    {
        try
        {
            // Convert the string dates to DateOnly objects
            var dInit = DateOnly.Parse(dateInit);
            var dEnd = DateOnly.Parse(dateEnd);

            // Validate the input parameters
            if (dInit > dEnd)
            {
                throw new ArgumentException("The initial date cannot be greater than the end date.");
            }

            var prompt = $"Análisis de ventas para el rango de fechas: {dateInit:dd/MM/yyyy} - {dateEnd:dd/MM/yyyy}. Tengo un conjunto de datos de ventas que incluye el nombre del producto, categoría, unidades vendidas, precio por unidad, fecha de venta y ubicación de la venta. Con esta información, necesito identificar las siguientes métricas e insights:\n" +
            "1. **Tendencias de ventas**: Identifica cuáles son los productos más vendidos y las categorías de productos con mayor demanda. Observa si hay patrones estacionales o tendencias a lo largo del tiempo en las ventas.\n" +
            "2. **Análisis de rentabilidad**: Determina cuáles son los productos y categorías más rentables basándose en las unidades vendidas y los precios por unidad.\n" +
            "3. **Proyecciones de ventas**: Basándose en los patrones históricos de ventas, realiza proyecciones de ventas para los próximos tres meses. Considera factores estacionales y tendencias de crecimiento.\n" +
            "4. **Recomendaciones de inventario**: Proporciona recomendaciones sobre cómo ajustar los niveles de inventario basándose en las tendencias de ventas y proyecciones. Indica qué productos deberían ser reabastecidos más frecuentemente y cuáles pueden reducirse.\n" +
            "5. **Oportunidades de marketing**: Identifica oportunidades para campañas de marketing específicas, como promociones para productos de bajo rendimiento o destacar productos estrella en publicidad.\n" +
            "Por favor, presenta los resultados y los insights en un formato claro y conciso, listando cada punto de análisis con sus respectivas conclusiones e implicaciones para el negocio, seguido por '#### Resultados en JSON a continuación ####' y luego presenta al final del texto los resultados principales en formato JSON de acuerdo con la siguiente estructura:\n" +
            "- `productosMasVendidos`: [Un objeto que lista los productos más vendidos, con cada producto como clave y las unidades vendidas como valor.]\n" +
            "- `categoriasConMayorDemanda`: [Un objeto que lista las categorías con mayor demanda, con cada categoría como clave y las unidades vendidas como valor.]\n" +
            "- `productosMasRentables`: [Un objeto que lista los productos más rentables, con cada producto como clave y el total de ingresos generados como valor.]\n" +
            "- `categoriasMasRentables`: [Un objeto que lista las categorías más rentables, con cada categoría como clave y el total de ingresos generados como valor.]\n" +
            "El JSON debe estar bien formado y seguir estas especificaciones de estructura.";

            // Search for the data in the database
            var salesRecords = _salesRecordRepository.GetSalesByDateRange(dInit, dEnd);

            var message = JsonSerializer.Serialize(salesRecords);

            // Send a message to the AI assistant for further processing
            var response = await _aIConnector.CompletionAsync(prompt, message) ?? throw new Exception("No response or invalid response from the AI assistant.");

            // Log the response from the AI assistant
            _logger.LogInformation("AI response: {response}", response);

            var contentMessage = response.Message.Content.ToString();
            // Extract the analysis and JSON data from the response
            var analysisResult = _jsonExtractor.ExtractAnalysisAndJson<InternalVentasInfo>(contentMessage, "#### Resultados en JSON a continuación ####") ?? throw new Exception("Error al extraer el análisis y los datos JSON.");

            return new ResponseDataAnalysisDTO
            {
                DataAnalysis = analysisResult.AnalysisText,
                DataReport = analysisResult.JsonData,
                DataRaw = contentMessage
            };

        }
        catch (Exception ex)
        {
            // Log and rethrow the exception
            _logger.LogError(ex, "An error occurred while performing the sales analysis.");
            throw;
        }
    }

    /// <summary>
    /// Retrieves the sales analysis for a given date range.
    /// </summary>
    /// <param name="dateInit">The initial date of the range.</param>
    /// <param name="dateEnd">The end date of the range.</param>
    /// <returns>A <see cref="ResponseDataAnalysisDTO"/> object containing the analysis results and JSON data.</returns>
    /// <exception cref="ArgumentException">Thrown when the initial date is greater than the end date.</exception>
    /// <exception cref="Exception">Thrown when an error occurs while performing the sales analysis.</exception>
    public IAsyncEnumerable<string> GetSaleAnalysisWithStreamAsync(string dateInit, string dateEnd)
    {

        // Convert the string dates to DateOnly objects
        var dInit = DateOnly.Parse(dateInit);
        var dEnd = DateOnly.Parse(dateEnd);

        // Validate the input parameters
        if (dInit > dEnd)
        {
            throw new ArgumentException("The initial date cannot be greater than the end date.");
        }

        var prompt = $"Análisis de ventas para el rango de fechas: {dateInit:dd/MM/yyyy} - {dateEnd:dd/MM/yyyy}. Tengo un conjunto de datos de ventas que incluye el nombre del producto, categoría, unidades vendidas, precio por unidad, fecha de venta y ubicación de la venta. Con esta información, necesito identificar las siguientes métricas e insights:\n" +
        "1. **Tendencias de ventas**: Identifica cuáles son los productos más vendidos y las categorías de productos con mayor demanda. Observa si hay patrones estacionales o tendencias a lo largo del tiempo en las ventas.\n" +
        "2. **Análisis de rentabilidad**: Determina cuáles son los productos y categorías más rentables basándose en las unidades vendidas y los precios por unidad.\n" +
        "3. **Proyecciones de ventas**: Basándose en los patrones históricos de ventas, realiza proyecciones de ventas para los próximos tres meses. Considera factores estacionales y tendencias de crecimiento.\n" +
        "4. **Recomendaciones de inventario**: Proporciona recomendaciones sobre cómo ajustar los niveles de inventario basándose en las tendencias de ventas y proyecciones. Indica qué productos deberían ser reabastecidos más frecuentemente y cuáles pueden reducirse.\n" +
        "5. **Oportunidades de marketing**: Identifica oportunidades para campañas de marketing específicas, como promociones para productos de bajo rendimiento o destacar productos estrella en publicidad.\n" +
        "Por favor, presenta los resultados y los insights en un formato claro y conciso, listando cada punto de análisis con sus respectivas conclusiones e implicaciones para el negocio";

        // Search for the data in the database
        var salesRecords = _salesRecordRepository.GetSalesByDateRange(dInit, dEnd);

        var message = JsonSerializer.Serialize(salesRecords);

        // Send a message to the AI assistant for further processing
        return _aIConnector.CompletionWithStreamAsync(prompt, message) ?? throw new Exception("No response or invalid response from the AI assistant.");

    }

}
