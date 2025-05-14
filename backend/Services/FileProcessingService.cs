using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace docmatchMS.Services;

public class FileProcessingService
{
    public async Task<string> ExtractTextFromFileAsync(string filePath)
    {
        var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();

        switch (fileExtension)
        {
            case ".txt":
                return await ReadTextFileAsync(filePath);
            case ".pdf":
                return ExtractTextFromPdf(filePath);
            case ".docx":
                return ExtractTextFromDocx(filePath);
            default:
                throw new NotSupportedException("File type not supported.");
        }
    }

    private async Task<string> ReadTextFileAsync(string filePath)
    {
        return await File.ReadAllTextAsync(filePath);
    }

    private string ExtractTextFromPdf(string filePath)
    {
        StringBuilder text = new StringBuilder();
        using (var pdfReader = new PdfReader(filePath))
        {
            using (var pdfDocument = new PdfDocument(pdfReader))
            {
                for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i)));
                }
            }
        }
        return text.ToString();
    }

    private string ExtractTextFromDocx(string filePath)
    {
        // Placeholder for .docx extraction logic
        // Use DocumentFormat.OpenXml or other libraries
        return "Extracted text from .docx (not implemented yet)";
    }
}