using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using WinSonic.Service.Misc;

namespace WinSonic.Misc.ImageTools;

public class ImageSharpResizer : IImageResizer
{
    public Stream ResizeImage(
        Stream imageStream,
        int? width = null,
        int? height = null,
        bool maintainAspectRatio = true,
        bool allowUpscale = false
    )
    {
        using var image = Image.Load(imageStream);

        if (width.HasValue && height.HasValue)
        {
            if (maintainAspectRatio)
            {
                var aspectRatio = (double) image.Width / image.Height;

                if (width.Value / (double) height.Value > aspectRatio)
                {
                    width = (int) (height.Value * aspectRatio);
                }
                else
                {
                    height = (int) (width.Value / aspectRatio);
                }
            }

            if (allowUpscale)
            {
                width = Math.Min(width.Value, image.Width);
                height = Math.Min(height.Value, image.Height);
            }

            if (width != image.Width || height != image.Height)
            {
                image.Mutate(x => x.Resize(width.Value, height.Value));
            }
        }
        else if (width.HasValue)
        {
            if (maintainAspectRatio)
            {
                height = (int) (width.Value / ((double) image.Width / image.Height));
            }
            
            if (allowUpscale)
            {
                width = Math.Min(width.Value, image.Width);
                height = Math.Min(height ?? image.Height, image.Height);
            }

            if (width != image.Width || height != image.Height)
            {
                image.Mutate(x => x.Resize(width.Value, height ?? image.Height));
            }
        }
        else if (height.HasValue)
        {
            if (maintainAspectRatio)
            {
                width = (int) (height.Value * ((double) image.Width / image.Height));
            }

            if (allowUpscale)
            {
                width = Math.Min(width ?? image.Width, image.Width);
                height = Math.Min(height.Value, image.Height);
            }

            if (width != image.Width || height != image.Height)
            {
                image.Mutate(x => x.Resize(width ?? image.Width, height ?? image.Height));
            }
        }

        var outputStream = new MemoryStream();
        image.SaveAsJpeg(outputStream);
        outputStream.Position = 0;
        return outputStream;
    }
}
