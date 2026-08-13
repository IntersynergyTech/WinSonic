using System;
using Avalonia.Controls.Primitives;
using WinSonic.Core.Models;

namespace WinSonic.Gui.Xplat.Controls;

public class TrackListEntry : TemplatedControl
{
    public Song Song { get; set; }
    public TrackListingType Type { get; set; }
}

public enum TrackListingType
{
    General,
    AlbumView,
}
