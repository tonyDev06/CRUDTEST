using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace CRUDTEST
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatosAlumno();
            }
        }
        public void CargaDatosAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSalumnos";
                cmd.Connection = conn;
                conn.Open();
                gvdAlumnos.DataSource = cmd.ExecuteReader();
                gvdAlumnos.DataBind();
            }
        }
        
            public void GuardaAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIalumnos";
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text.Trim();
                cmd.Parameters.Add("@apPaterno", SqlDbType.VarChar).Value = txtApPaterno.Text.Trim();
                cmd.Parameters.Add("@apMaterno", SqlDbType.VarChar).Value = txtApMaterno.Text.Trim();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlDatoaAlumno.Visible = false;
            pnlAltaAlumno.Visible = true;
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pnlAltaAlumno.Visible = false;
            pnlDatoaAlumno.Visible = true;
            GuardaAlumno();
            CargaDatosAlumno();
        }

        protected void gvdAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvdAlumnos.Rows[e.RowIndex];
            // eliminarAlumno(gvdAlumnos.DataKeys[e.RowIndex].Value.ToString());
            bajaAlumno(gvdAlumnos.DataKeys[e.RowIndex].Value.ToString());
            CargaDatosAlumno();
        }

        public void bajaAlumno(string idAlumno)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBajaAlumno";
                cmd.Parameters.Add("@idAlumno", SqlDbType.BigInt).Value = Int64.Parse(idAlumno);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
            public void eliminarAlumno(string idAlumno)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPDalumnos";
                cmd.Parameters.Add("@idAlumno", SqlDbType.BigInt).Value = Int64.Parse(idAlumno);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void actulizarAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUalumnos";
                cmd.Parameters.Add("@idAlumno", SqlDbType.BigInt).Value = long.Parse(lblIdAlumno.Text);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text.Trim();
                cmd.Parameters.Add("@apPaterno", SqlDbType.VarChar).Value = txtApPaterno.Text.Trim();
                cmd.Parameters.Add("@apMaterno", SqlDbType.VarChar).Value = txtApMaterno.Text.Trim();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void lkbActualizar_Click(object sender, EventArgs e)
        {
            pnlAltaAlumno.Visible = true;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            gvdAlumnos.SelectedIndex = row.RowIndex;
            lblIdAlumno.Text = row.Cells[0].Text;
            txtNombre.Text = row.Cells[1].Text;
            txtApPaterno.Text = row.Cells[2].Text;
            txtApMaterno.Text = row.Cells[3].Text;
            txtEmail.Text = row.Cells[4].Text;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            pnlAltaAlumno.Visible = false;
            pnlDatoaAlumno.Visible = true;
            actulizarAlumno();
            lblIdAlumno.Text = "";
            btnActualizar.Visible = false;
            btnGuardar.Visible = true;
            CargaDatosAlumno();
        }

        public void BusquedaAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSalumnosPorNombre";
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombreBus.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                gvdAlumnos.DataSource = cmd.ExecuteReader();
                gvdAlumnos.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaAlumno();
        }
    }
}