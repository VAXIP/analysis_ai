namespace Assistant.Connector.DTO
{
    /// <summary>
    /// Represents the settings for the API connection.
    /// </summary>
    public class OpenAIDTO
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public required string ApiKey { get; set; }
        
        /// <summary>
        /// Gets or sets the organization ID.
        /// </summary>
        public required string OrganizationId { get; set; }
 
    }
}
