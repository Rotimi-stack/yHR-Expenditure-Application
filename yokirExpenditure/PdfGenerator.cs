using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using yHR.Common.Data;

namespace yHR
{


    public class PdfGenerator
    {

        protected void DisplayMessage(string message, MessageBoxIcon icon, int timeout = 1000)
        {
            MessageBox.Show(message, "Expenditures", MessageBoxButtons.OK, icon);
            Task.Delay(timeout).ContinueWith(t =>
            {

            });
        }
        private static CustomFontResolver fontResolver;

        public PdfGenerator()
        {
            if (fontResolver == null)
            {
                fontResolver = new CustomFontResolver();
                GlobalFontSettings.FontResolver = fontResolver;
            }
        }

        //public void PrintToPdf(string fileName, List<Expenditures> items)
        //{
        //    // Create a PDF document
        //    PdfDocument pdfDocument = new PdfDocument();


        //    // Add a page to the document
        //    PdfPage pdfPage = pdfDocument.AddPage();

        //    // Create a PDF graphics object
        //    XGraphics gfx = XGraphics.FromPdfPage(pdfPage);

        //    XFont headingFont = new XFont("Arial", 16);

        //    // Set font and format
        //    XFont font = new XFont("Arial", 11);
        //    XStringFormat centerFormat = new XStringFormat();
        //    centerFormat.Alignment = XStringAlignment.Center;

        //    // Set column widths for the table
        //    double[] columnWidths = { 170, 70, 100, 100, 200 };

        //    // Set starting position
        //    double xPosition = 10;
        //    double yPosition = 30;



        //    //double headingXPosition = 10;
        //    double headingYPosition = 30;

        //    // Draw heading
        //    string headingText = "yHR Expenditure Report";
        //    double headingWidth = gfx.MeasureString(headingText, headingFont).Width;
        //    double headingXPosition = (pdfPage.Width.Point - headingWidth) / 2;  // Centered horizontally
        //    gfx.DrawString(headingText, headingFont, XBrushes.Black, headingXPosition, headingYPosition);

        //    yPosition += headingFont.Height + 10;

        //    // Draw table headers
        //    gfx.DrawString("Description", font, XBrushes.Black, xPosition, yPosition);
        //    xPosition += columnWidths[0];
        //    gfx.DrawString("Amount", font, XBrushes.Black, xPosition, yPosition);
        //    xPosition += columnWidths[1];
        //    gfx.DrawString("ExpType", font, XBrushes.Black, xPosition, yPosition);
        //    xPosition += columnWidths[2];
        //    gfx.DrawString("ExpTypeSub", font, XBrushes.Black, xPosition, yPosition);
        //    xPosition += columnWidths[3];
        //    gfx.DrawString("Date", font, XBrushes.Black, xPosition, yPosition);

        //    gfx.DrawLine(XPens.Black, 10, yPosition + 20, columnWidths.Sum(), yPosition + 20);

        //    // Move to the next row
        //    yPosition += 20;





        //    decimal totalAmont = 0;
        //    float padding = 25;



        //    // Draw table content
        //    foreach (var item in items)
        //    {
        //        xPosition = 10;

        //        for (int i = 0; i < columnWidths.Length; i++)
        //        {
        //            gfx.DrawLine(XPens.Black, xPosition + columnWidths[i], yPosition, xPosition + columnWidths[i], yPosition + 20);
        //            xPosition += columnWidths[i];
        //        }

        //        gfx.DrawLine(XPens.Black, 10, yPosition + 20, xPosition - padding, yPosition + 20);

        //        xPosition = 10;

        //        DrawStringWithWrapping(gfx, item.Description, font, XBrushes.Black, xPosition, yPosition, columnWidths[0]);
        //        xPosition += columnWidths[0];
        //        gfx.DrawString(item.Amount.ToString(), font, XBrushes.Black, xPosition, yPosition,XStringFormat.Center);
        //        xPosition += columnWidths[1];
        //        DrawStringWithWrapping(gfx, item.ExpTypeDescrip, font, XBrushes.Black, xPosition, yPosition, columnWidths[2], XStringFormat.Center);
        //        xPosition += columnWidths[2];

