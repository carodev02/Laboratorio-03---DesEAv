using System.Windows;
using ReservasApp.Views;

namespace ReservasApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AulasDataTable_Click(object sender, RoutedEventArgs e)
        {
            new AulasDataTableWindow().ShowDialog();
        }

        private void AulasObjetos_Click(object sender, RoutedEventArgs e)
        {
            new AulasObjetosWindow().ShowDialog();
        }

        private void ReservasDataTable_Click(object sender, RoutedEventArgs e)
        {
            MostrarModuloPendiente("Reservas - DataTable");
        }

        private void ReservasObjetos_Click(object sender, RoutedEventArgs e)
        {
            MostrarModuloPendiente("Reservas - Objetos");
        }

        private void NuevaReserva_Click(object sender, RoutedEventArgs e)
        {
            MostrarModuloPendiente("Nueva Reserva");
        }

        private static void MostrarModuloPendiente(string modulo)
        {
            MessageBox.Show(
                $"El módulo \"{modulo}\" todavía no está implementado.",
                "Módulo pendiente",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
