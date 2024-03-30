namespace Assistant.Connector.DTO
{
    /// <summary>
    /// Represents the details of an internal message.
    /// </summary>
    public class InternalMessageDetailsDTO
    {
        /// <summary>
        /// Gets or sets the role of the message.
        /// </summary>
        public required string Role { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public required string Content { get; set; }
    }
}
