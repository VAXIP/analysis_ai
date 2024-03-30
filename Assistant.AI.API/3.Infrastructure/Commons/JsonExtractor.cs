

namespace Assistant.Infrastructure.Commons;

/// <summary>
/// Represents a service for sales analysis in the Assistant application.
/// </summary>
public class JsonExtractor : IJsonExtractor
{
    /// <summary>
    /// Extracts and parses a JSON string from the provided full text.
    /// </summary>
    /// <param name="fullText">The full text containing the JSON string.</param>
    /// <param name="jsonStartIndicator">The indicator that marks the start of the JSON string.</param>
    /// <returns>The parsed JSON object as a <see cref="JObject"/> or null if parsing fails.</returns>
    public InternalAnalysisResultDto ExtractAnalysisAndJson<TDto>(string fullText, string jsonStartIndicator)
    {
        // Encontrar el inicio del JSON
        int startIndex = fullText.IndexOf(jsonStartIndicator);

        if (startIndex == -1)
        {
            Console.WriteLine("Indicador de inicio de JSON no encontrado.");
            return null!; // O manejar de otra manera
        }

        // Extraer el texto de análisis
        string analysisText = fullText.Substring(0, startIndex).Trim();

        // Ajustar el startIndex para que comience exactamente donde inicia el JSON
        startIndex += jsonStartIndicator.Length;

        // Extraer el substring que contiene el JSON
        string jsonString = fullText.Substring(startIndex).Trim();

        string startPattern = "```json";
        string endPattern = "```";
        if (jsonString.StartsWith(startPattern))
        {
            jsonString = jsonString[startPattern.Length..]; // Elimina el patrón de inicio
        }
        if (jsonString.EndsWith(endPattern))
        {
            jsonString = jsonString[..^endPattern.Length]; // Elimina el patrón de final
        }

        jsonString = jsonString.Trim(); // Elimina espacios en blanco adicionales

        // Intentar parsear el JSON
        TDto jsonObject = default!;
        try
        {
            jsonObject = JsonSerializer.Deserialize<TDto>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            Console.WriteLine("JSON parseado con éxito.");
        }
        catch (JsonException e)
        {
            Console.WriteLine("Error al parsear JSON: " + e.Message);
        }
        // Crear y devolver el DTO con ambos elementos
        return new InternalAnalysisResultDto
        {
            AnalysisText = analysisText,
            JsonData = jsonObject
        };
    }
}
