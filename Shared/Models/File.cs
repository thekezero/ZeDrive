using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

/// <summary>
///     Represents a virtual file stored in ZeDrive. Includes encrypted metadata, virtual path structure, chunk
///     distribution, and status information.
/// </summary>
[Serializable]
public class File
{
    ///<summary>Unique identifier for the file.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    ///<summary>File folder identifier.</summary>
    [JsonPropertyName("folder_id")]
    public Guid FolderId { get; set; } = Guid.NewGuid();

    ///<summary>Encrypted file name (Base64), encrypted with the master key of the Storage Space.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    ///     Encrypted hash of the original file content (Base64), used for integrity verification.<br />
    ///     Encrypted with the master key of the Storage Space.
    /// </summary>
    [JsonPropertyName("file_hash")]
    public string FileHash { get; set; } = string.Empty;

    /// <summary>
    ///     Encrypted master key of the file (Base64), which is used to decrypt the file content.<br />
    ///     This key is encrypted using the master key of the Storage Space or Folder (for sharing).
    /// </summary>
    [JsonPropertyName("master_key")]
    public string MasterKey { get; set; } = string.Empty;

    /// <summary>Total size of the file in bytes.</summary>
    [JsonPropertyName("file_size")]
    public ulong FileSize { get; set; } = 0;

    ///<summary>List of chunks that compose the file, allowing distributed and resumable uploads.</summary>
    [JsonPropertyName("chunks")]
    public List<Chunk> Chunks { get; set; } = [];

    ///<summary>Indicates whether the file upload process is completed.</summary>
    [JsonPropertyName("is_completed")]
    public bool IsCompleted { get; set; } = false;

    ///<summary>Timestamp when the file was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Timestamp when the file was last modified.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}