        //        string expTypeSub = item.ExpSubTypeDescrip ?? "N/A";
        //        DrawStringWithWrapping(gfx, expTypeSub, font, XBrushes.Black, xPosition, yPosition, columnWidths[3],XStringFormat.Center);
        //        xPosition += columnWidths[3];
        //        gfx.DrawString(item.DateCreated.ToString(), font, XBrushes.Black, xPosition, yPosition, XStringFormat.Center);


        //        totalAmont += item.Amount;

        //        // Move to the next row
        //        yPosition += CalculateContentHeight(gfx, item, font, columnWidths);
        //    }

        //    //Draw total amount
        //    xPosition = 10;
        //    yPosition += 50;
        //    gfx.DrawString($"Total Amount: {totalAmont.ToString("N")}", font, XBrushes.Black, xPosition, yPosition);



        //    gfx.DrawLine(XPens.Black, 10, yPosition, xPosition, yPosition);

        //    string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //    string fulllPath = Path.Combine(defaultPath, fileName);
        //    // Save the PDF file
        //    pdfDocument.Save(fulllPath);

        //    try
        //    {
        //        Process.Start(new ProcessStartInfo(fulllPath) { UseShellExecute = true });
        //    }
        //    catch (Exception ex)
        //    {

        //        return;
        //    }

        //}




        public void PrintToPdf(string fileName, ListView listView)
        {
            // Create a PDF document
            PdfDocument pdfDocument = new PdfDocument();

            // Add a page to the document
            PdfPage pdfPage = pdfDocument.AddPage();

            // Create a PDF graphics object
            XGraphics gfx = XGraphics.FromPdfPage(pdfPage);

            XFont headingFont = new XFont("Arial", 16);

            // Set font and format
            XFont font = new XFont("Arial", 11);
            XStringFormat centerFormat = new XStringFormat();
            centerFormat.Alignment = XStringAlignment.Center;

            // Set column widths for the table
            double[] columnWidths = { 170, 70, 100, 100, 200 };

            // Set starting position
            double xPosition = 10;
            double yPosition = 30;

            // Draw heading
            string headingText = "yHR Expenditure Report";
            double headingWidth = gfx.MeasureString(headingText, headingFont).Width;
            double headingXPosition = (pdfPage.Width.Point - headingWidth) / 2;  // Centered horizontally
            gfx.DrawString(headingText, headingFont, XBrushes.Black, headingXPosition, yPosition);
            yPosition += headingFont.Height + 10;

            // Draw table headers
            gfx.DrawString("Description", font, XBrushes.Black, xPosition, yPosition);
            xPosition += columnWidths[0];
            gfx.DrawString("Amount", font, XBrushes.Black, xPosition, yPosition);
            xPosition += columnWidths[1];
            gfx.DrawString("ExpType", font, XBrushes.Black, xPosition, yPosition);
            xPosition += columnWidths[2];
            gfx.DrawString("ExpTypeSub", font, XBrushes.Black, xPosition, yPosition);
            xPosition += columnWidths[3];
            gfx.DrawString("Date", font, XBrushes.Black, xPosition, yPosition);

            gfx.DrawLine(XPens.Black, 10, yPosition + 20, columnWidths.Sum(), yPosition + 20);

            // Move to the next row
            yPosition += 20;

            // Draw table content
            foreach (ListViewItem item in listView.Items)
            {
                xPosition = 10;

                for (int i = 0; i < columnWidths.Length; i++)
                {
                    gfx.DrawLine(XPens.Black, xPosition + columnWidths[i], yPosition, xPosition + columnWidths[i], yPosition + 20);
                    xPosition += columnWidths[i];
                }

                gfx.DrawLine(XPens.Black, 10, yPosition + 20, xPosition - 10, yPosition + 20);

                xPosition = 10;

                gfx.DrawString(item.SubItems[0].Text, font, XBrushes.Black, xPosition, yPosition);
                xPosition += columnWidths[0];
                gfx.DrawString(item.SubItems[1].Text, font, XBrushes.Black, xPosition, yPosition);
                xPosition += columnWidths[1];
                gfx.DrawString(item.SubItems[2].Text, font, XBrushes.Black, xPosition, yPosition);
                xPosition += columnWidths[2];
                gfx.DrawString(item.SubItems[3].Text, font, XBrushes.Black, xPosition, yPosition);
                xPosition += columnWidths[3];
                gfx.DrawString(item.SubItems[4].Text, font, XBrushes.Black, xPosition, yPosition);

                // Move to the next row
                yPosition += CalculateContentHeight(gfx, item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text, font, columnWidths);

            }

            string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(defaultPath, fileName);

            // Save the PDF file
            pdfDocument.Save(fullPath);

            try
            {
                Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening PDF file: {ex.Message}");
            }
        }



