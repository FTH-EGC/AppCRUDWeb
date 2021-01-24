using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevWebApppb.Models.ViewModels;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DevWebApppb.DataAccess
{
    public class DataAccessLayer
    {

        public List<DatosViewModel>  GetData()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<DatosViewModel> lst = null;
            DatosViewModel objUsu = null;

            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "READ");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                lst = new List<DatosViewModel>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objUsu = new DatosViewModel();
                    objUsu.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    objUsu.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objUsu.Apellido_Paterno = ds.Tables[0].Rows[i]["apellido_paterno"].ToString();
                    objUsu.Apellido_Materno = ds.Tables[0].Rows[i]["apellido_materno"].ToString();
                    objUsu.Edad = ds.Tables[0].Rows[i]["edad"].ToString();
                    objUsu.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["isactive"]);

                    lst.Add(objUsu);
                }

                return lst;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                con.Close();
            }



        }
        public DatosViewModel GetUsuId(int usuId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            DatosViewModel objUsu = null;

            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SELECTID");
                cmd.Parameters.AddWithValue("@userId", usuId);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objUsu = new DatosViewModel();
                    objUsu.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    objUsu.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objUsu.Apellido_Paterno = ds.Tables[0].Rows[i]["apellido_paterno"].ToString();
                    objUsu.Apellido_Materno = ds.Tables[0].Rows[i]["apellido_materno"].ToString();
                    objUsu.Edad = ds.Tables[0].Rows[i]["edad"].ToString();
                    objUsu.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["isactive"]);

                }

                return objUsu;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public string INSERTDATA(DatosViewModel usuObj) {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Action", "CREATE");
                cmd.Parameters.AddWithValue("@nombre", usuObj.Nombre);
                cmd.Parameters.AddWithValue("@apellido_paterno", usuObj.Apellido_Paterno);
                cmd.Parameters.AddWithValue("@apellido_materno", usuObj.Apellido_Materno);
                cmd.Parameters.AddWithValue("@edad", usuObj.Edad);
                cmd.Parameters.AddWithValue("@isactive", usuObj.IsActive);

                result = cmd.ExecuteNonQuery().ToString();

                return result;


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally {
                con.Close();
            }
        }


        public string UPDATEUSER(DatosViewModel objUsu) {
            SqlConnection con = null;
            string result = "";

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@userId", objUsu.Id);
                cmd.Parameters.AddWithValue("@nombre", objUsu.Nombre);
                cmd.Parameters.AddWithValue("@apellido_paterno", objUsu.Apellido_Paterno);
                cmd.Parameters.AddWithValue("@apellido_materno", objUsu.Apellido_Materno);
                cmd.Parameters.AddWithValue("@edad", objUsu.Edad);
                cmd.Parameters.AddWithValue("@isactive", objUsu.IsActive);
                result = cmd.ExecuteNonQuery().ToString();
                return result;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally {
                con.Close();
            }


        }


        public int DELETE(int usuId) {
            SqlConnection con = null;
            try
            {
                int result;
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@userId", usuId);
                SqlDataAdapter da = new SqlDataAdapter();
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                con.Close();
            }
        
        }


    }
}