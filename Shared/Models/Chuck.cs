using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

///<summary>Represents a portion of a file that has been split for storage, allowing distribution.</summary>
[Serializable]
public class Chunk
{
    ///<summary>Unique identifier for the chunk. Also used as the object key in the storage bucket.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    ///<summary>Index used to determine where the chunk is distributed across regions or storage nodes.</summary>
    [JsonPropertyName("distribution")]
    public uint Distribution { get; set; } = 0;

    ///<summary>Size of the chunk in bytes.</summary>
    [JsonPropertyName("size")]
    public uint Size { get; set; } = 0;

    ///<summary>Sequence number of the chunk in the file for reassembly.</summary>
    [JsonPropertyName("sequence")]
    public uint Sequence { get; set; } = 0;

    ///<summary>UTC timestamp when the chunk was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    ///<summary>UTC timestamp when the chunk was last modified.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}