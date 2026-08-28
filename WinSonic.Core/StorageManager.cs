namespace WinSonic.Core;

public class StorageManager
{
#if DEBUG
    private const string APPLICATION_BASE_FOLDER = "WinSonic_Debug";
#else
    private const string APPLICATION_BASE_FOLDER = "WinSonic";
#endif
    private const string SONGS_FOLDER = "SongsCache";
    private const string ARTWORK_FOLDER = "ArtworkCache";
    private const string LOGS_FOLDER = "Logs";
    private const string DATABASE_NAME = "WinSonicDb.db";

    private string GetBaseFolder() =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            APPLICATION_BASE_FOLDER
        );

    private string GetSongsFolder() => Path.Combine(GetBaseFolder(), SONGS_FOLDER);

    private string GetArtworkFolder() => Path.Combine(GetBaseFolder(), ARTWORK_FOLDER);
    
    public string GetDatabaseFile() => EnsureDbFileExists(Path.Combine(GetBaseFolder(), DATABASE_NAME));
    
    public string GetLogsDirectory() => Path.Combine(GetBaseFolder(), LOGS_FOLDER);

    private string EnsureDbFileExists(string fileName)
    {
        var fileInfo = new FileInfo(fileName);

        if (!fileInfo.Exists)
        {
            fileInfo.Create();
        }

        return fileName;
    }
    
    public void EnsureDirectoriesExist()
    {
        Directory.CreateDirectory(GetBaseFolder());
        Directory.CreateDirectory(GetSongsFolder());
        Directory.CreateDirectory(GetArtworkFolder());
    }

    public FileStream OpenSongFile(string fileName)
    {
        return OpenFileInFolder(GetSongsFolder(), fileName, false);
    }

    public FileStream OpenArtworkFile(string fileName)
    {
        return OpenFileInFolder(GetArtworkFolder(), fileName, false);
    }

    private void SaveFile(
        string fileName,
        string folder,
        Stream stream
    )
    {
        var fileStream = OpenFileInFolder(folder, fileName, true);
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

    private FileStream OpenFileInFolder(string folderPath, string fileName, bool writable)
    {
        var filePath = Path.Combine(folderPath, fileName);
        return new FileStream(filePath, writable ? FileMode.OpenOrCreate : FileMode.Open, writable ? FileAccess.ReadWrite : FileAccess.Read);
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
