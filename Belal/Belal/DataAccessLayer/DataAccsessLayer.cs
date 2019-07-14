﻿using System;
using System.Data;
using System.Data.SqlClient;




namespace Belal.DataAccessLayer
{
    public class DataAccsessLayer
    {

        
        public string SqlConnection { get; set; } =
            @"Data Source=DESKTOP-LO44UHS\LAJJA;
           Initial Catalog=bel;
          Integrated Security=True";


        public string Server { get; set; } = "DESKTOP-LO44UHS\\LAJJA";


        public string Database { get; set; } = "bel";



        private SqlConnection _connection;

        public DataAccsessLayer()
        {
            InitializeConnection();
        }


        public DataAccsessLayer(string sqlConnection)
        {
            this.SqlConnection = sqlConnection;
            InitializeConnection();
        }
        public DataAccsessLayer(string server, string database)
        {
            this.Server = server;
            this.Database = database;
            this.SqlConnection = String.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", server, database);
            InitializeConnection();
        }
        public SqlConnection InitializeConnection()
        {
            _connection = new SqlConnection(SqlConnection);
            return _connection;
        }
        public void Open()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }
        public void Close()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        // DataAccessLayer.DataAccessLayer().EXECUTE("AddNewEmployees", parms.ToArray());
        public DataTable EXECUTE(string procedureName, SqlParameter[] param)
        {
            var cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName,
                Connection = _connection
            };

            if (param != null)
                cmd.Parameters.AddRange(param);


            var dt = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            Close();
            return dt;
        }
        public DataTable EXECUTE(string procedureName)
        {
            return EXECUTE(procedureName, null);
        }
        public int ExecuteProcedure(string procedureName, SqlParameter[] param)
        {
            var cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName,
                Connection = _connection
            };

            if (param != null)
                cmd.Parameters.AddRange(param);

            //this.Open();
            _connection.Open();
            var rows = cmd.ExecuteNonQuery();
            Close();
            return rows;
        }

        public int ExecuteProcedure(string procedureName)
        {
            return ExecuteProcedure(procedureName, null);
        }

    }
}