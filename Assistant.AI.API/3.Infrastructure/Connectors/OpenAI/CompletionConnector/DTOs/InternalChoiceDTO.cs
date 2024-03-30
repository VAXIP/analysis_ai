namespace Assistant.Connector.DTO
{
    /// <summary>
    /// Represents the data transfer object for an internal choice in the Assistant Connector.
    /// </summary>
    public class InternalChoiceDTO
    {
        /// <summary>
        /// Gets or sets the index of the internal choice.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the details of the internal message.
        /// </summary>
        public InternalMessageDetailsDTO? Message { get; set; }

        /// <summary>
        /// Gets or sets the log probabilities of the internal choice.
        /// </summary>
        public object Logprobs { get; set; } = new object();

        /// <summary>
        /// Gets or sets the reason for finishing the internal choice.
        /// </summary>
        public string FinishReason { get; set; } = string.Empty;
    }
}
