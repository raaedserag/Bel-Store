using Belal.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Belal.Helpers
{
    class ProductHelper
    {
        public void AddNewProduct(Product product)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product.Name;

             parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@Quntity", SqlDbType.Int));
            parms[parms.Count - 1].Value = product.Quntity;

            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@Vendor", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product.Vendor;

            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@Barcode", SqlDbType.VarChar));
            parms[parms.Count - 1].Value = product.Barcode;


            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@Price", SqlDbType.Float));
            parms[parms.Count - 1].Value = product.Price;

            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@category_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = product.category_id;


            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("AddNewProduct", parms.ToArray());
            MessageBox.Show(@"تم إاضافة المنتج بنجاح");
        }



    }
}