        private void DrawStringWithWrapping(XGraphics gfx, string text, XFont font, XBrush brush, double x, double y, double maxWidth)
        {
            if (gfx.MeasureString(text, font).Width <= maxWidth)
            {
                gfx.DrawString(text, font, brush, x, y);
            }
            else
            {
                string[] words = text.Split(' ');
                StringBuilder currentLine = new StringBuilder();
                double currentLineWidth = 0;

                foreach (string word in words)
                {
                    double wordWidth = gfx.MeasureString(word + " ", font).Width;
                    if (currentLineWidth + wordWidth <= maxWidth)
                    {
                        currentLine.Append(word + " ");
                        currentLineWidth += wordWidth;
                    }
                    else
                    {
                        gfx.DrawString(currentLine.ToString(), font, brush, x, y);
                        y += font.Height;
                        currentLine = new StringBuilder(word + " ");
                        currentLineWidth = wordWidth;
                    }
                }

                if (currentLine.Length > 0)
                {
                    gfx.DrawString(currentLine.ToString(), font, brush, x, y);
                }
            }
        }

        private double CalculateContentHeight(XGraphics gfx, string description, string amount, string expType, string expTypeSub, string date, XFont font, double[] columnWidths)
        {
            double maxHeight = 20;
            maxHeight = Math.Max(gfx.MeasureString(description, font).Height, maxHeight);
            maxHeight = Math.Max(gfx.MeasureString(amount, font).Height, maxHeight);
            maxHeight = Math.Max(gfx.MeasureString(expType, font).Height, maxHeight);
            maxHeight = Math.Max(gfx.MeasureString(expTypeSub, font).Height, maxHeight);
            maxHeight = Math.Max(gfx.MeasureString(date, font).Height, maxHeight);
            return maxHeight;
        }






























































        //public void PrintToPdf(string fileName, List<Expenditures> items)
        //{
        //    // Create a PDF document
        //    PdfDocument pdfDocument = new PdfDocument();

        //    // Add a page to the document
        //    PdfPage pdfPage = pdfDocument.AddPage();

        //    // Create a PDF graphics object
        //    XGraphics gfx = XGraphics.FromPdfPage(pdfPage);

        //    XFont headingFont = new XFont("Arial", 16);
        //    XFont font = new XFont("Arial", 10);

        //    double[] columnWidths = { 200, 70, 100, 100, 170 };
        //    double xPosition = 50;
        //    double yPosition = 50;

        //    // Draw heading
        //    string headingText = "yHR Expenditure Report";
        //    double headingWidth = gfx.MeasureString(headingText, headingFont).Width;
        //    double headingXPosition = (pdfPage.Width.Point - headingWidth) / 2;  // Centered horizontally
        //    gfx.DrawString(headingText, headingFont, XBrushes.Black, headingXPosition, yPosition);

        //    yPosition += headingFont.Height + 10;

        //    // Draw table headers with center alignment
        //    for (int i = 0; i < columnWidths.Length; i++)
        //    {
        //        double headerXPosition = xPosition + (columnWidths[i] / 2) - (gfx.MeasureString(items.FirstOrDefault().Description, font).Width / 2);
        //        gfx.DrawString(GetColumnName(i), font, XBrushes.Black, headerXPosition, yPosition);
        //        xPosition += columnWidths[i];
        //    }

