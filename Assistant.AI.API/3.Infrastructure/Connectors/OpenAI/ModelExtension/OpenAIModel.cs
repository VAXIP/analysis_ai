namespace Assistant.AInfrastructure.Connectors.OpenAI.EnumModels;

/// <summary>
/// Represents the available models for OpenAIModel.
/// </summary>

public enum OpenAIModel
{
    /// <summary>
    /// New Updated GPT 3.5 Turbo model with higher accuracy at responding in requested formats.
    /// </summary>
    /// <remarks>
    /// This model addresses a text encoding issue for non-English language function calls and returns a maximum of 4,096 output tokens.
    /// Context window: 16,385 tokens. Training data up to Sep 2021.
    /// </remarks>
    Gpt3_5_Turbo_0125,

    /// <summary>
    /// Alias for GPT-3.5 Turbo 0125 model.
    /// </summary>
    /// <remarks>
    /// Currently points to Gpt3_5_Turbo_0125 model. Context window: 16,385 tokens. Training data up to Sep 2021.
    /// </remarks>
    Gpt3_5_Turbo,

    /// <summary>
    /// GPT-3.5 Turbo model with improved instruction following and reproducible outputs.
    /// </summary>
    /// <remarks>
    /// Features JSON mode, parallel function calling, and returns a maximum of 4,096 output tokens. Context window: 16,385 tokens. Training data up to Sep 2021.
    /// </remarks>
    Gpt3_5_Turbo_1106,

    // Añade descripciones similares para los modelos restantes siguiendo el patrón anterior

    /// <summary>
    /// New GPT-4 Turbo model intended to reduce cases of "laziness."
    /// </summary>
    /// <remarks>
    /// This model is the latest GPT-4 version with a focus on completing tasks efficiently and returns a maximum of 4,096 output tokens.
    /// Context window: 128,000 tokens. Training data up to Dec 2023.
    /// </remarks>
    Gpt4_0125_Preview,

    /// <summary>
    /// Alias for GPT-4 0125 Preview model.
    /// </summary>
    /// <remarks>
    /// Currently points to Gpt4_0125_Preview. Context window: 128,000 tokens. Training data up to Dec 2023.
    /// </remarks>
    Gpt4_Turbo_Preview,

    /// <summary>
    /// GPT-4 Turbo model featuring improved instruction following and JSON mode.
    /// </summary>
    /// <remarks>
    /// Includes reproducible outputs, parallel function calling, and returns a maximum of 4,096 output tokens.
    /// Context window: 128,000 tokens. Training data up to Apr 2023.
    /// </remarks>
    Gpt4_1106_Preview
}
