using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class ImageProcessor
{
    private readonly string baseImagePath;

    public ImageProcessor()
    {
        // 프로그램 실행 폴더에 상품이미지 폴더 생성
        string programPath = Application.StartupPath;
        baseImagePath = Path.Combine(programPath, "상품이미지");

        if (!Directory.Exists(baseImagePath))
        {
            Directory.CreateDirectory(baseImagePath);
        }
    }

    public async Task<string> ProcessAndSaveImage(string imageUrl, bool isMainImage)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                byte[] data = await httpClient.GetByteArrayAsync(imageUrl);
                using (var ms = new MemoryStream(data))
                using (var sourceImage = Image.FromStream(ms))
                {
                    using (var resizedImage = isMainImage ?
                        ResizeMainImage(sourceImage) :
                        ResizeDetailImage(sourceImage))
                    {
                        string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString("N")}.jpg";
                        string fullPath = Path.Combine(baseImagePath, fileName);
                        SaveImageWithQuality(resizedImage, fullPath, 90);
                        return fullPath;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"이미지 처리 중 오류: {ex.Message}");
        }
    }

    private Image ResizeMainImage(Image sourceImage)
    {
        // 대표이미지는 262x262로 리사이징
        int size = Math.Min(sourceImage.Width, sourceImage.Height);
        var cropRect = new Rectangle(
            (sourceImage.Width - size) / 2,
            (sourceImage.Height - size) / 2,
            size,
            size
        );

        var croppedImage = new Bitmap(size, size);
        using (var g = Graphics.FromImage(croppedImage))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(sourceImage, new Rectangle(0, 0, size, size), cropRect, GraphicsUnit.Pixel);
        }

        var finalImage = new Bitmap(262, 262);
        using (var g = Graphics.FromImage(finalImage))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(croppedImage, 0, 0, 262, 262);
        }

        croppedImage.Dispose();
        return finalImage;
    }

    private Image ResizeDetailImage(Image sourceImage)
    {
        // 상세이미지는 가로 860px로 리사이징
        int newWidth = 860;
        int newHeight = (int)((float)sourceImage.Height * newWidth / sourceImage.Width);

        var resizedImage = new Bitmap(newWidth, newHeight);
        using (var g = Graphics.FromImage(resizedImage))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(sourceImage, 0, 0, newWidth, newHeight);
        }

        return resizedImage;
    }

    private void SaveImageWithQuality(Image image, string path, long quality)
    {
        var encoder = ImageCodecInfo.GetImageEncoders()
            .First(c => c.FormatID == ImageFormat.Jpeg.Guid);

        var encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);

        image.Save(path, encoder, encoderParams);
    }
}