        //    // Draw horizontal line below headers
        //    gfx.DrawLine(XPens.Black, 10, yPosition + 20, xPosition, yPosition + 20);

        //    // Move to the next row
        //    yPosition += 20;

        //    // Draw table content
        //    foreach (var item in items)
        //    {
        //        xPosition = 20;

        //        for (int i = 0; i < columnWidths.Length; i++)
        //        {
        //            gfx.DrawLine(XPens.Black, xPosition + columnWidths[i], yPosition, xPosition + columnWidths[i], yPosition + 30);
        //            xPosition += columnWidths[i];
        //        }

        //        gfx.DrawLine(XPens.Black, 10, yPosition + 20, xPosition, yPosition + 20);

        //        xPosition = 20;

        //        double descriptionHeight = CalculateTextHeight(gfx, item.Description, font, columnWidths[0]);
        //        double descriptionYPosition = yPosition + ((30 - descriptionHeight) / 2); // Center vertically
        //        gfx.DrawString(item.Description, font, XBrushes.Black, new XRect(xPosition, yPosition, columnWidths[1], font.Height), XStringFormats.CenterLeft);
        //        xPosition += columnWidths[0];
        //        gfx.DrawString(item.Amount.ToString(), font, XBrushes.Black, new XRect(xPosition, yPosition, columnWidths[1], font.Height), XStringFormats.Center);
        //        xPosition += columnWidths[1];
        //        gfx.DrawString(item.ExpTypeDescrip, font, XBrushes.Black, new XRect(xPosition, yPosition, columnWidths[2], font.Height), XStringFormats.Center);
        //        xPosition += columnWidths[2];

        //        string expTypeSub = item.ExpSubTypeDescrip ?? "N/A";
        //        gfx.DrawString(expTypeSub, font, XBrushes.Black, new XRect(xPosition, yPosition, columnWidths[3], font.Height), XStringFormats.Center);
        //        xPosition += columnWidths[3];
        //        gfx.DrawString(item.DateCreated.ToString(), font, XBrushes.Black, new XRect(xPosition, yPosition, columnWidths[4], font.Height), XStringFormats.Center);

        //        // Move to the next row
        //        yPosition += CalculateContentHeight(gfx, item, font, columnWidths);
        //    }

        //    //Draw total amount
        //    xPosition = 10;
        //    yPosition += 50;
        //    gfx.DrawString($"Total Amount: {items.Sum(x => x.Amount).ToString("N")}", font, XBrushes.Black, xPosition, yPosition);

        //    gfx.DrawLine(XPens.Black, 10, yPosition, xPosition, yPosition);

        //    string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    string fullPath = Path.Combine(defaultPath, fileName);

        //    // Save the PDF file
        //    pdfDocument.Save(fullPath);

        //    try
        //    {
        //        Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        private string GetColumnName(int index)
        {
            switch (index)
            {
                case 0:
                    return "Description";
                case 1:
                    return "Amount";
                case 2:
                    return "ExpType";
                case 3:
                    return "ExpTypeSub";
                case 4:
                    return "Date";
                default:
                    return "Unknown";
            }
        }

        private double CalculateTextHeight(XGraphics gfx, string text, XFont font, double maxWidth)
        {
            // Split the text into words
            string[] words = text.Split(' ');

            double lineHeight = font.GetHeight();
            double currentLineWidth = 0;
            double totalHeight = 0;

            foreach (string word in words)
            {
                double wordWidth = gfx.MeasureString(word + " ", font).Width;

                // Check if the word fits within the max width
                if (currentLineWidth + wordWidth <= maxWidth)
                {
                    currentLineWidth += wordWidth;
                }
                else
                {
                    // Move to the next line
                    totalHeight += lineHeight;
                    currentLineWidth = wordWidth;
                }
            }

            // Add the height of the last line
            totalHeight += lineHeight;

            return totalHeight;
        }
        

    }

    public class CustomFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            using (var fontStream = new FileStream("C:\\Windows\\Fonts\\arial.ttf", FileMode.Open, FileAccess.Read))
            {
                fontStream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            return new FontResolverInfo("YourFontFamilyName");
        }
    }







}

