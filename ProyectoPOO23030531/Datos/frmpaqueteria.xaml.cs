using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoPOO23030531.Datos
{
    /// <summary>
    /// Lógica de interacción para frmpaqueteria.xaml
    /// </summary>
    public partial class frmpaqueteria : Window
    {
        public frmpaqueteria()
        {
            InitializeComponent();
            cargarfolio();
        }

        public void cargarfolio()
        {
            string query = "SELECT MAX(CategoryID)+1 AS FOLIO FROM Categories;";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    // Asignar valores a las propiedades de la clase
                    txtID.Text = reader["Folio"].ToString();
                }
                reader.Close();
            }
        }
        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnbasura_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
