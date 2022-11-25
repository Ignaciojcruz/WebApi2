
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
    public class TrackDAL
    {
        //conectar a BBDD
        string connString = ConfigurationManager.AppSettings["ConexionBD"];
        string Sp = "Sp_Track";

        //Inserta y actualiza
        public int Set_Track(Track track)
        {
            int resp = 0;
            string accion = "A1";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(track, accion, ref outError);

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
        public List<Track> Get_Track(Track track)
        {
            List<Track> list = new List<Track>();
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(track, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Track track2 = new Track();
                        track2.Id = Convert.ToInt32(row["Id"]);
                        track2.Name = row["Name"].ToString();
                        track2.Length = Convert.ToInt32(row["Length"]);                        
                        track2.IsDeleted = Convert.ToBoolean(row["isDeleted"]);
                        list.Add(track2);
                    }
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return list;
        }

        public Track Get_Track(int id)
        {
            Track track = new Track();
            Track track2 = new Track();
            string accion = "A2";
            string outError = "";
            track.Id = id;

            try
            {
                DataSet ds = retornaDs(track, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    track2.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    track2.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    track2.Length = Convert.ToInt32(ds.Tables[0].Rows[0]["Length"]);
                    track2.IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["isDeleted"]);
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return track2;
        }

        //eliminar datos
        public int Delete_Track(int id)
        {
            int resp = 0;
            string accion = "A3";
            string outError = "";
            Track track = new Track();
            track.Id = id;

            try
            {
                DataSet ds = retornaDs(track, accion, ref outError);

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

        private DataSet retornaDs(Track track, string accion, ref string outError)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectaDAL conecta = new ConectaDAL();
                SqlConnection connection = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(Sp, connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = accion;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = track.Id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = track.Name;                
                cmd.Parameters.Add("@Length", SqlDbType.Int).Value = track.Length;
                
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