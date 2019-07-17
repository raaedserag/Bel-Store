using Belal.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Belal.Helpers
{
    class ProductHelper
    {
        public DataTable Get_products()
        {
            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Get_products", null);
        }

        public void AddNewProduct(Product product)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product.Name;


            parms.Add(new SqlParameter("@quantity", SqlDbType.Int));
            parms[parms.Count - 1].Value = product.Quntity;

            parms.Add(new SqlParameter("@vendor", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product.Vendor;

            parms.Add(new SqlParameter("@barcode", SqlDbType.VarChar));
            parms[parms.Count - 1].Value = product.Barcode;


            parms.Add(new SqlParameter("@price", SqlDbType.Float));
            parms[parms.Count - 1].Value = product.Price;


            parms.Add(new SqlParameter("@category_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = product.category_id;


            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Add_new_product", parms.ToArray());
        }

        public void DeleteProduct(string product_id)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product_id;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Delete_product", parms.ToArray());

        }

        public void UpdateProduct(Product product)
        {
            var parms = new List<SqlParameter>();
            
            parms.Add(new SqlParameter("@id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product.Id;

            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product.Name;

            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@quantity", SqlDbType.Int));
            parms[parms.Count - 1].Value = product.Quntity;

            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@vendor", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product.Vendor;

            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@barcode", SqlDbType.VarChar));
            parms[parms.Count - 1].Value = product.Barcode;


            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@price", SqlDbType.Float));
            parms[parms.Count - 1].Value = product.Price;

            parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@category_id", SqlDbType.Int));
            parms[parms.Count - 1].Value = product.category_id;


            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Update_product", parms.ToArray());
             
        }


        public DataTable SearchProductsBarcode(string barcode)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@barcode", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = barcode;

            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Search_products_barcode", parms.ToArray());

        }

        public DataTable SearchProductsName(string name)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = name;

            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Search_products_name", parms.ToArray());
        }

        public DataTable SearchProductsCategory(string category_id)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@category_id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = category_id;

            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Search_products_category", parms.ToArray());
        }

        public DataTable SearchProductsVendor(string vendor)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@vendor", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = vendor;

            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Search_products_vendor", parms.ToArray());
        }
        public void PushProduct(string product_id, string quantity)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@product_id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = product_id;

            parms.Add(new SqlParameter("@pushed_quantity", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = quantity;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Push_product", parms.ToArray());

        }
        

    }
}
