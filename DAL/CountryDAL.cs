using WebApi2.Models;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Antlr.Runtime.Misc;
using System.Drawing;
using System.Collections.Generic;

namespace WebApi2.DAL
{
    public class CountryDAL
    {
        //conectar a BBDD
        string connString = ConfigurationManager.AppSettings["ConexionBD"];
        string Sp = "Sp_Country";

        //Inserta y actualiza
        public int Set_Country(Country country)
        {
            int resp = 0;
            string accion = "A1";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(country, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables[0].Rows.Count > 0) resp = Convert.ToInt32(ds.Tables[0].Rows[0]["resultado"]);
            }
            catch (Exception ex)
            {
                outError = ex.Message;
                resp = -1;
            }

            return resp;
        }

        //retornar datos
        public List<Country> Get_Country(Country country)
        {
            List<Country> list = new List<Country>();
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(country, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Country country2 = new Country();
                        country2.Id = Convert.ToInt32(row["Id"]);
                        country2.Name = row["Name"].ToString();                        
                        country2.IsDeleted = Convert.ToBoolean(row["isDeleted"]);
                        list.Add(country2);
                    }
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;

            }



            return list;
        }

        public Country Get_Country(int id)
        {
            Country country = new Country();
            Country country2 = new Country();
            country.Id = id;
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(country, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {

                    country2.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    country2.Name = ds.Tables[0].Rows[0]["Name"].ToString();                    
                    country2.IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["isDeleted"]);
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return country2;
        }

        //eliminar datos
        public int Delete_Country(int Id)
        {
            int resp = 0;

            string accion = "A3";
            string outError = "";

            Country country = new Country();
            country.Id = Id;

            try
            {
                DataSet ds = retornaDs(country, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables[0].Rows.Count > 0) resp = Convert.ToInt32(ds.Tables[0].Rows[0]["resultado"]);
            }
            catch (Exception ex)
            {
                outError = ex.Message;
                resp = -1;
            }

            return resp;
        }

        private DataSet retornaDs(Country country, string accion, ref string outError)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectaDAL conecta = new ConectaDAL();
                SqlConnection connection = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(Sp, connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = accion;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = country.Id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = country.Name;
                cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = country.IsDeleted;
                
                ds = conecta.GetDataSet(connection, cmd, ref outError);
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return ds;
        }
    }
}