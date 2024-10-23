using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
            graba();
        }
        Clases.Clpaqueteria G;
        private void graba()
        {
            try
            {
                Clases.Clpaqueteria B = new Clases.Clpaqueteria(byte.Parse(txtID.Text));
                DataSet ds = new DataSet();
                Clases.conexion c = new Clases.conexion(B.consultari());
                ds = c.consultar();
                G = new Clases.Clpaqueteria((txtNombre.Text), txtTelefono.Text);
                c = new Clases.conexion();
                if (ds.Tables["Tabla"].Rows.Count > 0)
                {
                    //MessageBox.Show(c.EJECUTAR(G.modificar(), G.RegionId, G.RegionName));
                }

                else
                {

                    MessageBox.Show(c.EJECUTAR(G.grabar(), G.CompanyName1, G.Phone1));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void buscar()
        {

            string query = "SELECT * FROM Shippers WHERE ShipperID = @ShipperID";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShipperID", txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    // Asignar valores a las propiedades de la clase
                    txtNombre.Text = reader["CompanyName"].ToString();
                    txtTelefono.Text = reader["Phone"].ToString();
                    // this.Picture = (byte[])reader["Picture"];
                }
                else MessageBox.Show("No existe la categoría");
                reader.Close();
            }
        }
        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            Clases.Clpaqueteria categ = new Clases.Clpaqueteria();
            Clases.conexion con = new Clases.conexion();
            if (con.Execute(categ.buscarTodos(), 0) == true)
            {
                if (con.FieldValue != "")
                {
                    txtID.Text = con.FieldValue;
                    buscar();
                }
            }
        }

        private void btnbasura_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
