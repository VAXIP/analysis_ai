
namespace Assistant.Connector.Interfaces
{
    /// <summary>
    /// Represents the interface for the OpenAI completion connector.
    /// </summary>
    public interface IOpenAICompletionConnector
    {
        /// <summary>
        /// Sends a completion request to the OpenAI API.
        /// </summary>
        /// <param name="prompt">The prompt for the completion.</param>
        /// <param name="contentStr">The content string for the completion.</param>
        /// <param name="model">The model to use for the completion. Default is "gpt-3.5-turbo-0125".</param>
        /// <returns>A task that represents the asynchronous completion operation. The task result contains the response from the OpenAI API.</returns>
        IAsyncEnumerable<string> CompletionWithStreamAsync(string prompt, string contentStr);

        /// <summary>
        /// Sends a completion request to the OpenAI API.
        /// </summary>
        /// <param name="prompt">The prompt for the completion.</param>
        /// <param name="contentStr">The content string for the completion.</param>
        /// <param name="model">The model to use for the completion. Default is "gpt-3.5-turbo-0125".</param>
        /// <returns>A task that represents the asynchronous completion operation. The task result contains the response from the OpenAI API.</returns>
        Task<Choice> CompletionAsync(string prompt, string contentStr);
    }
}