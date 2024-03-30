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
        public Task<ResponseDataAnalysisDTO> GetSaleAnalysis(string dateInit, string dateEnd);
    }
}
