using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Belal.DataAccessLayer;
using NumberToWord;

namespace Belal.Helpers
{
    class ReceiptsHelpers
    {

        
        public DataRow Generate_receipt(string client_id)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@client_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(client_id);

            return new DataAccsessLayer().EXECUTE("Generate_recipt", parms.ToArray()).Rows[0];
            
        }

        public DataRow Generate_Returned_receipt(string client_id)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@client_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(client_id);

            return new DataAccsessLayer().EXECUTE("Generate_Returnedrecipt", parms.ToArray()).Rows[0];

        }
        public void Add_entry(string product_id, string receipt_id, string quantity)
        {
            var parms = new List<SqlParameter>();

            parms.Add(new SqlParameter("@product_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(product_id);

            parms.Add(new SqlParameter("@receipt_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(receipt_id);

            parms.Add(new SqlParameter("@quantity", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(quantity);

            new DataAccsessLayer().ExecuteProcedure("Add_entry", parms.ToArray());
        }

        public void Add_Returnedentry(string product_id, string receipt_id, string quantity)
        {
            var parms = new List<SqlParameter>();

            parms.Add(new SqlParameter("@product_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(product_id);

            parms.Add(new SqlParameter("@receipt_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(receipt_id);

            parms.Add(new SqlParameter("@quantity", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(quantity);

            new DataAccsessLayer().ExecuteProcedure("Add_Returnedentry", parms.ToArray());
        }

        public DataTable Create_receipt(string receipt_id, string client_id, string paid, string readable_balance,
            string notes)
        {
            var parms = new List<SqlParameter>();

            parms.Add(new SqlParameter("@receipt_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(receipt_id);

            parms.Add(new SqlParameter("@client_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(client_id);

            parms.Add(new SqlParameter("@paid", SqlDbType.Float));
            parms[parms.Count - 1].Value = float.Parse(paid);

            parms.Add(new SqlParameter("@readable_balance", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = readable_balance;

            parms.Add(new SqlParameter("@notes", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = notes;

            return new DataAccsessLayer().EXECUTE("Create_receipt", parms.ToArray());

        }


        public DataTable Create_Returned_receipt(string receipt_id, string client_id, string received, string readable_balance,
            string notes)
        {
            var parms = new List<SqlParameter>();

            parms.Add(new SqlParameter("@receipt_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(receipt_id);

            parms.Add(new SqlParameter("@client_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(client_id);

            parms.Add(new SqlParameter("@received", SqlDbType.Float));
            parms[parms.Count - 1].Value = float.Parse(received);

            parms.Add(new SqlParameter("@readable_balance", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = readable_balance;

            parms.Add(new SqlParameter("@notes", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = notes;

            return new DataAccsessLayer().EXECUTE("Create_Returnedreceipt", parms.ToArray());

        }

        public DataTable Get_receipt_products(string receipt_id)
        {
            var parms = new List<SqlParameter>();

            parms.Add(new SqlParameter("@receipt_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(receipt_id);


            return new DataAccsessLayer().EXECUTE("Get_receipt_products", parms.ToArray());
        }

        public DataTable Get_Returnedreceipt_products(string receipt_id)
        {
            var parms = new List<SqlParameter>();

            parms.Add(new SqlParameter("@receipt_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = int.Parse(receipt_id);


            return new DataAccsessLayer().EXECUTE("Get_Returnedreceipt_products", parms.ToArray());
        }

        public string read_balance(string balance)
        {
            float result = float.Parse(balance);
            if ( result >= 0)
            {
                return "له " + new ToWord(Convert.ToDecimal(balance), new CurrencyInfo()).ConvertToArabic();
            }
            else
            {
                
                return "مدين ب" + new ToWord(Convert.ToDecimal((0-result).ToString()), new CurrencyInfo()).ConvertToArabic();
            }
            
        }
    }
}
