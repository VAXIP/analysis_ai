namespace Assistant.Applications.DTO;

/// <summary>
/// Represents the internal analysis result data transfer object.
/// </summary>
public class InternalAnalysisResultDto
{
    /// <summary>
    /// Gets or sets the analysis text.
    /// </summary>
    public string AnalysisText { get; set; } = null!;

    /// <summary>
    /// Gets or sets the JSON data.
    /// </summary>
    public object JsonData { get; set; } = null!;
}