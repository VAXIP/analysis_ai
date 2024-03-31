namespace Assistant.AInfrastructure.Connectors.OpenAI.EnumModels;

public static class OpenAIModelExtensions
{
    /// <summary>
    /// Converts the specified <see cref="OpenAIModel3_5"/> enum value to its corresponding string representation.
    /// </summary>
    /// <param name="model">The <see cref="OpenAIModel3_5"/> enum value to convert.</param>
    /// <returns>The string representation of the <see cref="OpenAIModel3_5"/> enum value.</returns>
    public static string ToModelString(this OpenAIModel model)
    {
        return model switch
        {
            OpenAIModel.Gpt3_5_Turbo_0125 => "gpt-3.5-turbo-0125",
            OpenAIModel.Gpt3_5_Turbo => "gpt-3.5-turbo",
            OpenAIModel.Gpt3_5_Turbo_1106 => "gpt-3.5-turbo-1106",
            OpenAIModel.Gpt4_0125_Preview => "gpt-4-0125-preview",
            OpenAIModel.Gpt4_Turbo_Preview => "gpt-4-turbo-preview",
            OpenAIModel.Gpt4_1106_Preview => "gpt-4-1106-preview",
            _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)

        };
    }

}
