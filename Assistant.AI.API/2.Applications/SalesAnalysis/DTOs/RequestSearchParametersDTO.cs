 
namespace Assistant.Applications.DTO
{
    /// <summary>
    /// Represents the request search parameters for sales analysis.
    /// </summary>
    public class RequestSearchParametersDTO
    {
        /// <summary>
        /// Gets or sets the initial date for the search.
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid date format. The date should be in the format 'yyyy-MM-dd'.")]
        public string DateInit { get; set; } = null!;

        /// <summary>
        /// Gets or sets the end date for the search.
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid date format. The date should be in the format 'yyyy-MM-dd'.")]
        public string DateEnd { get; set; } = null!;
    }
}