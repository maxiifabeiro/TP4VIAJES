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
    public partial class Ejercicio3b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IdTema = Request.QueryString["IdTema"];
                if (!string.IsNullOrEmpty(IdTema))
                {
                    MostrarLibros(IdTema);
                }
                else
                {
                    Response.Write("No se ha seleccionado ningún tema.");
                }
            }
        }

        private void MostrarLibros(string IdTema)
        {
            string connectionString = "Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Libreria;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string query = "SELECT * FROM Libros WHERE IdTema = @IdTema";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdTema", IdTema);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grvLibros.DataSource = dt;
                    grvLibros.DataBind();
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}