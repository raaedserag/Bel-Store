using Belal.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Belal.Helpers
{
    class CategoriesHelpers
    {
        public DataTable Get_categories()
        {
            
            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Get_categories", null);
        }
        public void AddNewCatogry(Categories categories)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@new_category", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = categories.Name;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Add_Category", parms.ToArray());
            
        }

        public DataTable SearchCategories(string search_key)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = search_key;

          return  new DataAccessLayer.DataAccsessLayer().EXECUTE("Search_categories", parms.ToArray());

        }
        public void DeleteCategory(string category_id)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = category_id;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Delete_category", parms.ToArray());

        }
        public void UpdateCategory(string category_id, string new_name)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = category_id;

            parms.Add(new SqlParameter("@new_name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_name;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Update_category", parms.ToArray());

        }
    }
}
