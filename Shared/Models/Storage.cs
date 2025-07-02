using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

///<summary>Represents a user's file storage.</summary>
[Serializable]
public class Storage
{
    ///<summary>Unique identifier of the storage.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    ///<summary>The main space stored by the user.</summary>
    [JsonPropertyName("space")]
    public Space Space { get; set; } = new();

    ///<summary>List of spaces stored by the user.</summary>
    [JsonPropertyName("spaces")]
    public List<Space> Spaces { get; set; } = [];

    ///<summary>Date and time when the storage was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    ///<summary>Date and time when the storage was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}