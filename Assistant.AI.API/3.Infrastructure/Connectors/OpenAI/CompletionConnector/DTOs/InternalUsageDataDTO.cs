namespace Assistant.Connector.DTO
{
    /// <summary>
    /// Represents the internal usage data for a completion request.
    /// </summary>
    public class InternalUsageDataDTO
    {
        /// <summary>
        /// Gets or sets the number of tokens in the prompt.
        /// </summary>
        public int PromptTokens { get; set; }

        /// <summary>
        /// Gets or sets the number of tokens in the completion.
        /// </summary>
        public int CompletionTokens { get; set; }

        /// <summary>
        /// Gets or sets the total number of tokens in the request.
        /// </summary>
        public int TotalTokens { get; set; }
    }
}
