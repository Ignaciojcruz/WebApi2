
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApi2.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace WebApi2.DAL
{
    public class TrackTimeDAL
    {
        //conectar a BBDD
        string connString = ConfigurationManager.AppSettings["ConexionBD"];
        string Sp = "Sp_TrackTime";

        //Inserta y actualiza
        public int Set_TrackTime(TrackTime trackTime)
        {
            int resp = 0;
            string accion = "A1";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(trackTime, accion, ref outError);

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
        public List<TrackTime> Get_TrackTime(TrackTime trackTime)
        {
            List<TrackTime> list = new List<TrackTime>();
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(trackTime, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        TrackTime trackTime2 = new TrackTime();
                        trackTime2.Id = Convert.ToInt32(row["Id"]);
                        trackTime2.IdTrack = Convert.ToInt32(row["IdTrack"]);
                        trackTime2.IdCar = Convert.ToInt32(row["IdCar"]);
                        trackTime2.BestTimeLap = TimeSpan.Parse(row["BestTimeLap"].ToString());
                        list.Add(trackTime2);
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
        public int Delete_TrackTime(TrackTime trackTime)
        {
            int resp = 0;
            string accion = "A3";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(trackTime, accion, ref outError);

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

        private DataSet retornaDs(TrackTime trackTime, string accion, ref string outError)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectaDAL conecta = new ConectaDAL();
                SqlConnection connection = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(Sp, connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = accion;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = trackTime.Id;
                cmd.Parameters.Add("@IdTrack", SqlDbType.Int).Value = trackTime.IdTrack;
                cmd.Parameters.Add("@IdCar", SqlDbType.Int).Value = trackTime.IdCar;
                cmd.Parameters.Add("@BestTimeLap", SqlDbType.Time).Value = trackTime.BestTimeLap;
                
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