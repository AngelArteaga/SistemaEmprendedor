using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace Sistemaemprendedor.Models
{
    public class DBConection
    {
        private SqlDataReader sqlDataReader;
        private SqlConnection sqlConection;


        private SqlCommand cmdSQL;

        public DBConection()
        {
            sqlConection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        public int Execute(string query)
        {

            int result;
            if (SqlConection.State == System.Data.ConnectionState.Open)
            {
                cmdSQL = new SqlCommand(query, sqlConection);
                cmdSQL.CommandTimeout = 80;
                result = cmdSQL.ExecuteNonQuery();

            }
            else
            {
                sqlConection.Open();
                cmdSQL = new SqlCommand(query, sqlConection);
                cmdSQL.CommandTimeout = 80;
                result = cmdSQL.ExecuteNonQuery();

            }
            return result;
        }

        public SqlDataReader ExecuteQuery(string query)
        {
            if (SqlConection.State == System.Data.ConnectionState.Open)
            {
                cmdSQL = new SqlCommand(query, sqlConection);
                SqlDataReader = cmdSQL.ExecuteReader();

            }
            else
            {
                sqlConection.Open();
                cmdSQL = new SqlCommand(query, sqlConection);
                SqlDataReader = cmdSQL.ExecuteReader();
            }

            return SqlDataReader;
        }

        public SqlDataReader SqlDataReader
        {
            get { return sqlDataReader; }
            set { sqlDataReader = value; }
        }

        public void Cerrar()
        {
            SqlDataReader.Close();
            sqlConection.Close();
        }

        public SqlConnection SqlConection
        {
            get { return sqlConection; }
            set { sqlConection = value; }
        }
    }
}