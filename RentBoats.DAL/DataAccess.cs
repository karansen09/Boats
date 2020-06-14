using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace RentBoats.DAL
{
    public class DataAccess
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()) + "/RentBoats").AddJsonFile("appsettings.json", false).Build();

        private static string ConnectionString = configuration.GetConnectionString("Default");

        
        public static SqlCommand GetCommand()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            return cmd;
        }

        public static string ExecureScaler(SqlCommand cmd)
        {
            string str = null;
            try
            {
                cmd.Connection.Open();
                str = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

            return str;
        }


        public static string ExecuteNonQuery(SqlCommand cmd)
        {
            string str = null;
            try
            {
                cmd.Connection.Open();
                str = cmd.ExecuteNonQuery().ToString();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
            return str;
        }

        public static DataTable ExecuteTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                //cmd.Connection.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

    }
}
