namespace WinSonic.Service.Misc;

public interface IImageResizer
{
    Stream ResizeImage(
        Stream imageStream,
        int? width = null,
        int? height = null,
        bool maintainAspectRatio = true,
        bool allowUpscale = false
    );
}
