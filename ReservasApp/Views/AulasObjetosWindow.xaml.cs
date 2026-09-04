using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Data.SqlClient;
using ReservasApp.Data;
using ReservasApp.Models;

namespace ReservasApp.Views
{
    public partial class AulasObjetosWindow : Window
    {
        public AulasObjetosWindow()
        {
            InitializeComponent();
            CargarAulas();
        }

        private void CargarAulas()
        {
            List<Aula> aulas = new List<Aula>();

            try
            {
                using (SqlConnection conexion = ConexionDB.ObtenerConexion())
                {
                    conexion.Open();

                    string sql = @"
                        SELECT AulaId, Nombre, Capacidad
                        FROM Aulas";

                    SqlCommand comando =
                        new SqlCommand(sql, conexion);

                    SqlDataReader reader =
                        comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Aula aula = new Aula
                        {
                            AulaId = Convert.ToInt32(reader["AulaId"]),
                            Nombre = reader["Nombre"].ToString()!,
                            Capacidad = Convert.ToInt32(reader["Capacidad"])
                        };

                        aulas.Add(aula);
                    }
                }

                dgAulas.ItemsSource = aulas;
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

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            List<Aula> aulas = new List<Aula>();

            try
            {
                using (SqlConnection conexion = ConexionDB.ObtenerConexion())
                {
                    conexion.Open();

                    string sql = @"
                        SELECT AulaId, Nombre, Capacidad
                        FROM Aulas
                        WHERE Nombre LIKE @Nombre";

                    SqlCommand comando =
                        new SqlCommand(sql, conexion);

                    comando.Parameters.AddWithValue(
                        "@Nombre",
                        "%" + texto + "%"
                    );

                    SqlDataReader reader =
                        comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Aula aula = new Aula
                        {
                            AulaId = Convert.ToInt32(reader["AulaId"]),
                            Nombre = reader["Nombre"].ToString()!,
                            Capacidad = Convert.ToInt32(reader["Capacidad"])
                        };

                        aulas.Add(aula);
                    }
                }

                dgAulas.ItemsSource = aulas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar aulas:\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}