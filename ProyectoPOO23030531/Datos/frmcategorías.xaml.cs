using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            cargarfolio();
        }

        public void buscar() 
        {
            string query = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
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
        //private string miconexion = "Data Source=DESKTOP-LUQE5QD\\SQLEXPRESS01;Initial Catalog=NORTHWIND;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private void cargarfolio()
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

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            Clases.clcategorías categ = new Clases.clcategorías();
            Clases.conexion con = new Clases.conexion();
            if(con.Execute(categ.buscarTodos(),0) == true) 
            { 
                if(con.FieldValue !="")
                {
                    txtID.Text = con.FieldValue;
                    buscar();
                }
            }
        }
        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
            string querygrabar = "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)";
            string querymodificar = "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description WHERE CategoryId = @CategoryId";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {

                    // Modificar
                    SqlCommand cmdmodificar = new SqlCommand(querymodificar, conn);
                    cmdmodificar.Parameters.AddWithValue("@CategoryId", txtID.Text);
                    cmdmodificar.Parameters.AddWithValue("@CategoryName", txtNombre.Text);
                    cmdmodificar.Parameters.AddWithValue("@Descritpion", txtDescripción.Text);
                    // conn.Open();
                    reader.Close();
                    cmdmodificar.ExecuteNonQuery();
                }
                else
                {
                    // Grabar
                    SqlCommand cmdgrabar = new SqlCommand(querygrabar, conn);
                    cmdgrabar.Parameters.AddWithValue("@CategoryName", txtNombre.Text);
                    cmdgrabar.Parameters.AddWithValue("@Description", txtDescripción.Text);
                    // conn.Open();
                    reader.Close();
                    cmdgrabar.ExecuteNonQuery();
                    MessageBox.Show("Registro guardado correctamente");
                    txtID.Clear();
                    txtDescripción.Clear();
                    txtNombre.Clear();
                    cargarfolio();
                    txtNombre.Focus();
                }
                reader.Close();
            }
        }

        private void btnbasura_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Seguro de borrar el registro?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            string queryborrar = "delete FROM Categories WHERE CategoryId = @CategoryId";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
            if (result == MessageBoxResult.Yes)
            {
                SqlCommand cmdborrar = new SqlCommand(queryborrar, conn);
                cmdborrar.Parameters.AddWithValue("@CategoryId", txtID.Text);
                conn.Open();
                cmdborrar.ExecuteNonQuery(); 
                MessageBox.Show("Registro guardado correctamente");
                txtID.Clear();
                txtDescripción.Clear();
                txtNombre.Clear();
                cargarfolio();
                txtNombre.Focus();

            }
            else
            {
                MessageBox.Show("Borrad de registro cancelado");
            }

        }
    }
}