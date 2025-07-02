using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

[Serializable]
public class Folder
{
    /// <summary>Unique identifier for this folder.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Encrypted path within the space (base64, encrypted with space key).</summary>
    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>Subfolders inside this folder.</summary>
    [JsonPropertyName("folders")]
    public List<Folder> Folders { get; set; } = [];

    /// <summary>Files stored directly in this folder.</summary>
    [JsonPropertyName("files")]
    public List<File> Files { get; set; } = [];
}