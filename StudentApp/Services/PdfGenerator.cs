﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace StudentApp.Services
{
    public class PdfGenerator
    {
        public void GenerateReceipt(string studentName, decimal paymentAmount, DateTime paymentDate)
        {
            using (FileStream stream = new FileStream("Detalii Chitanta.pdf", FileMode.Create))
            {

                Document document = new Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                Font headerFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                Paragraph header = new Paragraph("Chitanta cazare camin", headerFont);
                header.Alignment = Element.ALIGN_CENTER;
                //document.Add(header);
                Paragraph paragraph1 = new Paragraph(header);
                paragraph1.SpacingBefore = 50;
                document.Add(paragraph1);


                string message = $"Draga studentule cu numele {studentName}, " + 
                         $"tocmai ai platit suma de plata pentru cazarea la camin" +
                         $"în valoare de {paymentAmount} LEI pe data de {paymentDate}. Va multumim!";
                Paragraph paragraph2 = new Paragraph(message);
                paragraph2.SpacingBefore = 60;
                document.Add(new Paragraph(paragraph2));

                long randomGeneratedNumber = new Random().Next(100000000, 999999999);
                Paragraph receiptCode = new Paragraph($"Cod chitanta: {randomGeneratedNumber}");
                receiptCode.Alignment = Element.ALIGN_RIGHT;
                Paragraph paragraph3 = new Paragraph(receiptCode);
                paragraph3.SpacingBefore = 60;
                document.Add(paragraph3);

                document.Close();
            }
        }

        
    }
}
