using System.Diagnostics;

namespace WinSonic.Player.ReplayGain;

public class ReplayGainProcessor
{
    private ReplayGainConfiguration _config;
    private float _currentVolume = 1.0f;
    private float? _currentTrackGain = null;
    private float? _currentAlbumGain = null;
    private float _currentGain = DEFAULT_GAIN;

    private bool NormalisationEnabled => _config.Mode != ReplayGainMode.None;

    private const float DEFAULT_GAIN = 0f;

    public ReplayGainProcessor(ReplayGainConfiguration config)
    {
        _config = config;
    }

    public void UpdateConfiguration(ReplayGainConfiguration updatedConfiguration)
    {
        _config = updatedConfiguration;

        CalculateCurrentGain();
    }
    
    public ReplayGainConfiguration GetConfiguration() => _config;

    public float UpdateVolume(float volume)
    {
        _currentVolume = volume;
        return CalculateNewVolume();
    }

    public float UpdateTrackGain(decimal? trackGain, decimal? albumGain)
    {
        _currentTrackGain = Convert.ToSingle(trackGain);
        _currentAlbumGain = Convert.ToSingle(albumGain);

        CalculateCurrentGain();

        return CalculateNewVolume();
    }

    private void CalculateCurrentGain()
    {
        var preferredGain = _config.Mode switch
        {
            ReplayGainMode.Track => _currentTrackGain,
            ReplayGainMode.Album => _currentAlbumGain,
            _ => null
        };

        if (preferredGain.HasValue)
        {
            Debug.WriteLine($"ReplayGainProcessor: Applying gain {preferredGain.Value:F4} dB from {_config.Mode} mode.");
            _currentGain = preferredGain.Value;
        }
        else if (_config.Mode == ReplayGainMode.Track && _currentAlbumGain.HasValue)
        {
            Debug.WriteLine(
                $"ReplayGainProcessor: Track gain not available, falling back to album gain {_currentAlbumGain.Value:F4} dB."
            );

            _currentGain = _currentAlbumGain.Value;
        }
        else if (_config.Mode == ReplayGainMode.Album && _currentTrackGain.HasValue)

        {
            Debug.WriteLine(
                $"ReplayGainProcessor: Album gain not available, falling back to track gain {_currentTrackGain.Value:F4} dB."
            );

            _currentGain = _currentTrackGain.Value;
        }
        else
        {
            Debug.WriteLine($"ReplayGainProcessor: No suitable gain available.");
            _currentGain = DEFAULT_GAIN;
        }
    }

    private float ConvertGainToLinear(float gainInDb)
    {
        return (float) Math.Pow(10, gainInDb / 20);
    }

    private float CalculateNewVolume()
    {
        if (!NormalisationEnabled)
        {
            return _currentVolume;
        }

        //todo: clipping prevention

        var preampScale = _config.PreampEnabled ? ConvertGainToLinear(_config.PreampAdjustment) : 1.0f;
        var replayGainScale = ConvertGainToLinear(_currentGain);
        var newVolume = _currentVolume * preampScale * replayGainScale;

        return newVolume;
    }

    public float GetVolume()
    {
        return CalculateNewVolume();
    }
}
