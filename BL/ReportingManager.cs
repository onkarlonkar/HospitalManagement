using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DL.Entity;
using System.Linq.Expressions;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;
using System.Configuration;
using Utility;

namespace BL
{
    public class ReportingManager : IReportingService
    {
        public List<OPDHistoryModel> GetByCasePaper(string casePaperNo)
        {
            throw new NotImplementedException();
        }

        public List<OPDHistoryModel> GetByDate(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<OPDHistoryModel> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<OPDHistoryModel> GetGenericReport(OPDFilterSearchModel searchModel)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                List<OPDHistoryModel> model = entity.GetGenericReport(GetPredicate(searchModel));

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DownloadReport(OPDFilterSearchModel searchModel)
        {
            try
            {
                OPDHistory entity = new OPDHistory();
                List<OPDHistoryModel> model = entity.GetGenericReport(GetPredicate(searchModel));
                return createReport(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<PatientDetailModel> GetIPDReport(OPDFilterSearchModel searchModel)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                List<PatientDetailModel> model = entity.GetGenericReport(GetIPDPredicate(searchModel));

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DownloadIPDReport(OPDFilterSearchModel searchModel)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                List<PatientDetailModel> model = entity.GetGenericReport(GetIPDPredicate(searchModel));
                return createIPDReport(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public Expression<Func<OPDHistory, bool>> GetPredicate(OPDFilterSearchModel model)
        {
            Expression<Func<OPDHistory, bool>> predicate = t => t.PatientId.HasValue;
            Expression<Func<OPDHistory, bool>> predicateFilter = null;
            if (model.searchText != null)
            {
                predicateFilter = t => t.PatientDetail.FullName.Contains(model.searchText) || t.PatientDetail.CasePaperNumber.Contains(model.searchText);
                predicate = PredicateBuilder.AndAlso<OPDHistory>(predicate, predicateFilter);
                predicateFilter = null;
            }
            if (model.ConsultingId.Any())
            {
                predicateFilter = t => model.ConsultingId.Contains(t.ConsultingDoctorId);
                predicate = PredicateBuilder.AndAlso<OPDHistory>(predicate, predicateFilter);
                predicateFilter = null;
            }
            if (model.StatusId.Any())
            {
                predicateFilter = t => model.StatusId.Contains(t.StatusId);
                predicate = PredicateBuilder.AndAlso<OPDHistory>(predicate, predicateFilter);
                predicateFilter = null;
            }
            if (model.type.Any())
            {
                predicateFilter = t => model.type.Contains(t.IsFollowUp);
                predicate = PredicateBuilder.AndAlso<OPDHistory>(predicate, predicateFilter);
                predicateFilter = null;
            }
            if (model.from.HasValue)
            {
                predicateFilter = t => t.InTime.Value >= model.from.Value && t.InTime.Value <= model.to.Value;
                predicate = PredicateBuilder.AndAlso<OPDHistory>(predicate, predicateFilter);
                predicateFilter = null;
            }
            return predicate;
        }

        public Expression<Func<PatientDetail, bool>> GetIPDPredicate(OPDFilterSearchModel model)
        {
            Expression<Func<PatientDetail, bool>> predicate = t => t.Id != Guid.Empty;
            Expression<Func<PatientDetail, bool>> predicateFilter = null;
            if (model.searchText != null)
            {
                predicateFilter = t => t.FullName.Contains(model.searchText) || t.CasePaperNumber.Contains(model.searchText);
                predicate = PredicateBuilder.AndAlso<PatientDetail>(predicate, predicateFilter);
                predicateFilter = null;
            }
            if (model.from.HasValue)
            {
                predicateFilter = t => t.ModifiedOn.Value >= model.from.Value && t.ModifiedOn.Value <= model.to.Value;
                predicate = PredicateBuilder.AndAlso<PatientDetail>(predicate, predicateFilter);
                predicateFilter = null;
            }
            return predicate;
        }

        public string createReport(List<OPDHistoryModel> model)
        {
            string path = string.Empty;
            if (model.Any())
            {
                //File Name
                string renamefileName = DateTime.Now.Ticks.ToString() + ".docx";
                path = ConfigurationManager.AppSettings["OPDHistoryRPT"].ToString() + DateTime.Now.ToString("dd-MM-yyyy");
                if (ErrorLog.IsFolderExist(path))
                {
                    path = path + "\\" + renamefileName;
                }
                //Create word document
                Document document = new Document();
                Section section = document.AddSection();
                section.PageSetup.PageSize = PageSize.A4;
                //section.PageSetup.Orientation = PageOrientation.Landscape;
                createHeader(ref section);

                createBody(ref section, model);

                createFooter(ref section);

                //Save and Launch

                document.SaveToFile(path, FileFormat.Docx2013);


                System.Diagnostics.Process.Start(path);
            }

            return path;
        }


        public string createIPDReport(List<PatientDetailModel> model)
        {
            string path = string.Empty;
            if (model.Any())
            {
                //File Name
                string renamefileName = DateTime.Now.Ticks.ToString() + ".docx";
                path = ConfigurationManager.AppSettings["IPDHistoryRPT"].ToString() + DateTime.Now.ToString("dd-MM-yyyy");
                if (ErrorLog.IsFolderExist(path))
                {
                    path = path + "\\" + renamefileName;
                }
                //Create word document
                Document document = new Document();
                Section section = document.AddSection();
                section.PageSetup.PageSize = PageSize.A4;

                createHeader(ref section);

                createIPDBody(ref section, model);

                createFooter(ref section);

                //Save and Launch

                document.SaveToFile(path, FileFormat.Docx2013);


                System.Diagnostics.Process.Start(path);
            }

            return path;
        }


        private void createIPDBody(ref Section section, List<PatientDetailModel> model)
        {
            Paragraph para = section.AddParagraph();
            para.AppendText("");

            Table table = section.AddTable(true);
            //Create Header and Data
            String[] Header = { "Sr #", "Case Paper #", "Name", "Date", "Time", "Received By", "Bill" };

            //Add Cells
            table.ResetCells(model.Count + 2, Header.Length);

            //Header Row
            TableRow FRow = table.Rows[0];
            FRow.IsHeader = true;

            //Row Height
            FRow.Height = 23;

            //Header Format
            FRow.RowFormat.BackColor = Color.AliceBlue;

            for (int i = 0; i < Header.Length; i++)
            {
                //Cell Alignment
                Paragraph p = FRow.Cells[i].AddParagraph();
                FRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                FRow.Cells[i].SetCellWidth(20, CellWidthType.Percentage);
                //Data Format
                TextRange TR = p.AppendText(Header[i]);
                TR.CharacterFormat.FontName = "Calibri";
                TR.CharacterFormat.FontSize = 10;
                TR.CharacterFormat.TextColor = Color.Black;
                TR.CharacterFormat.Bold = true;
            }

            //Column Width
            FRow.Cells[0].SetCellWidth(3, CellWidthType.Percentage);
            FRow.Cells[1].SetCellWidth(12, CellWidthType.Percentage);
            FRow.Cells[2].SetCellWidth(20, CellWidthType.Percentage);
            FRow.Cells[3].SetCellWidth(15, CellWidthType.Percentage);
            FRow.Cells[4].SetCellWidth(15, CellWidthType.Percentage);
            FRow.Cells[5].SetCellWidth(15, CellWidthType.Percentage);
            FRow.Cells[6].SetCellWidth(8, CellWidthType.Percentage);

            int index = 0;
            TableRow DataRow = table.Rows[index + 1];

            decimal? grandTotal = 0.00M;
            foreach (var item in model)
            {
                if (index != 0)
                    DataRow = table.Rows[index + 1];

                //Row Height
                DataRow.Height = 20;

                addRows(ref DataRow, 0, (index + 1).ToString());
                addRows(ref DataRow, 1, item.CasePaperNumber);
                addRows(ref DataRow, 2, item.FullName);
                addRows(ref DataRow, 3, item.CreatedOn.Value.Date.ToShortDateString());
                addRows(ref DataRow, 4, item.CreatedOn.Value.ToShortTimeString());
                addRows(ref DataRow, 5, item.ReceivedName);
                addRows(ref DataRow, 6, item.IPDBillAmount.ToString(), false, HorizontalAlignment.Right);


                grandTotal = item.IPDBillAmount + grandTotal;
                index++;


            }

            //final total collection
            table.ApplyHorizontalMerge(index + 1, 0, 5);
            DataRow = table.Rows[index + 1];
            //Row Height
            DataRow.Height = 20;

            addRows(ref DataRow, 0, "Total", true);

            addRows(ref DataRow, 6, grandTotal.ToString(), true, HorizontalAlignment.Right);

        }

        private void createBody(ref Section section, List<OPDHistoryModel> model)
        {
            Paragraph para = section.AddParagraph();
            para.AppendText("");

            Table table = section.AddTable(true);
            //Create Header and Data
            String[] Header = { "Sr #", "Name", "DateTime", "OPD", "Lab+Other", "ECG", "X-Ray", "Paid", "Dues", "Total" };

            //Add Cells
            table.ResetCells(model.Count + 2, Header.Length);

            //Header Row
            TableRow FRow = table.Rows[0];
            FRow.IsHeader = true;

            //table.AutoFit(AutoFitBehaviorType.AutoFitToContents);

            //Row Height
            //FRow.Height = 23;

            //Header Format
            FRow.RowFormat.BackColor = Color.AliceBlue;

            for (int i = 0; i < Header.Length; i++)
            {
                //Cell Alignment
                Paragraph p = FRow.Cells[i].AddParagraph();
                FRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                //FRow.Cells[i].SetCellWidth(20, CellWidthType.Percentage);
                //Data Format
                TextRange TR = p.AppendText(Header[i]);
                TR.CharacterFormat.FontName = "Calibri";
                TR.CharacterFormat.FontSize = 8;
                TR.CharacterFormat.TextColor = Color.Black;
                TR.CharacterFormat.Bold = true;
            }

            //Column Width
            FRow.Cells[0].SetCellWidth(3, CellWidthType.Percentage);
            FRow.Cells[1].SetCellWidth(12, CellWidthType.Percentage);
            FRow.Cells[2].SetCellWidth(18, CellWidthType.Percentage);
            FRow.Cells[3].SetCellWidth(8, CellWidthType.Percentage);
            FRow.Cells[4].SetCellWidth(12, CellWidthType.Percentage);
            FRow.Cells[5].SetCellWidth(8, CellWidthType.Percentage);
            FRow.Cells[6].SetCellWidth(8, CellWidthType.Percentage);
            FRow.Cells[7].SetCellWidth(8, CellWidthType.Percentage);
            FRow.Cells[8].SetCellWidth(8, CellWidthType.Percentage);
            FRow.Cells[9].SetCellWidth(12, CellWidthType.Percentage);

            int index = 0;
            TableRow DataRow = table.Rows[index + 1];
            decimal? totalOPDAmount = 0.00M;
            decimal? totalLABAmount = 0.00M;
            decimal? totalECGAmount = 0.00M;
            decimal? totalXRAYAmount = 0.00M;
            decimal? totalThirdPartyLabAmount = 0.00M;
            decimal? totalPaidAmount = 0.00M;
            decimal? totalDuesAmount = 0.00M;
            decimal? grandTotal = 0.00M;
            foreach (var item in model)
            {
                if (index != 0)
                    DataRow = table.Rows[index + 1];

                //Row Height
                DataRow.Height = 20;

                addRows(ref DataRow, 0, (index + 1).ToString());

                addRows(ref DataRow, 1, item.PatientName);
                addRows(ref DataRow, 2, item.InTime.Value.Date.ToShortDateString() + " " + item.InTime.Value.ToShortTimeString());

                addRows(ref DataRow, 3, item.Amount.ToString());
                addRows(ref DataRow, 4, item.LabTestingAmount.ToString() + "+" + item.ThirdPartyLabAmoumt.ToString());
                if (item.TPLabs.Any())
                {
                    //table.ApplyHorizontalMerge(11, index + 1, index + 1);
                    table.ApplyVerticalMerge(4, index + 1, index + 1);
                    // add a nested table to cell(first row, second column)

                    Table nestedTable = table[index + 1, 4].AddTable(true);

                    nestedTable.ResetCells(item.TPLabs.Count + 1, 2);
                    nestedTable.AutoFit(AutoFitBehaviorType.AutoFitToContents);

                    //Create Header and Data
                    String[] nestedHeader = { "Name", "Amt" };
                    //Header Row
                    TableRow nestedFRow = nestedTable.Rows[0];
                    nestedFRow.IsHeader = true;




                    //Header Format                   
                    nestedFRow.RowFormat.BackColor = Color.AliceBlue;

                    for (int i = 0; i < nestedHeader.Length; i++)
                    {
                        //Cell Alignment
                        Paragraph p = nestedFRow.Cells[i].AddParagraph();
                        nestedFRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                        p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                        //nestedFRow.Cells[i].SetCellWidth(20, CellWidthType.Percentage);
                        //Data Format
                        TextRange TR = p.AppendText(nestedHeader[i]);
                        TR.CharacterFormat.FontName = "Calibri";
                        TR.CharacterFormat.FontSize = 8;
                        TR.CharacterFormat.TextColor = Color.Black;
                        TR.CharacterFormat.Bold = true;
                    }


                    int rowIndex = 0;
                    TableRow nestedDataRow = nestedTable.Rows[rowIndex + 1];
                    foreach (var itemValue in item.TPLabs)
                    {
                        if (rowIndex != 0)
                            nestedDataRow = nestedTable.Rows[rowIndex + 1];

                        addRows(ref nestedDataRow, 0, itemValue.Name.ToString(), false, 8, HorizontalAlignment.Left);
                        addRows(ref nestedDataRow, 1, itemValue.Rate.ToString(), false, 8, HorizontalAlignment.Right);
                        rowIndex++;

                    }

                }


                addRows(ref DataRow, 5, item.ECGAmount.ToString());
                addRows(ref DataRow, 6, item.XRAYAmount.ToString());


                addRows(ref DataRow, 7, item.PaidAmount.ToString());

                if (item.OPDHistoryUpdates.Any())
                {
                    //table.ApplyHorizontalMerge(11, index + 1, index + 1);
                    table.ApplyVerticalMerge(7, index + 1, index + 1);
                    // add a nested table to cell(first row, second column)

                    Table nestedTable = table[index + 1, 7].AddTable(true);

                    nestedTable.ResetCells(item.OPDHistoryUpdates.Count + 1, 2);
                    nestedTable.AutoFit(AutoFitBehaviorType.AutoFitToContents);

                    //Create Header and Data
                    String[] nestedHeader = { "Name", "Amt" };
                    //Header Row
                    TableRow nestedFRow = nestedTable.Rows[0];
                    nestedFRow.IsHeader = true;




                    //Header Format                   
                    nestedFRow.RowFormat.BackColor = Color.AliceBlue;

                    for (int i = 0; i < nestedHeader.Length; i++)
                    {
                        //Cell Alignment
                        Paragraph p = nestedFRow.Cells[i].AddParagraph();
                        nestedFRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                        p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                        //nestedFRow.Cells[i].SetCellWidth(20, CellWidthType.Percentage);
                        //Data Format
                        TextRange TR = p.AppendText(nestedHeader[i]);
                        TR.CharacterFormat.FontName = "Calibri";
                        TR.CharacterFormat.FontSize = 8;
                        TR.CharacterFormat.TextColor = Color.Black;
                        TR.CharacterFormat.Bold = true;
                    }


                    int rowIndex = 0;
                    TableRow nestedDataRow = nestedTable.Rows[rowIndex + 1];
                    foreach (var itemValue in item.OPDHistoryUpdates)
                    {
                        if (rowIndex != 0)
                            nestedDataRow = nestedTable.Rows[rowIndex + 1];

                        addRows(ref nestedDataRow, 0, itemValue.UpdatedName.ToString(), false, 8, HorizontalAlignment.Left);
                        addRows(ref nestedDataRow, 1, itemValue.UpdatedValue.ToString(), false, 8, HorizontalAlignment.Right);
                        rowIndex++;

                    }

                }


                addRows(ref DataRow, 8, item.DueAmount.ToString());
                addRows(ref DataRow, 9, item.TotalAmount.ToString());
                totalOPDAmount = item.Amount + totalOPDAmount;
                totalLABAmount = item.LabTestingAmount + totalLABAmount;
                totalECGAmount = item.ECGAmount + totalECGAmount;
                totalXRAYAmount = item.XRAYAmount + totalXRAYAmount;
                totalThirdPartyLabAmount = item.ThirdPartyLabAmoumt + totalThirdPartyLabAmount;
                totalPaidAmount = item.PaidAmount + totalPaidAmount;
                totalDuesAmount = item.DueAmount + totalDuesAmount;
                grandTotal = item.TotalAmount + grandTotal;


                index++;


            }
            decimal? labtotals = totalLABAmount + totalThirdPartyLabAmount;
            //final total collection
            table.ApplyHorizontalMerge(index + 1, 0, 2);
            DataRow = table.Rows[index + 1];
            //Row Height
            DataRow.Height = 20;

            addRows(ref DataRow, 0, "Total", true);

            addRows(ref DataRow, 3, totalOPDAmount.ToString(), true);
            addRows(ref DataRow, 4, labtotals.ToString(), true);
            addRows(ref DataRow, 5, totalECGAmount.ToString(), true);
            addRows(ref DataRow, 6, totalXRAYAmount.ToString(), true);
            addRows(ref DataRow, 7, totalPaidAmount.ToString(), true);
            addRows(ref DataRow, 8, totalDuesAmount.ToString(), true);
            addRows(ref DataRow, 9, grandTotal.ToString(), true);

        }

        private void addRows(ref TableRow DataRow, int index, string value)
        {
            //Cell Alignment
            DataRow.Cells[index].CellFormat.VerticalAlignment = VerticalAlignment.Middle;


            //Fill Data in Rows
            Paragraph p2 = DataRow.Cells[index].AddParagraph();
            TextRange TR2 = p2.AppendText(value);

            //Format Cells
            p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
            TR2.CharacterFormat.FontName = "Calibri";
            TR2.CharacterFormat.FontSize = 8;
            TR2.CharacterFormat.TextColor = Color.Black;
        }



        private void addRows(ref TableRow DataRow, int index, string value, bool isbold, HorizontalAlignment alignment = HorizontalAlignment.Center)
        {
            //Cell Alignment
            DataRow.Cells[index].CellFormat.VerticalAlignment = VerticalAlignment.Middle;

            //Fill Data in Rows
            Paragraph p2 = DataRow.Cells[index].AddParagraph();
            TextRange TR2 = p2.AppendText(value);

            //Format Cells
            p2.Format.HorizontalAlignment = alignment;
            TR2.CharacterFormat.FontName = "Calibri";
            TR2.CharacterFormat.FontSize = 8;
            TR2.CharacterFormat.TextColor = Color.Black;
            TR2.CharacterFormat.Bold = true;
        }

        private void addRows(ref TableRow DataRow, int index, string value, bool isbold, int fontSize, HorizontalAlignment alignment = HorizontalAlignment.Center)
        {
            //Cell Alignment
            DataRow.Cells[index].CellFormat.VerticalAlignment = VerticalAlignment.Middle;

            //Fill Data in Rows
            Paragraph p2 = DataRow.Cells[index].AddParagraph();
            TextRange TR2 = p2.AppendText(value);

            //Format Cells
            p2.Format.HorizontalAlignment = alignment;
            TR2.CharacterFormat.FontName = "Calibri";
            TR2.CharacterFormat.FontSize = fontSize;
            TR2.CharacterFormat.TextColor = Color.Black;
            TR2.CharacterFormat.Bold = true;
        }
        private void createHeader(ref Section section)
        {
            //Add Header

            HeaderFooter header = section.HeadersFooters.Header;
            setHeaderFont(ref header, "PARAMASHETTI", 15, "Calibri", true);
            setHeaderFont(ref header, "MULTI SPECIALITY HOSPITAL", 12, "Calibri");
            setHeaderFont(ref header, "Vishwas Estate, Miraj - Sangli Road, Miraj.", 12, "Calibri");
            setHeaderFont(ref header, "Phone: 0233 - 2212430, 2212431", 12, "Calibri", false, true);


        }

        private void setHeaderFont(ref HeaderFooter header, string value, int fontSize, string fontName, bool isBold = false, bool isBorder = false)
        {
            Paragraph paragraph = header.AddParagraph();
            TextRange tRange = paragraph.AppendText(value);
            tRange.CharacterFormat.FontName = fontName;
            tRange.CharacterFormat.FontSize = fontSize;
            tRange.CharacterFormat.Bold = isBold;
            tRange.CharacterFormat.TextColor = Color.Black;
            paragraph.Format.HorizontalAlignment = HorizontalAlignment.Center;
            paragraph.Format.TextAlignment = TextAlignment.Center;
            if (isBorder)
            {
                paragraph.Format.Borders.Bottom.BorderType = BorderStyle.ThickThinMediumGap;
                paragraph.Format.Borders.Bottom.Space = 0.05f;
                paragraph.Format.Borders.Bottom.Color = Color.Black;
            }
        }

        private void createFooter(ref Section section)
        {
            //Add Header

            HeaderFooter footer = section.HeadersFooters.Footer;
            Paragraph FParagraph = footer.AddParagraph();
            TextRange FText = FParagraph.AppendText("PARAMASHETTI, MULTI SPECIALITY HOSPITAL");

            FText.CharacterFormat.FontName = "Calibri";
            //Set Footer Text Format
            FText.CharacterFormat.FontSize = 12;
            FText.CharacterFormat.TextColor = Color.DarkGray;

            //Set Footer Paragrah Format
            FParagraph.Format.HorizontalAlignment = HorizontalAlignment.Right;
            FParagraph.Format.Borders.Top.BorderType = BorderStyle.Single;
            FParagraph.Format.Borders.Top.Space = 0.15f;
            FParagraph.Format.Borders.Color = Color.DarkGray;
        }
    }

}
