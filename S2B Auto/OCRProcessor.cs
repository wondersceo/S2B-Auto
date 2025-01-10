using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Tesseract;
using System.Windows.Forms;

public class OCRProcessor
{
    private readonly string tessDataPath;
    private readonly TesseractEngine engine;

    public OCRProcessor()
    {
        // Tesseract 데이터 파일 경로 설정
        tessDataPath = Path.Combine(Application.StartupPath, "tessdata");

        // 한글과 영어 인식을 위한 엔진 초기화
        engine = new TesseractEngine(tessDataPath, "kor+eng", EngineMode.Default);
    }

    public string ExtractTextFromImage(string imagePath)
    {
        try
        {
            using (var img = Pix.LoadFromFile(imagePath))
            {
                using (var page = engine.Process(img))
                {
                    string text = page.GetText();
                    return text;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"OCR 처리 중 오류: {ex.Message}");
        }
    }

    public string ExtractTextFromBitmap(Bitmap bitmap)
    {
        try
        {
            using (var img = Pix.LoadFromFile(bitmap.ToString()))
            {
                using (var page = engine.Process(img))
                {
                    string text = page.GetText();
                    return text;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"OCR 처리 중 오류: {ex.Message}");
        }
    }
}