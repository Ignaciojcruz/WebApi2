using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;

namespace WebApi2.DAL
{
    public class ConectaDAL
    {
        public DataSet GetDataSet(SqlConnection conn, SqlCommand cmd)
        {
            DataSet ds = new DataSet();

            try
            {
                conn.Open();

                using (conn)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    adapter.Fill(ds);
                }

                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {

            }

            return ds;
        }
    }
}