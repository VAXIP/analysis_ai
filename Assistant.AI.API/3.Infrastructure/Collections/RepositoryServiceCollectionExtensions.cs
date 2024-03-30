
namespace Assistant.Collection.Extensions;

/// <summary>
/// Provides extension methods for adding scoped collections to the <see cref="IServiceCollection"/>.
/// </summary>
public static class RepositoryServiceCollectionExtensions
{
    /// <summary>
    /// Adds the scoped collection services to the <see cref="IServiceCollection"/>.
    /// /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service descriptors to.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddScopedCollections(this IServiceCollection services)
    {
        services.AddScoped<IOpenAICompletionConnector, OpenAICompletionConnector>();
        services.AddScoped<IAssistantSalesAnalysisService, AssistantSalesAnalysisService>();
        services.AddScoped<ISalesRecordRepository, SalesRecordRepository>();
        services.AddScoped<IJsonExtractor, JsonExtractor>();

        return services;
    }
}