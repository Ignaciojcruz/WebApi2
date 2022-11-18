
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
    public class CarDAL
    {
        //conectar a BBDD
        string connString = ConfigurationManager.AppSettings["ConexionBD"];
        string Sp = "Sp_Car";

        //Inserta y actualiza
        public int Set_Car(Car car)
        {
            int resp = 0;
            string accion = "A1";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(car, accion, ref outError);

                if(outError.Length > 0) throw new Exception(outError);
                if (ds.Tables[0].Rows.Count > 0) resp = Convert.ToInt32(ds.Tables[0].Rows[0]["resultado"]);
            }
            catch(Exception ex)
            {
                outError = ex.Message;
                resp = -1;
            }         
                                                                    
            return resp;
        }
                
        //retornar datos
        public List<Car> Get_Car(Car car)
        {
            List<Car> list = new List<Car>();
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(car, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Car car2 = new Car();
                        car2.Id = Convert.ToInt32(row["Id"]);
                        car2.Brand = row["Brand"].ToString();
                        car2.Model = row["Model"].ToString();
                        car2.Year = Convert.ToInt32(row["Year"]);
                        car2.IsDeleted = Convert.ToBoolean(row["isDeleted"]);
                        list.Add(car2);
                    }
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;
                
            }



            return list;
        }
                       
        //eliminar datos
        public int Delete_Car(Car car)
        {
            int resp = 0;
            string accion = "A3";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(car, accion, ref outError);

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

        private DataSet retornaDs(Car car, string accion, ref string outError)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectaDAL conecta = new ConectaDAL();
                SqlConnection connection = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(Sp, connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = accion;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = car.Id;
                cmd.Parameters.Add("@Brand", SqlDbType.VarChar).Value = car.Brand;
                cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = car.Model;
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = car.Year;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = car.Type;

                ds = conecta.GetDataSet(connection, cmd);
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return ds;
        }


    }
}