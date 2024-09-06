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
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTemas();
            }
            
        }
        private void CargarTemas()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-G0HN6SJ\\SQLEXPRESS01;Initial Catalog=Libreria;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            cn.Open();

            string query = "SELECT IdTema, Tema FROM Temas";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // Usa SqlDataReader para leer los datos
                SqlDataReader reader = cmd.ExecuteReader();
                ddlTemas.Items.Clear(); // Limpia los elementos anteriores

                while (reader.Read())
                {
                    string id = reader["IdTema"].ToString(); 
                    string nombre = reader["Tema"].ToString();
                    ddlTemas.Items.Add(new ListItem(nombre, id));
                }
            }
        }

        protected void btnLibros_Click(object sender, EventArgs e)
        {
            string temaSeleccionado = ddlTemas.SelectedValue;
            Response.Redirect($"Ejercicio3b.aspx?IdTema={temaSeleccionado}");
        }
    }
}