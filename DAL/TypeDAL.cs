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
    public class TypeDAL
    {
        //conectar a BBDD
        string connString = ConfigurationManager.AppSettings["ConexionBD"];
        string Sp = "Sp_Type";

        //Inserta y actualiza
        public int Set_Type(WebApi2.Models.Type type)
        {
            int resp = 0;
            string accion = "A1";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(type, accion, ref outError);

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
        public List<WebApi2.Models.Type> Get_Type(WebApi2.Models.Type type)
        {
            List<WebApi2.Models.Type> list = new List<WebApi2.Models.Type>();
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(type, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        WebApi2.Models.Type type2 = new WebApi2.Models.Type();
                        type2.Id = Convert.ToInt32(row["Id"]);
                        type2.Name = row["Name"].ToString();
                        type2.IsDeleted = Convert.ToBoolean(row["isDeleted"]);
                        list.Add(type2);
                    }
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;

            }



            return list;
        }

        public WebApi2.Models.Type Get_Type(int id)
        {
            WebApi2.Models.Type type = new WebApi2.Models.Type();
            WebApi2.Models.Type type2 = new WebApi2.Models.Type();
            type.Id = id;
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(type, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {

                    type2.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    type2.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    type2.IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["isDeleted"]);
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return type2;
        }

        //eliminar datos
        public int Delete_Type(int Id)
        {
            int resp = 0;

            string accion = "A3";
            string outError = "";

            WebApi2.Models.Type type = new WebApi2.Models.Type();
            type.Id = Id;

            try
            {
                DataSet ds = retornaDs(type, accion, ref outError);

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

        private DataSet retornaDs(WebApi2.Models.Type type, string accion, ref string outError)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectaDAL conecta = new ConectaDAL();
                SqlConnection connection = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(Sp, connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = accion;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = type.Id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = type.Name;
                cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = type.IsDeleted;

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