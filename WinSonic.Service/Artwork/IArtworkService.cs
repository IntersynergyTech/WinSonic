using WinSonic.Data.DbModels;

namespace WinSonic.Service.Artwork;

public interface IArtworkService
{
    public Task<Stream> GetArtworkAsync(
        string coverArtId,
        bool acceptAnyCached = true,
        CancellationToken cancellationToken = default
    );

    public Task<Stream> GetArtworkWithDimensionAsync(
        string coverArtId,
        int dimension,
        bool acceptAnyCached = false,
        CancellationToken cancellationToken = default
    );
}
