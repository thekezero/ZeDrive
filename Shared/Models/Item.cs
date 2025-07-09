using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ZeDrive.Shared.Models;

///<summary>Represents an individual file included in a share, with its encrypted access key.</summary>
[Serializable]
[Index(nameof(MasterKey), IsUnique = true)]
public class Item
{
    ///<summary>Unique identifier of the item entry in the share.</summary>
    [JsonPropertyName("id")]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    ///<summary>ID of the file being shared.</summary>
    [JsonPropertyName("file_id")]
    public Guid FileId { get; set; }

    ///<summary>Master key of the file encrypted by the share master key (base64).</summary>
    [JsonPropertyName("master_key")]
    public string MasterKey { get; set; } = string.Empty;

    ///<summary>Date and time when the item was added to the share.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    ///<summary>Date and time when the item was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}