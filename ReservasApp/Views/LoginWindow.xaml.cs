using System;
using System.Windows;
using Microsoft.Data.SqlClient;
using ReservasApp.Data;

namespace ReservasApp.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Password;

            try
            {
                using (SqlConnection conexion = ConexionDB.ObtenerConexion())
                {
                    conexion.Open();

                    string sql = @"
                        SELECT COUNT(*)
                        FROM Usuarios
                        WHERE Username = @Username
                        AND Password = @Password";

                    SqlCommand comando = new SqlCommand(sql, conexion);

                    comando.Parameters.AddWithValue("@Username", usuario);
                    comando.Parameters.AddWithValue("@Password", password);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    if (cantidad > 0)
                    {
                        MessageBox.Show(
                            "Inicio de sesión correcto.",
                            "Bienvenido",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                        );

                        MainWindow ventana = new MainWindow();
                        ventana.Show();

                        Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Usuario o contraseña incorrectos.",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar con la base de datos.\n\n" +
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}