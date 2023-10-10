using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyward.Models;
using Skyward.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.ViewModels.Tests
{
    [TestClass()]
    public class ConsultantWindowViewModelTests
    {
        AppContext appContext = new AppContext();

        [TestMethod()]
        public void GenerateAReportTest()
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            PdfWriter.GetInstance(doc, new FileStream($"{path}\\Report.pdf", FileMode.Create));

            doc.Open();

            PdfPTable table = new PdfPTable(4);

            table.AddCell("PurchaseDate");
            table.AddCell("DateOfDelay");
            table.AddCell("TypeTicket");
            table.AddCell("Price");

            DateTime date = DateTime.Now.AddMonths(-1);
            decimal? smoant = 0;
            ObservableCollection<TypeTicket> typeTickets = new ObservableCollection<TypeTicket>(appContext.TypeTickets);
            foreach (var item in appContext.Tickets)
            {
                if (item.PurchaseDate.Date > date)
                {
                    table.AddCell($"{string.Format(item.PurchaseDate.Date.ToString()).Trim(new char[] { '0', ':' })}");
                    table.AddCell($"{string.Format(item.DateOfDelay.Date.ToString()).Trim(new char[] { '0', ':' })}");
                    foreach (var part in typeTickets)
                    {
                        if (item.TypeTicketId == part.Id)
                        {
                            if (part.type_ticket == "На день")
                            {
                                table.AddCell($"Day");
                            }
                            else if (part.type_ticket == "На неделю")
                            {
                                table.AddCell($"Week");
                            }
                            else if (part.type_ticket == "На месяц")
                            {
                                table.AddCell($"Month");
                            }
                            else if (part.type_ticket == "На год")
                            {
                                table.AddCell($"Year");
                            }
                            table.AddCell($"{part.price}p.");
                            smoant += part.price;
                        }
                    }
                }
            }
            PdfPCell cell = new PdfPCell(new Phrase("Total:"));
            cell.Colspan = 3;
            table.AddCell(cell);
            table.AddCell($"{smoant}p.");

            doc.Add(table);
            doc.Close();

            Assert.IsTrue(File.Exists($"{path}\\Report.pdf"));
        }
    }
}