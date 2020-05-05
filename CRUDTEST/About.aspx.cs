using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDTEST
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarCiudadEstado();
            }
        }

        public void CargarCiudadEstado()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spsEstado";
                cmd.Connection = conn;
                conn.Open();
                ddlEstado.DataSource = cmd.ExecuteReader();
                ddlEstado.DataTextField = "nombre";
                ddlEstado.DataValueField = "idCiudadEstado";
                ddlEstado.DataBind();
                ddlEstado.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }

        }

        public void CargarMunicipio(long idCiudad)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spsMunicipio";
                cmd.Parameters.Add("@idCiudadEstado", SqlDbType.BigInt).Value = idCiudad;
                cmd.Connection = conn;
                conn.Open();
                ddlMunicipio.DataSource = cmd.ExecuteReader();
                ddlMunicipio.DataTextField = "nombre";
                ddlMunicipio.DataValueField = "idDelMun";
                ddlMunicipio.DataBind();
                ddlMunicipio.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }

        }

        public void CargarColonia(long idMunicipiod)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spsColonia";
                cmd.Parameters.Add("@idDelMun", SqlDbType.BigInt).Value = idMunicipiod;
                cmd.Connection = conn;
                conn.Open();
                ddlColonia.DataSource = cmd.ExecuteReader();
                ddlColonia.DataTextField = "nombre";
                ddlColonia.DataValueField = "idColonia";
                ddlColonia.DataBind();
                ddlColonia.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }


        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMunicipio.ClearSelection();
            ddlColonia.ClearSelection();
            CargarMunicipio(long.Parse(ddlEstado.SelectedValue));

        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlColonia.ClearSelection();
            CargarColonia(long.Parse(ddlMunicipio.SelectedValue));
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            validaUsuario();
        }
        public void validaUsuario()
        {   
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spValidaUsuario";
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = txtContrasena.Text;
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Response.Redirect(@"~\Default.aspx");
                    lblMensaje.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Usuario y/o contraseña incorrectos";
                }
                
            }
        }
    }
}