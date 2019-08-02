using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using Belal.Model; 
namespace Belal.Helpers
{
    class ExcelHandler
    {
        public WorkBook workbook;
        public WorkSheet sheet;
        

        private void load_file()
        {
            workbook = WorkBook.Load(Environment.GetEnvironmentVariable("belal_file_location", EnvironmentVariableTarget.User) + "\\receipt_temp.xlsx");
            sheet = workbook.WorkSheets.First();

        }
        private void styling_table(string cell_id, string cell_value, bool title, bool wrap, bool right, bool center)
        {
            // Value
            sheet[cell_id].Value = cell_value;
            sheet[cell_id].Style.Font.Name = "Calibri";

            // Allignment and Font
            if (title) // Footer Titles
            {
                sheet[cell_id].Style.Font.Height = 13;
                sheet[cell_id].Style.Font.Bold = true;
            }   
            else if(!title && center) // Table Cells
            {
                sheet[cell_id].Style.BottomBorder.SetColor("#22798E");
                sheet[cell_id].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;
                sheet[cell_id].Style.Font.Height = 11;
                sheet[cell_id].Style.Font.Bold = false;
                
                if (right)
                {
                    sheet[cell_id].Style.SetBackgroundColor("#DEF5FA");
                }
            }
            else // Footer & Header Cells
            {
                sheet[cell_id].Style.Font.Height = 11;
                sheet[cell_id].Style.Font.Bold = false;

            }

            if (wrap)
            {
                sheet[cell_id].Style.WrapText = true;
            }
            else
            {
                sheet[cell_id].Style.WrapText = false;
            }
            if(center)
            {
                sheet[cell_id].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            }
            else
            {
                sheet[cell_id].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
            }
            
            
            

        }

        public void Styling_receipt(Receipts receipt_data, DataTable products)
        {


            load_file();
            // Receipt Header

            styling_table("F2",receipt_data.Client_name, false, false, false, false);
            styling_table("F3", receipt_data.Client_address, false, false, false, false);
            styling_table("D2", receipt_data.Client_phone, false, false, false, false);
            styling_table("D3", receipt_data.Receipt_type, false, false, false, false);
            styling_table("B2", receipt_data.Id, false, false, false, false);
            styling_table("B3", receipt_data.Receipt_date, false, false, false, false);

            // Receipt Table
            int j = 6;
            for (int i = 0; i < products.Rows.Count; i++)  
            {
                styling_table("B" + j.ToString(), products.Rows[i]["category"].ToString(),
                    false, false, false, true);
                styling_table("C" + j.ToString(), products.Rows[i]["name"].ToString(),
                    false, false, false,  true);
                styling_table("D" + j.ToString(), products.Rows[i]["vendor"].ToString(),
                    false, false, false, true);
                styling_table("E" + j.ToString(), products.Rows[i]["quantity"].ToString(),
                    false, false, false, true);
                styling_table("F" + j.ToString(), products.Rows[i]["price"].ToString(),
                    false, false, false, true);
                styling_table("G" + j.ToString(), products.Rows[i]["total_price"].ToString(),
                    false, false, true, true);
                
                j++;
            }
            j++;

            // Receipt Footer
            styling_table("B" + j.ToString(), receipt_data.receipt_dis_total,
                    false, false, false, false);
            styling_table("C" + j.ToString(), "الاجمالي بعد الخصم",
                true, false, false, true);
            styling_table("D" + j.ToString(), receipt_data.receipt_dis + "%",
                false, false, false, false);
            styling_table("E" + j.ToString(), "الخصم",
                true, false, false, true);
            styling_table("F" + j.ToString(), receipt_data.receipt_total,
                false, false, false, false);
            styling_table("G" + j.ToString(), "اجمالي الفاتورة",
                true, false, true, true);

            j++;

            styling_table("B" + j.ToString(), receipt_data.Newbalance,
                    false, false, false, false);
            styling_table("C" + j.ToString(), "الرصيد الحالي",
                true, false, false, true);
            styling_table("D" + j.ToString(), receipt_data.Paid,
                false, false, false, false);
            styling_table("E" + j.ToString(), receipt_data.Pay_type,
                true, false, false, true);
            styling_table("F" + j.ToString(), receipt_data.Past_Balance,
                false, false, false, false);
            styling_table("G" + j.ToString(), "الرصيد السابق",
                true, false, true, true);

            j++;
            j++;
            styling_table("F" + j.ToString(), receipt_data.Readable_balance,
                    false, false, false, false);
            styling_table("G" + j.ToString(), "الرصيد الحالي بالأحرف",
                    true, false, false, true);

            j++;
            j++;

            styling_table("F" + j.ToString(), receipt_data.Notes,
                    false, false, false, false);
            styling_table("G" + j.ToString(), "ملاحظات",
                    true, false, false, true);

            workbook.SaveAs(Environment.GetEnvironmentVariable("belal_file_location", EnvironmentVariableTarget.User) + "\\test1.xlsx");
        }

    }
}
    