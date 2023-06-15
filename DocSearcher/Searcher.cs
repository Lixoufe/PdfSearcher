using System.IO;
using System.Diagnostics;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;

namespace DocSearcher
{
    internal static class Searcher
    {
        public static int Search(string folderPath, string text)
        {
            int nbFound = 0;
            foreach (var filePath in Directory.EnumerateFiles(folderPath))
            {
                if (Path.GetExtension(filePath) == ".pdf")
                {
                    var reader = new PdfDocument(new PdfReader(filePath));
                    for (int i = 1; i <= reader.GetNumberOfPages(); i++)
                    {
                        if (PdfTextExtractor.GetTextFromPage(reader.GetPage(i)).Contains(text))
                        {
                            Process.Start(filePath);
                            nbFound++;
                            break;
                        }
                    }
                    
                }

            }

            foreach(var dir in Directory.EnumerateDirectories(folderPath))
            {
                nbFound += Search(dir, text);
            }

            return nbFound;
        }
    }
}
