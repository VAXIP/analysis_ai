namespace Assistant.Connector.DTO
{

    public class ResponseChatCompletion
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("object")]
        public string Object { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public long Created { get; set; } = 0;

        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("system_fingerprint")]
        public string SystemFingerprint { get; set; } = string.Empty;

        [JsonPropertyName("choices")]
        public InternalChoiceDTO[] Choices { get; set; } = [];

        [JsonPropertyName("usage")]
        public InternalUsageDataDTO Usage { get; set; } = new InternalUsageDataDTO();
    }

}
