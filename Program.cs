using IronPdf;
using System;
using System.IO;

namespace IronPdfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var documentWithJavaScriptQuery = "<h1>Html Page 1 with JavaScript.</h1><script>document.querySelector('h1').style.backgroundColor = 'red';</script>";
            var headerWithJavaScriptQuery = "<h1>Header with JavaScript.</h1><script>document.querySelector('h1').style.backgroundColor = 'red';</script>";
            var footerWithJavaScriptQuery = "<h1>Footer with JavaScript.</h1><script>document.querySelector('h1').style.backgroundColor = 'red';</script>";

            var renderer = new HtmlToPdf
            {
                PrintOptions =
                {
                    EnableJavaScript = false
                }
            };

            var pdfDocument = renderer.RenderHtmlAsPdf(documentWithJavaScriptQuery);
            pdfDocument.AddHeadersAndFooters(new PdfPrintOptions
            {
                Header = new HtmlHeaderFooter { HtmlFragment = headerWithJavaScriptQuery},
                CssMediaType = PdfPrintOptions.PdfCssMediaType.Print,
                EnableJavaScript = false
            });
            pdfDocument.AddHeadersAndFooters(new PdfPrintOptions
            {
                Footer = new HtmlHeaderFooter { HtmlFragment = footerWithJavaScriptQuery },
                CssMediaType = PdfPrintOptions.PdfCssMediaType.Print,
                EnableJavaScript = false
            });

            pdfDocument.SaveAs(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "IronPdfTest.pdf"));
        }
    }
}
