namespace Assistant.Connector.Services;

/// <summary>
/// Represents a connector for interacting with the OpenAI Completion API.
/// </summary>
public class OpenAICompletionConnector : IOpenAICompletionConnector
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenAICompletionConnector"/> class.
    /// </summary>
    /// <param name="setting">The API settings.</param>
    public OpenAICompletionConnector(IOptions<OpenAIDTO> setting)
    {
        httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
        httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", setting.Value.OrganizationId);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.Value.ApiKey);
    }

    /// <summary>
    /// Sends a completion request to the OpenAI API.
    /// </summary>
    /// <param name="prompt">The prompt for the completion.</param>
    /// <param name="contentStr">The content string for the completion.</param>
    /// <param name="model">The model to use for the completion. Default is "gpt-3.5-turbo-0125".</param>
    /// <returns>The response from the OpenAI API.</returns>
    public async Task<ResponseChatCompletion> CompletionAsync(string prompt, string contentStr, string model = "gpt-3.5-turbo-0125")
    {
        try
        {
            var requestBody = new
            {
                model,
                messages = new[]
                {
                    new {
                        role = "system",
                        content = prompt
                    },
                    new {
                        role = "user",
                        content = contentStr
                    }
                }
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}. Detalles: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var aiResponse = JsonSerializer.Deserialize<ResponseChatCompletion>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return aiResponse!;
        }
        catch (HttpRequestException ex)
        {
            // Handle HTTP exceptions
            throw new ApplicationException($"Error al crear el hilo: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            // Handle other types of exceptions
            throw new ApplicationException($"Error inesperado: {ex.Message}", ex);
        }
    }
}
