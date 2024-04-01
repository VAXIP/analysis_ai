namespace Assistant.Applications.Interfaces
{
    /// <summary>
    /// Defines the contract for services that interact with the AI assistant.
    /// This interface includes methods for sending messages to the AI, retrieving conversation threads,
    /// and deleting threads as needed.
    /// </summary>
    /// <remarks>
    /// Implementing this interface allows for a decoupled and flexible design, 
    /// enabling different implementations of AI assistant services that can be easily interchanged or modified.
    /// </remarks>
    public interface IAssistantSalesAnalysisService
    {
        /// <summary>
        /// Retrieves the sales analysis data for a given date range asynchronously.
        /// </summary>
        /// <param name="dateInit">The start date of the analysis.</param>
        /// <param name="dateEnd">The end date of the analysis.</param>
        /// <returns>The sales analysis data as a <see cref="ResponseDataAnalysisDTO"/>.</returns>
        Task<ResponseDataAnalysisDTO> GetSaleAnalysisAsync(string dateInit, string dateEnd);

        /// <summary>
        /// Retrieves the sales analysis data for a given date range asynchronously using a stream.
        /// </summary>
        /// <param name="dateInit">The start date of the analysis.</param>
        /// <param name="dateEnd">The end date of the analysis.</param>
        /// <returns>The sales analysis data as a string.</returns>
        IAsyncEnumerable<string> GetSaleAnalysisWithStreamAsync(string dateInit, string dateEnd);
    }
}
