using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4VIAJES
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFiltros();
            }
        }

        private void CargarTodosLosProductos()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            cn.Open();

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Productos", cn);
            DataSet ds = new DataSet();
            cmd.Fill(ds, "Productos");

            grvColumna.DataSource = ds.Tables["Productos"];
            grvColumna.DataBind();

            cn.Close();
        }

        private void CargarFiltros()
        {
            ddlProducto.Items.Add(new ListItem("Igual a:", "1"));
            ddlProducto.Items.Add(new ListItem("Mayor a:", "2"));
            ddlProducto.Items.Add(new ListItem("Menor a:", "3"));
            ddlCategoria.Items.Add(new ListItem("Igual a:", "1"));
            ddlCategoria.Items.Add(new ListItem("Mayor a:", "2"));
            ddlCategoria.Items.Add(new ListItem("Menor a:", "3"));
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string idProducto = txtProducto.Text.Trim();
            string idCategoria = txtCategoria.Text.Trim();
            string filtroProducto = ddlProducto.SelectedValue;
            string filtroCategoria = ddlCategoria.SelectedValue;

            FiltrarProductos(idProducto, filtroProducto, idCategoria, filtroCategoria);

            txtProducto.Text = string.Empty;
            txtCategoria.Text = string.Empty;
        }

        private void FiltrarProductos(string idProducto, string filtroProducto, string idCategoria, string filtroCategoria)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            cn.Open();

            string query = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE 1=1"; // 1=1 para simplificar

            // Si se ingresa valor al textbox de producto lo filtro
            if (!string.IsNullOrEmpty(idProducto))
            {
                switch (filtroProducto)
                {
                    case "1":  // Igual a
                        query += " AND IdProducto = @IdProducto";
                        break;
                    case "2":  // Mayor a
                        query += " AND IdProducto > @IdProducto";
                        break;
                    case "3":  // Menor a
                        query += " AND IdProducto < @IdProducto";
                        break;
                }
            }

            // Si se ingresa valor al textbox de categoria lo filtro
            if (!string.IsNullOrEmpty(idCategoria))
            {
                switch (filtroCategoria)
                {
                    case "1":  // Igual a
                        query += " AND IdCategoría = @IdCategoría";
                        break;
                    case "2":  // Mayor a
                        query += " AND IdCategoría > @IdCategoría";
                        break;
                    case "3":  // Menor a
                        query += " AND IdCategoría < @IdCategoría";
                        break;
                }
            }

            SqlDataAdapter cmd = new SqlDataAdapter(query, cn);
            if (!string.IsNullOrEmpty(idProducto))
            {
                cmd.SelectCommand.Parameters.AddWithValue("@IdProducto", idProducto);
            }
            if (!string.IsNullOrEmpty(idCategoria))
            {
                cmd.SelectCommand.Parameters.AddWithValue("@IdCategoría", idCategoria);
            }

            DataSet ds = new DataSet();
            cmd.Fill(ds, "Productos");
            grvColumna.DataSource = ds.Tables["Productos"];
            grvColumna.DataBind();

            cn.Close();
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            FiltrarProductos(null, null, null, null);
        }
    }
}
