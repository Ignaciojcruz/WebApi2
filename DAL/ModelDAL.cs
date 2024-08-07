﻿using WebApi2.Models;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Antlr.Runtime.Misc;
using System.Drawing;
using System.Collections.Generic;

namespace WebApi2.DAL
{
    public class ModelDAL
    {
        //conectar a BBDD
        string connString = ConfigurationManager.AppSettings["ConexionBD"];
        string Sp = "Sp_Model";

        //Inserta y actualiza
        public int Set_Model(Model model)
        {
            int resp = 0;
            string accion = "A1";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(model, accion, ref outError);

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
        public List<Model> Get_Model(Model model)
        {
            List<Model> list = new List<Model>();
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(model, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Model model2 = new Model();
                        model2.Id = Convert.ToInt32(row["Id"]);
                        model2.Name = row["Name"].ToString();
                        model2.IdBrand = Convert.ToInt32(row["IdBrand"]);
                        model2.IsDeleted = Convert.ToBoolean(row["isDeleted"]);
                        list.Add(model2);
                    }
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;

            }



            return list;
        }

        public Model Get_Model(int id)
        {
            Model model = new Model();
            Model model2 = new Model();
            model.Id = id;
            string accion = "A2";
            string outError = "";

            try
            {
                DataSet ds = retornaDs(model, accion, ref outError);

                if (outError.Length > 0) throw new Exception(outError);
                if (ds.Tables.Count > 0)
                {
                    model2.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    model2.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    model2.IdBrand = Convert.ToInt32(ds.Tables[0].Rows[0]["IdBrand"]);
                    model2.IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["isDeleted"]);
                }
            }
            catch (Exception ex)
            {
                outError = ex.Message;
            }

            return model2;
        }

        //eliminar datos
        public int Delete_Model(int Id)
        {
            int resp = 0;

            string accion = "A3";
            string outError = "";

            Model model = new Model();
            model.Id = Id;

            try
            {
                DataSet ds = retornaDs(model, accion, ref outError);

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

        private DataSet retornaDs(Model model, string accion, ref string outError)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectaDAL conecta = new ConectaDAL();
                SqlConnection connection = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(Sp, connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = accion;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@IdBrand", SqlDbType.Int).Value = model.IdBrand;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = model.Name;
                cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = model.IsDeleted;

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