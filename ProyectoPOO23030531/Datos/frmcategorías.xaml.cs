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
    /// Lógica de interacción para frmcategorías.xaml
    /// </summary>
    public partial class frmcategorías : Window
    {
        public frmcategorías()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM categorias WHERE CategoryId = @CategoryId";
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LUQE5QD\\SQLEXPRESS01;Initial Catalog=NORTHWIND;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    // Asignar valores a las propiedades de la clase
                    txtNombre.Text = reader["CategoryName"].ToString();
                    txtDescripción.Text = reader["Description"].ToString();
                    // this.Picture = (byte[])reader["Picture"];
                }
                else MessageBox.Show("No existe la categoría");
                reader.Close();
            }
        }
    }

}