using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApi2.Models;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace WebApi2.DAL
{
    public class BrandDAL
    {
        //conectar a BBDD
        string connString = ConfigurationManager.AppSettings["ConexionBD"];
        string Sp = "Sp_Brand";

        //Inserta y actualiza
        public int Set_Brand(Brand brand)
        {
            int resp = 0;
            string accion = "A1";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(brand, accion, ref outError);

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
        public List<Brand> Get_Brand(Brand brand)
        {
            List<Brand> list = new List<Brand>();
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(brand, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Brand brand2 = new Brand();
                        brand2.Id = Convert.ToInt32(row["Id"]);
                        brand2.Name = row["Name"].ToString();
                        brand2.IdCountry = Convert.ToInt32(row["IdCountry"]);                        
                        brand2.IsDeleted = Convert.ToBoolean(row["isDeleted"]);
                        list.Add(brand2);
                    }
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;

            }



            return list;
        }

        public Brand Get_Brand(int id)
        {
            Brand brand = new Brand();
            Brand brand2 = new Brand();
            brand.Id = id;
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(brand, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {

                    brand2.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    brand2.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    brand2.IdCountry = Convert.ToInt32(ds.Tables[0].Rows[0]["IdCountry"]);                    
                    brand2.IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["isDeleted"]);
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return brand2;
        }

        //eliminar datos
        public int Delete_Brand(int Id)
        {
            int resp = 0;

            string accion = "A3";
            string outError = "";

            Brand brand = new Brand();
            brand.Id = Id;

            try
            {
                DataSet ds = retornaDs(brand, accion, ref outError);

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

        private DataSet retornaDs(Brand brand, string accion, ref string outError)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectaDAL conecta = new ConectaDAL();
                SqlConnection connection = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(Sp, connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = accion;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = brand.Id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = brand.Name;
                cmd.Parameters.Add("@IdCountry", SqlDbType.Int).Value = brand.IdCountry;                
                cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = brand.IsDeleted;

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