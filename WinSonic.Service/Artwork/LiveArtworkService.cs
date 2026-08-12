using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.DbModels;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Service.Artwork;

public class LiveArtworkService : IArtworkService
{
    private readonly BaseDataContext _dataContext;
    private readonly SubsonicApiWrapper _api;

    public LiveArtworkService(
        BaseDataContext dataContext,
        SubsonicApiWrapper api
    )
    {
        _dataContext = dataContext;
        _api = api;
    }

    public async Task<Stream> GetArtworkAsync(
        string coverArtId,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        var api = _api.MediaRetrieval;
        var result = api.GetCoverArtWithHttpInfo(coverArtId);
        return result.Data;
    }

    public async Task<Stream> GetArtworkWithDimensionAsync(
        string coverArtId,
        int dimension,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        var api = _api.MediaRetrieval;
        return await api.GetCoverArtAsync(coverArtId, dimension, cancellationToken: cancellationToken);
    }
}
