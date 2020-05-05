using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace MyLibrary
{
    public class ExportExcel
    {
        public static void ExportToExcel(DataGridView g, string path, ref string err, string tieudefile, string chantrang)
        {
            try
            {
                string _stoutput = tieudefile + " \n";
                string _sHearder = "";
                for (int i = 0; i < g.Columns.Count; i++)
                {
                    _sHearder = _sHearder.ToString() + Convert.ToString(g.Columns[i].HeaderText) + "\t";
                }
                _stoutput += _sHearder + "\r\n";
                for (int j = 0; j < g.RowCount; j++)
                {
                    string stline = "";
                    for (int k = 0; k < g.ColumnCount; k++)
                    {
                        stline = stline.ToString() + g.Rows[j].Cells[k].Value.ToString() + "\t";
                    }
                    _stoutput += stline + "\r\n";
                }
                _stoutput += "\n\n" + chantrang;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter bw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        bw.Write(_stoutput);
                    }
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
        }

        public static void ExportExcelByMicrosoft(DataGridView dgv, string title, string path, int colBegin)
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                return;
            }
            xlApp.Visible = false;

            object misValue = System.Reflection.Missing.Value;

            Excel.Workbook wb = xlApp.Workbooks.Add(misValue);

            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                MessageBox.Show("Không thể tạo được WorkSheet");
                return;
            }

            int row = 1;
            string fontName = "Times New Roman";
            int fontSizeTieuDe = 18;
            int fontSizeTenTruong = 14;
            int fontSizeNoiDung = 12;

            Excel.Range rangetitle = ws.get_Range("A1", "L1");
            rangetitle.Merge();
            rangetitle.Font.Bold = true;
            rangetitle.Font.Size = fontSizeTieuDe;
            rangetitle.Font.Name = fontName;
            rangetitle.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rangetitle.Value2 = title;

            Excel.Range titleTable;
            int col = colBegin;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                // char Cot = char.Parse((KyTu++).ToString());
                if (dgv.Columns[i].Visible == true)
                {
                    KeysConverter key = new KeysConverter();
                    String s = key.ConvertFromString((col++).ToString()).ToString();
                    //  MessageBox.Show(s);

                    titleTable = ws.get_Range(s + "2", s + "2");
                    titleTable.Font.Size = fontSizeTenTruong;
                    titleTable.Font.Name = fontName;
                    titleTable.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    titleTable.Value2 = dgv.Columns[i].HeaderText;
                    titleTable.ColumnWidth = dgv.Columns[i].HeaderText.Length + 5;
                }
            }
            titleTable = ws.get_Range("A2", "L2");
            titleTable.Interior.Color = ConsoleColor.Blue;
            //Để ghi nội dung
            int soDongCanGhi = dgv.RowCount + 3;
            Excel.Range contentTable;

            for (int i = 3; i < soDongCanGhi; i++)
            {

                col = colBegin;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible == true)
                    {
                        KeysConverter key = new KeysConverter();
                        String s = key.ConvertFromString((col++).ToString()).ToString();
                        contentTable = ws.get_Range(s + i, s + i);
                        contentTable.Font.Size = fontSizeNoiDung;
                        contentTable.Font.Name = fontName;
                        contentTable.Value2 = dgv.Rows[i - 3].Cells[j].Value.ToString();
                    }
                }
            }
            Excel.Range boderTable;
            boderTable = ws.get_Range("A2", string.Format("L{0}", soDongCanGhi - 1));
            BorderAround(boderTable);
            //Lưu file
            wb.SaveAs(path);

            //đóng file để hoàn tất quá trình lưu trữ
            wb.Close(true, misValue, misValue);
            //thoát và thu hồi bộ nhớ cho COM
            xlApp.Quit();
            releaseObject(ws);
            releaseObject(wb);
            releaseObject(xlApp);

            //Mở File excel sau khi Xuất thành công
            System.Diagnostics.Process.Start(path);

        }
        public static void ExportExcelByMicrosoft(DataGridView dgv, string title, string path, int colBegin, int rowBegin, int rowEnd)
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                return;
            }
            xlApp.Visible = false;

            object misValue = System.Reflection.Missing.Value;

            Excel.Workbook wb = xlApp.Workbooks.Add(misValue);

            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                MessageBox.Show("Không thể tạo được WorkSheet");
                return;
            }

            int row = 1;
            string fontName = "Times New Roman";
            int fontSizeTieuDe = 18;
            int fontSizeTenTruong = 14;
            int fontSizeNoiDung = 12;



            Excel.Range titleTable;
            int col = colBegin;
            int colNumber = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                // char Cot = char.Parse((KyTu++).ToString());
                if (dgv.Columns[i].Visible == true)
                {
                    KeysConverter key = new KeysConverter();
                    String s = key.ConvertFromString((col++).ToString()).ToString();
                    //  MessageBox.Show(s);
                    colNumber++;
                    titleTable = ws.get_Range(s + "2", s + "2");
                    titleTable.Font.Size = fontSizeTenTruong;
                    titleTable.Font.Name = fontName;
                    titleTable.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    titleTable.Value2 = dgv.Columns[i].HeaderText;
                    titleTable.ColumnWidth = dgv.Columns[i].HeaderText.Length + 5;
                }
            }

            //Để ghi nội dung
            int soDongCanGhi = dgv.RowCount + 3;
            Excel.Range contentTable;

            for (int i = 3; i < soDongCanGhi; i++)
            {

                col = colBegin;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible == true)
                    {
                        KeysConverter key = new KeysConverter();
                        String s = key.ConvertFromString((col++).ToString()).ToString();
                        contentTable = ws.get_Range(s + i, s + i);
                        contentTable.Font.Size = fontSizeNoiDung;
                        contentTable.Font.Name = fontName;
                        contentTable.Value2 = dgv.Rows[i - 3].Cells[j].Value.ToString();
                    }
                }
            }
            KeysConverter keys = new KeysConverter();
            String col1 = keys.ConvertFromString((colBegin).ToString()).ToString();
            String col2 = keys.ConvertFromString((colBegin + colNumber).ToString()).ToString();
            Excel.Range rangetitle = ws.get_Range("A1", col2 + "1");
            rangetitle.Merge();
            rangetitle.Font.Bold = true;
            rangetitle.Font.Size = fontSizeTieuDe;
            rangetitle.Font.Name = fontName;
            rangetitle.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rangetitle.Value2 = title;

            titleTable = ws.get_Range("A2", col2 + "2");
            titleTable.Interior.Color = ConsoleColor.Blue;

            Excel.Range boderTable;
            //KeysConverter keys = new KeysConverter();
            //String col1 = keys.ConvertFromString((colBegin).ToString()).ToString();
            //String col2 = keys.ConvertFromString((colBegin + colNumber).ToString()).ToString();
            //boderTable = ws.get_Range(col1+rowBegin.ToString(), string.Format("{0}{1}", col2,rowEnd));
            boderTable = ws.get_Range("A2").CurrentRegion;
            BorderAround(boderTable);
            //Lưu file
            wb.SaveAs(path);

            //đóng file để hoàn tất quá trình lưu trữ
            wb.Close(true, misValue, misValue);
            //thoát và thu hồi bộ nhớ cho COM
            xlApp.Quit();
            releaseObject(ws);
            releaseObject(wb);
            releaseObject(xlApp);

            //Mở File excel sau khi Xuất thành công
            System.Diagnostics.Process.Start(path);

        }
        public static void ExportExcelByMicrosoft(DataGridView dgv, string title, string path, int colBegin, string cellBegin)
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                return;
            }
            xlApp.Visible = false;

            object misValue = System.Reflection.Missing.Value;

            Excel.Workbook wb = xlApp.Workbooks.Add(misValue);

            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                MessageBox.Show("Không thể tạo được WorkSheet");
                return;
            }

            int row = 1;
            string fontName = "Times New Roman";
            int fontSizeTieuDe = 18;
            int fontSizeTenTruong = 14;
            int fontSizeNoiDung = 12;




            Excel.Range titleTable;
            int col = colBegin;
            int colNumber = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                // char Cot = char.Parse((KyTu++).ToString());
                if (dgv.Columns[i].Visible == true)
                {
                    KeysConverter key = new KeysConverter();
                    String s = key.ConvertFromString((col++).ToString()).ToString();
                    //  MessageBox.Show(s);
                    colNumber++;
                    titleTable = ws.get_Range(s + "2", s + "2");
                    titleTable.Font.Size = fontSizeTenTruong;
                    titleTable.Font.Name = fontName;
                    titleTable.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    titleTable.Value2 = dgv.Columns[i].HeaderText;
                    titleTable.ColumnWidth = dgv.Columns[i].HeaderText.Length + 5;
                }
            }
            titleTable = ws.get_Range("A2", "L2");
            titleTable.Interior.Color = ConsoleColor.Blue;
            //Để ghi nội dung
            int soDongCanGhi = dgv.RowCount + 3;
            Excel.Range contentTable;

            for (int i = 3; i < soDongCanGhi; i++)
            {

                col = colBegin;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible == true)
                    {
                        KeysConverter key = new KeysConverter();
                        String s = key.ConvertFromString((col++).ToString()).ToString();
                        contentTable = ws.get_Range(s + i, s + i);
                        contentTable.Font.Size = fontSizeNoiDung;
                        contentTable.Font.Name = fontName;
                        contentTable.Value2 = dgv.Rows[i - 3].Cells[j].Value.ToString();
                    }
                }
            }
            KeysConverter keys = new KeysConverter();
            String col1 = keys.ConvertFromString((colBegin).ToString()).ToString();
            String col2 = keys.ConvertFromString((colBegin + colNumber - 1).ToString()).ToString();
            Excel.Range rangetitle = ws.get_Range("A1", col2 + "1");
            rangetitle.Merge();
            rangetitle.Font.Bold = true;
            rangetitle.Font.Size = fontSizeTieuDe;
            rangetitle.Font.Name = fontName;
            rangetitle.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rangetitle.Value2 = title;

            titleTable = ws.get_Range("A2", col2 + "2");
            titleTable.Interior.Color = ConsoleColor.Blue;
            Excel.Range boderTable;

            boderTable = ws.get_Range(cellBegin).CurrentRegion;
            BorderAround(boderTable);
            //Lưu file
            wb.SaveAs(path);

            //đóng file để hoàn tất quá trình lưu trữ
            wb.Close(true, misValue, misValue);
            //thoát và thu hồi bộ nhớ cho COM
            xlApp.Quit();
            releaseObject(ws);
            releaseObject(wb);
            releaseObject(xlApp);

            //Mở File excel sau khi Xuất thành công
            System.Diagnostics.Process.Start(path);

        }
        private static void BorderAround(Excel.Range range)
        {
            Excel.Borders borders = range.Borders;
            borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Color = ConsoleColor.Black;
            borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }
    }
}
