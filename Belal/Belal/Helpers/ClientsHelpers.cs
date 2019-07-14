using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Belal.Model;
using System.Windows.Forms;
namespace Belal.Helpers


{
    class ClientsHelpers
    {
        public void AddNewClient(Client new_client)
        {

            var parms = new List<SqlParameter>();
            
            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_client.Name;

            parms.Add(new SqlParameter("@phone", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_client.Phone;
            
            parms.Add(new SqlParameter("@address", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_client.Address;
            
            parms.Add(new SqlParameter("@paid", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_client.Paid;
            
            parms.Add(new SqlParameter("@owed", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_client.Owed;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Add_client", parms.ToArray());
            MessageBox.Show(@"تم إاضافة العميل بنجاح");
        }
        public DataTable SearchClients(string search_key)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = search_key;

            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Search_clients_name", parms.ToArray());

        }
        public void DeleteClient(string client_id)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = client_id;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Delete_client", parms.ToArray());

        }
        public void UpdateClient(string client_id, string new_name, string new_phone, string new_address, string new_paid, string new_owed)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = client_id;

            parms.Add(new SqlParameter("@name", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_name;

            parms.Add(new SqlParameter("@phone", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_phone;

            parms.Add(new SqlParameter("@address", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_address;

            parms.Add(new SqlParameter("@paid", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_paid;

            parms.Add(new SqlParameter("@owed", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_owed;

            new DataAccessLayer.DataAccsessLayer().ExecuteProcedure("Update_client", parms.ToArray());

        }
        public DataTable GetClient(string client_id)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@client_id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = client_id;

            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Get_client", parms.ToArray());

        }
        public DataTable Pay_Cash(string client_id, string new_pay)
        {
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@id", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = client_id;

            parms.Add(new SqlParameter("@new_pay", SqlDbType.NVarChar));
            parms[parms.Count - 1].Value = new_pay;

            return new DataAccessLayer.DataAccsessLayer().EXECUTE("Pay_cash", parms.ToArray());

        }

    }
}
