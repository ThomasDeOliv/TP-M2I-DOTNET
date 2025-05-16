using System.Text.Json.Serialization;

namespace MauiSample.Models
{
    public sealed class TaskModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public required string Description { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("priority")]
        public required string Priority { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyName("dueDate")]
        public required DateTimeOffset DueDate { get; set; }
    }
}
