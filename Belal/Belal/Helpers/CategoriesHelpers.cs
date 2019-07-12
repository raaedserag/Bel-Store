using Belal.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Belal.Helpers
{
    class CategoriesHelpers
    {
        public void AddNewCatogry(Categories categories)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@new_category", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = categories.Name;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Add_Category", parms.ToArray());
            MessageBox.Show(@"تم إاضافة المنتج بنجاح");
        }

        public DataTable SearchCategories(string search_key)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = search_key;

          return  new DataAccessLayer.DataAccsessLayer().EXECUTE("Search_categories", parms.ToArray());

        }
    }
}
