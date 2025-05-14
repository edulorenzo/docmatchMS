namespace docmatchMS.Shared.Models;

public class FileMetadata
{
    public string FileName { get; set; }
    public string FileType { get; set; }
    public long FileSize { get; set; }
    public DateTime UploadedAt { get; set; }
}