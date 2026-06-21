namespace WinSonic.Core;

public class StorageManager
{
    private const string APPLICATION_BASE_FOLDER = "WinSonic";
    private const string SONGS_FOLDER = "SongsCache";
    private const string ARTWORK_FOLDER = "ArtworkCache";

    private string GetBaseFolder() =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            APPLICATION_BASE_FOLDER
        );

    private string GetSongsFolder() => Path.Combine(GetBaseFolder(), SONGS_FOLDER);

    private string GetArtworkFolder() => Path.Combine(GetBaseFolder(), ARTWORK_FOLDER);

    public void EnsureDirectoriesExist()
    {
        Directory.CreateDirectory(GetBaseFolder());
        Directory.CreateDirectory(GetSongsFolder());
        Directory.CreateDirectory(GetArtworkFolder());
    }

    public FileStream OpenSongFile(string fileName)
    {
        return OpenFileInFolder(GetSongsFolder(), fileName);
    }

    public FileStream OpenArtworkFile(string fileName)
    {
        return OpenFileInFolder(GetArtworkFolder(), fileName);
    }

    private void SaveFile(
        string fileName,
        string folder,
        Stream stream
    )
    {
        var fileStream = OpenFileInFolder(folder, fileName);
        stream.CopyTo(fileStream);
        fileStream.SetLength(fileStream.Position); // Truncate if the new content is smaller than the old content
        fileStream.Close();
    }

    public void SaveSongFile(
        string fileName,
        Stream stream
    )
    {
        SaveFile(fileName, GetSongsFolder(), stream);
    }

    public void SaveArtworkFile(
        string fileName,
        Stream stream
    )
    {
        SaveFile(fileName, GetArtworkFolder(), stream);
    }

    private FileStream OpenFileInFolder(string folderPath, string fileName)
    {
        var filePath = Path.Combine(folderPath, fileName);
        return new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    }

    private FileInfo GetFileInfo(string fileName, string folder)
    {
        var filePath = Path.Combine(folder, fileName);
        return new FileInfo(filePath);
    }

    public FileInfo GetSongFileInfo(string fileName)
    {
        return GetFileInfo(fileName, GetSongsFolder());
    }
}
