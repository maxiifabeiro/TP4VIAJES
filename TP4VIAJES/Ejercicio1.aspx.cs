using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP4VIAJES
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }

        protected void CargarProvincias()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Viajes;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            cn.Open();

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT IdProvincia, NombreProvincia FROM Provincias", cn);
            DataSet ds = new DataSet();
            cmd.Fill(ds, "Provincias");
            ddlProvinciaInicio.DataSource = ds.Tables["Provincias"];
            ddlProvinciaInicio.DataTextField = "NombreProvincia";
            ddlProvinciaInicio.DataValueField = "IdProvincia";

            ddlProvinciaInicio.DataBind();
            ddlProvinciaInicio.Items.Insert(0, new ListItem("--Selecciona una provincia--", ""));

            cn.Close();
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlProvinciaInicio.SelectedValue))
            {
                // Cargar localidades para Destino Inicio
                CargarLocalidades(ddlProvinciaInicio.SelectedValue);

                // Cargar provincias para Destino Final excluyendo la seleccionada en Destino Inicio
                CargarProvinciasExcluyendoInicio(ddlProvinciaInicio.SelectedValue);
            }
        }

        private void CargarLocalidades(string idProvincia)
        {
                SqlConnection cn = new SqlConnection("Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Viajes;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                cn.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT NombreLocalidad FROM Localidades WHERE IdProvincia = @IdProvincia", cn);
                cmd.SelectCommand.Parameters.AddWithValue("@IdProvincia", idProvincia);

                DataSet ds = new DataSet();
                cmd.Fill(ds, "Localidades");

                ddlLocalidadInicio.DataSource = ds.Tables["Localidades"];
                ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                ddlLocalidadInicio.DataBind();

                ddlLocalidadInicio.Items.Insert(0, new ListItem("--Selecciona una localidad--", ""));

                cn.Close();  
        }

        protected void CargarProvinciasExcluyendoInicio(string idProvinciaInicio)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Viajes;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            cn.Open();

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT IdProvincia, NombreProvincia FROM Provincias WHERE IdProvincia != @IdProvinciaInicio", cn);
            cmd.SelectCommand.Parameters.AddWithValue("@IdProvinciaInicio", idProvinciaInicio);

            DataSet ds = new DataSet();
            cmd.Fill(ds, "Provincias");

            ddlProvinciaFinal.DataSource = ds.Tables["Provincias"];
            ddlProvinciaFinal.DataTextField = "NombreProvincia";
            ddlProvinciaFinal.DataValueField = "IdProvincia";
            ddlProvinciaFinal.DataBind();

            ddlProvinciaFinal.Items.Insert(0, new ListItem("--Selecciona una provincia--", ""));

            cn.Close();
        }

        private void CargarLocalidadesFinal(string idProvincia)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Viajes;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            cn.Open();

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT NombreLocalidad FROM Localidades WHERE IdProvincia = @IdProvincia", cn);
            cmd.SelectCommand.Parameters.AddWithValue("@IdProvincia", idProvincia);

            DataSet ds = new DataSet();
            cmd.Fill(ds, "Localidades");

            ddlLocalidadFinal.DataSource = ds.Tables["Localidades"];
            ddlLocalidadFinal.DataTextField = "NombreLocalidad";
            ddlLocalidadFinal.DataBind();

            ddlLocalidadFinal.Items.Insert(0, new ListItem("--Selecciona una localidad--", ""));

            cn.Close();
        }

        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlProvinciaFinal.SelectedValue))
            {
                CargarLocalidadesFinal(ddlProvinciaFinal.SelectedValue);
            }
        }
    }
}