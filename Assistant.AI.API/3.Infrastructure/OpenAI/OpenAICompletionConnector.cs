

namespace Assistant.Connector.Services;

/// <summary>
/// Represents a connector for interacting with the OpenAI Completion API.
/// </summary>
public class OpenAICompletionConnector : IOpenAICompletionConnector
{
    /// <summary>
    /// The HTTP client used for making requests to the OpenAI API.
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenAICompletionConnector"/> class.
    /// </summary>
    /// <param name="setting">The API settings.</param>
    public OpenAICompletionConnector()
    {
        _httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromMinutes(5)
        };

    }

    /// <summary>
    /// Sends a completion request to the OpenAI API.
    /// </summary>
    /// <param name="prompt">The prompt for the completion.</param>
    /// <param name="contentStr">The content string for the completion.</param>
    /// <param name="model">The model to use for the completion. Default is "gpt-3.5-turbo-0125".</param>, OpenAIModel model = OpenAIModel.Gpt3_5_Turbo_0125
    /// <returns>The response from the OpenAI API.</returns>
    public async IAsyncEnumerable<string> CompletionWithStreamAsync(string prompt, string contentStr)
    {

        using var api = new OpenAIClient(client: _httpClient);
        var messages = new List<Message>
        {
            new(Role.System, prompt),
            new(Role.User, contentStr)
        };
        var cumulativeDelta = string.Empty;
        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo, responseFormat: ChatResponseFormat.Text);

        await foreach (var partialResponse in api.ChatEndpoint.StreamCompletionEnumerableAsync(chatRequest))
        {
            foreach (var choice in partialResponse.Choices.Where(choice => choice.Delta?.Content != null))
            {
                yield return choice.Delta.Content;
            }
        }

    }

    /// <summary>
    /// Sends a completion request to the OpenAI API and returns the first choice from the response.
    /// </summary>
    /// <param name="prompt">The prompt message for the AI assistant.</param>
    /// <param name="contentStr">The content message from the user.</param>
    /// <returns>The first choice from the AI assistant's response.</returns>
    public async Task<Choice> CompletionAsync(string prompt, string contentStr)
    {

        using var api = new OpenAIClient(client: _httpClient);
        var messages = new List<Message>
        {
            new(Role.System, prompt),
            new(Role.User, contentStr)
        };
        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
        var choice = response.FirstChoice;
        // Log the response from the AI assistant
        return choice;
    }
}