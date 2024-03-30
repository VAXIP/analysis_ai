using AngleSharp.Css.Dom;

namespace Assistant.Applications.DTO;

/// <summary>
/// Represents the response data analysis DTO.
/// </summary>
public class ResponseDataAnalysisDTO
{
    /// <summary>
    /// Gets or sets the data analysis.
    /// </summary>
    public required string DataAnalysis { get; set; }

    /// <summary>
    /// Gets or sets the data report.
    /// </summary>
    public required object DataReport { get; set; }

    /// <summary>
    /// Gets or sets the raw data. 
    /// </summary>
    public required string DataRaw { get; set; }
}
