using System.Data;
using System.Windows;
using Microsoft.Data.SqlClient;
using ReservasApp.Data;

namespace ReservasApp.Views
{
    public partial class AulasDataTableWindow : Window
    {
        public AulasDataTableWindow()
        {
            InitializeComponent();
            CargarAulas();
        }

        private void CargarAulas()
        {
            try
            {
                using (SqlConnection conexion = ConexionDB.ObtenerConexion())
                {
                    string sql = @"
                        SELECT
                            AulaId,
                            Nombre,
                            Capacidad
                        FROM Aulas";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, conexion);

                    DataTable tabla =
                        new DataTable();

                    adapter.Fill(tabla);

                    dgAulas.ItemsSource =
                        tabla.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las aulas:\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}