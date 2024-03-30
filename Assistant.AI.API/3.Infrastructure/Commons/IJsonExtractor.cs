
namespace Assistant.Infrastructure.Commons;

/// <summary>
/// Represents an interface for extracting analysis and JSON data from a given text.
/// </summary>
public interface IJsonExtractor
{
    /// <summary>
    /// Extracts the analysis result and JSON data from the provided full text using the specified JSON start indicator.
    /// </summary>
    /// <param name="fullText">The full text from which to extract the analysis result and JSON data.</param>
    /// <param name="jsonStartIndicator">The indicator that marks the start of the JSON data.</param>
    /// <returns>An instance of the InternalAnalysisResultDto containing the extracted analysis result and JSON data.</returns>
    InternalAnalysisResultDto ExtractAnalysisAndJson<TDto>(string fullText, string jsonStartIndicator);
}
