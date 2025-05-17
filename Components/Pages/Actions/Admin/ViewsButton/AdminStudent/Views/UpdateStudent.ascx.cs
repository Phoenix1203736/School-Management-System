using System;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views
{
    public partial class UpdateStudent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlResultados.Visible = false;
                lblMensaje.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            //    int userId;
            //    if (int.TryParse(txtUserId.Text, out userId))
            //    {
            //        try
            //        {
            //            // Aquí debes reemplazar con tu cadena de conexión
            //            string connectionString = "tu_cadena_de_conexion";

            //            using (SqlConnection connection = new SqlConnection(connectionString))
            //            {
            //                string query = @"SELECT FirstName, LastName, BirthDate, Email, Phone, DateEntry, Status
            //                                FROM Users
            //                                WHERE UserId = @UserId";

            //                using (SqlCommand command = new SqlCommand(query, connection))
            //                {
            //                    command.Parameters.AddWithValue("@UserId", userId);
            //                    connection.Open();

            //                    using (SqlDataReader reader = command.ExecuteReader())
            //                    {
            //                        if (reader.Read())
            //                        {
            //                            txtFirstName.Text = reader["FirstName"].ToString();
            //                            txtLastName.Text = reader["LastName"].ToString();

            //                            if (reader["BirthDate"] != DBNull.Value)
            //                                txtBirthDate.Text = Convert.ToDateTime(reader["BirthDate"]).ToShortDateString();

            //                            txtEmail.Text = reader["Email"].ToString();
            //                            txtPhone.Text = reader["Phone"].ToString();

            //                            if (reader["DateEntry"] != DBNull.Value)
            //                                txtDateEntry.Text = Convert.ToDateTime(reader["DateEntry"]).ToShortDateString();

            //                            ddlStatus.SelectedValue = reader["Status"].ToString();

            //                            pnlResultados.Visible = true;
            //                            lblMensaje.Visible = false;
            //                        }
            //                        else
            //                        {
            //                            pnlResultados.Visible = false;
            //                            MostrarMensaje("No se encontró ningún usuario con el ID proporcionado.");
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            pnlResultados.Visible = false;
            //            MostrarMensaje("Error al consultar el usuario: " + ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        MostrarMensaje("El ID de usuario debe ser un número válido.");
            //    }
            //}
        }

        // ReSharper disable once UnusedMember.Local
        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;
        }
    }
}