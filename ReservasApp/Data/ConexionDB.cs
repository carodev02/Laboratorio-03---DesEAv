using Microsoft.Data.SqlClient;

namespace ReservasApp.Data
{
    public static class ConexionDB
    {
        public static string CadenaConexion =
            @"Server=LOLA\SQLEXPRESS;Database=ReservasDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}