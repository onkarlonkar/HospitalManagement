using Model;
using Service;
using DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using System.Linq.Expressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace BL
{
    public class OPDHistoryManager : IOPDHistoryService
    {

        public List<OPDHistoryModel> AdvanceSearch(string searchText)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.AdvanceSearch(searchText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<OPDHistoryModel> Get()
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OPDHistoryModel> GetByStatus(params string[] status)
        {
            try
            {
                Expression<Func<OPDHistory, bool>> predicate = null;

                foreach (var item in status)
                {
                    if (predicate != null)
                    {
                        Expression<Func<OPDHistory, bool>> predicateFilter = t => t.Status.Name == item;
                        predicate = PredicateBuilder.OrElse<OPDHistory>(predicate, predicateFilter);
                    }
                    else
                    {
                        predicate = t => t.Status.Name == item;

                    }
                }


                OPDHistory entity = new OPDHistory();
                return entity.GetByStatus(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<OPDHistoryModel> GetHistoryByPatientId(Guid? id)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.GetHistoryByPatientId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public OPDHistoryModel GetById(Guid id)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public OPDHistoryModel GetByParentId(Guid id)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.GetByParentId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(OPDHistoryModel model)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DashboardModel getDashboardCounts()
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.getDashboardCounts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region -- Print --

        public bool Print(Guid? id, string printOption)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                OPDHistoryModel model = entity.GetById(id.Value);

                string renamefileName = DateTime.Now.Ticks.ToString() + ".pdf";
                string path = ConfigurationManager.AppSettings["SaveReport"].ToString() + DateTime.Now.ToString("dd-MM-yyyy");
                if (ErrorLog.IsFolderExist(path))
                {
                    path = path + "\\" + renamefileName;
                }


                // Create a Document object //
                var document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 10, 10);

                // Create a new PdfWrite object, writing the output to a MemoryStream //
                FileStream output = new FileStream(path, FileMode.Create);
                var writer = PdfWriter.GetInstance(document, output);

                // Method To Set Page Header And Footer //
                //setBillHeaderFooter(writer, document);

                // Open the Document for writing //
                document.Open();

                if (printOption == "Bill")
                {
                    setBillPageBody(document, model);
                    new BillHistory().Update(model.Id);
                }
                else if (printOption == "Prescription")
                {
                    setPrescriptionPageBody(document, model);
                }
                else if (printOption == "Both")
                {
                    setBillPageBody(document, model);
                    setPrescriptionPageBody(document, model);
                }

                // flush and clear the document from memory //
                document.Close();

                System.Diagnostics.Process.Start(path);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void setBillPageBody(iTextSharp.text.Document document, OPDHistoryModel model)
        {
            try
            {
                var boldTableFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["bodyboldTable11"]), iTextSharp.text.Font.BOLD);
                var bodyFontNormal = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["bodyboldTable12"]), iTextSharp.text.Font.NORMAL);
                var headerFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["headerFont"]), iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

                setBillPageHeader(document);

                //Patient Details
                PdfPTable table = new PdfPTable(2);
                table.DeleteBodyRows();
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 5;
                table.SpacingAfter = 10;


                newCell(table, "Name : " + model.PatientDetails.FullName, boldTableFont, 0, 0);
                newCell(table, "Date. : " + model.InTime.Value.ToShortDateString(), boldTableFont, 2, 0);
                newCell(table, "O.P.D No. : " + model.CasePaperNumber, boldTableFont, 0, 0);
                newCell(table, "Receipt No. : " + new BillHistory().GetByOPDId(model.Id.Value).ReceiptNumber.ToString(), boldTableFont, 2, 0);

                document.Add(table);

                // Bill Details
                table = new PdfPTable(3);
                table.DeleteBodyRows();
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 5;
                table.SpacingAfter = 10;



                newCell(table, "Received for ", boldTableFont, -1, -1, 2);
                newCell(table, "Rs", boldTableFont, 1, -1);

                int srNo = 1;
                newCell(table, srNo.ToString(), bodyFontNormal, 1, 4);
                newCell(table, "Conc. FEE. :", bodyFontNormal, 0, 8);

                PdfPCell cell = new PdfPCell(new Phrase(model.Amount.ToString(), bodyFontNormal));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = PdfCell.LEFT_BORDER;
                cell.Border = PdfCell.RIGHT_BORDER;
                table.AddCell(cell);

                if (model.LabTestingAmount.HasValue && model.LabTestingAmount.Value != Convert.ToDecimal(0.00))
                {
                    srNo++;
                    newCell(table, srNo.ToString(), bodyFontNormal, 1, 4);
                    newCell(table, "Labarotry. FEE. ", bodyFontNormal, 0, 8);
                    newCell(table, model.LabTestingAmount.ToString(), bodyFontNormal, 1, 8);
                }


                newCell(table, "Total", boldTableFont, 2, -1, 2);
                newCell(table, model.TotalAmount.ToString(), boldTableFont, 1, -1, 2);

                for (int i = 0; i < 5; i++)
                {
                    blankCell(table, 3);
                }
                newCell(table, "Signature", boldTableFont, 2, 0, 3);

                table.SetWidths(new int[] { 1, 12, 6 });

                document.Add(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void setBillPageHeader(Document document)
        {
            try
            {
                //Set Header Font
                var smallHeaderFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["smallHeaderFont"]), iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                var headerFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["headerFont"]), iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
                var bigheaderFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["bigheaderFont"]), iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

                PdfPTable table = new PdfPTable(1);
                table.DeleteBodyRows();
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 5;
                table.SpacingAfter = 5;

                newCell(table, "\n", 1, 0);
                newCell(table, "AN ISO 9000-2000 CERTIFIED HOSPITAL", smallHeaderFont, 1, 0);
                newCell(table, "Dr. V. S. Paramshetti, Miraj", headerFont, 1, 0);
                newCell(table, "\n", 1, 0);
                newCell(table, "RECEIPT", bigheaderFont, 1, 2);

                document.Add(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void setPrescriptionPageHeader(Document document)
        {
            try
            {
                //Set Header Font
                var smallHeaderFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["smallHeaderFont"]), iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                var headerFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["headerFont"]), iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

                PdfPTable table = new PdfPTable(1);
                table.DeleteBodyRows();
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 5;
                table.SpacingAfter = 5;

                newCell(table, "\n", 1, 0);
                newCell(table, "PARAMASHETTI", headerFont, 1, 0);
                newCell(table, "MULTI SPECIALITY HOSPITAL", headerFont, 1, 0);
                newCell(table, "Vishwas Estate, Miraj - Sangli Road, Miraj.", smallHeaderFont, 1, 0);
                newCell(table, "Phone : 0233 - 2212430, 2212431", smallHeaderFont, 1, 0);

                document.Add(table);

                table = new PdfPTable(2);
                table.DeleteBodyRows();
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 5;
                table.SpacingAfter = 5;

                List<string> lststring = new List<string>();
                lststring.Add("Dr. V. S. Paramshetti");
                lststring.Add("Dr. Mrs  R. V. Paramshetti");
                lststring.Add("M.D. (Med)");
                lststring.Add("M.B.B.S; D.C.H");
                lststring.Add("Consultant Physician");
                lststring.Add("Consultant Paediatrician");
                lststring.Add("Reg No. 63054");
                lststring.Add("Reg No. 33414");

                int index = 0;
                foreach (string item in lststring)
                {
                    int alignment = -1;
                    Font font = index < 2 ? headerFont : smallHeaderFont;
                    if (index == 3)
                        alignment = 2;
                    else
                    {
                        alignment = index % 2 != 0 ? 2 : 0;
                    }
                    newCell(table, item, font, alignment, 0);
                    index++;
                }


                newCell(table, "\n", 1, 2);

                document.Add(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void setPrescriptionPageBody(Document document, OPDHistoryModel model)
        {
            try
            {
                var boldTableFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["bodyboldTable11"]), iTextSharp.text.Font.BOLD);
                var bodyFontNormal = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["bodyboldTable12"]), iTextSharp.text.Font.NORMAL);
                var headerFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["headerFont"]), iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
                var bigheaderFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["bigheaderFont"]), iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

                setPrescriptionPageHeader(document);

                PdfPTable table = new PdfPTable(2);
                table.DeleteBodyRows();
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 5;
                table.SpacingAfter = 10;

                newCell(table, "DRUG SLIP", bigheaderFont, 1, 2, 2);
                blankCell(table, 2);
                newCell(table, "Name : " + model.PatientDetails.FullName, bodyFontNormal);
                newCell(table, "Date. : " + model.InTime.Value.ToShortDateString(), bodyFontNormal, 2, 0);
                newCell(table, "O.P.D No. : " + model.CasePaperNumber, bodyFontNormal, 0, 0, 2);

                blankCell(table, 2);
                newCell(table, "", bodyFontNormal, 0, 2, 2);
                newCell(table, "Rx", bigheaderFont, 0, 0);
                newCell(table, "Date: " + DateTime.Now.ToShortDateString(), boldTableFont, 2, 0);
                blankCell(table, 2);


                string[] splitArray = model.Madicines.Split(new string[] { "\\line" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in splitArray)
                {
                    string[] spArray = item.Split('$');
                    newCell(table, spArray[0].Trim(), bodyFontNormal, 0, 0);
                    newCell(table, spArray[1].Trim(), bodyFontNormal, 0, 0);
                    blankCell(table, 2);
                }

                for (int i = 0; i < 5; i++)
                {
                    blankCell(table, 2);
                }
                newCell(table, "Doctor's Sign.", bodyFontNormal, 2, 0, 2);
                document.Add(table);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void setBillHeaderFooter(PdfWriter writer, iTextSharp.text.Document document)
        {
            try
            {
                //Set Header Font
                var smallHeaderFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["smallHeaderFont"]), iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                var headerFont = FontFactory.GetFont("verdana", Convert.ToInt32(ConfigurationManager.AppSettings["headerFont"]), iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);


                PdfPTable headerTable = new PdfPTable(1);
                headerTable.DeleteBodyRows();
                headerTable.WidthPercentage = 100;
                headerTable.HorizontalAlignment = 0;
                headerTable.SpacingBefore = 2;
                headerTable.SpacingAfter = 1;

                Chunk c1 = new Chunk("\n", smallHeaderFont);
                Chunk c2 = new Chunk("AN ISO 9000-2000 CERTIFIED HOSPITAL\n", smallHeaderFont);
                Chunk c3 = new Chunk("Dr. V. S. Paramshetti, Miraj\n", headerFont);
                Chunk c4 = new Chunk("RECEIPT", headerFont);

                //Set header text
                Phrase headerPhrase = new Phrase("");
                headerPhrase.Add(c1);
                headerPhrase.Add(c2);
                headerPhrase.Add(c3);
                headerPhrase.Add(c4);


                //Add header
                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Alignment = Element.ALIGN_CENTER;
                document.Add(headerPhrase);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //Add footer            
            //HeaderFooter footer = new HeaderFooter(new Phrase(String.Format("Signature"), headerFont), false);
            //document.Footer = footer;
            //footer.Alignment = Element.ALIGN_RIGHT;
            //footer.Border = 0;
        }

        private PdfPCell blankCell(PdfPTable table, int? colspan = 0)
        {
            try
            {
                PdfPCell cell = new PdfPCell(new Phrase(""));
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Colspan = colspan.Value;
                table.AddCell(cell);
                return cell;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private PdfPCell newCell(PdfPTable table, string content, Font font, int? alignment = -1, int? border = 0, int? colspan = 0)
        {
            try
            {
                PdfPCell cell = new PdfPCell(new Phrase(content, font));
                if (border.Value != -1)
                    cell.Border = border.Value;
                cell.HorizontalAlignment = alignment.Value;
                cell.Colspan = colspan.Value;
                table.AddCell(cell);
                return cell;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private PdfPCell newCell(PdfPTable table, string content, int? alignment = -1, int? border = 0, int? colspan = 0)
        {
            try
            {
                PdfPCell cell = new PdfPCell(new Phrase(content));
                cell.Border = border.Value;
                cell.HorizontalAlignment = alignment.Value;
                cell.Colspan = colspan.Value;
                table.AddCell(cell);
                return cell;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        #endregion

        public List<LookupModel> getPatientByType(P_TYPE type)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                return entity.getPatientByType(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
     this Expression<Func<T, bool>> expr1,
     Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(left, right), parameter);
        }

        public static Expression<Func<T, bool>> OrElse<T>(
    this Expression<Func<T, bool>> expr1,
    Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(left, right), parameter);
        }
    }

    public class ReplaceExpressionVisitor
           : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override Expression Visit(Expression node)
        {
            if (node == _oldValue)
                return _newValue;
            return base.Visit(node);
        }
    }
}
