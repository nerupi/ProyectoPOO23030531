using System;
using System.Collections;
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
    /// Lógica de interacción para frmregiones.xaml
    /// </summary>
    public partial class frmregiones : Window
    {
        public frmregiones()
        {
            InitializeComponent();
            cargarfolio();
        }
        private void cargarfolio() 
        {
            //string sql = "select max(regionID)+1 as folio from region";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_folio_region", conn);
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read()) 
                {
                    txtID.Text = reader.GetInt32(0).ToString();
                }
                reader.Close();
            }
        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            //string query = "SELECT * FROM Region WHERE RegionId = @RegionId";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_busca_region", conn); 
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegionId", txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Asignar valores a las propiedades de la clase
                    txtID.Text = reader["RegionID"].ToString();
                    txtDescripción.Text = reader["RegionDescription"].ToString();
                    //this.Picture = (byte[])reader["Picture"];
                }
                else MessageBox.Show("No existe la región");
                reader.Close();
            }
        }

        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {
            // string query = "INSERT INTO region (RegionID, RegionDescription) values (@RegionID, @RegionDescription)";
            //string querymodifica = "UPDATE region SET RegionDescription=@DescriptionName where RegionID=@RegionID";
            //string querybuscar = "SELECT * FROM region WHERE RegionID = @RegionID";
            using (SqlConnection conn = new SqlConnection(Clases.clglobales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_busca_region", conn);
                cmd.Parameters.AddWithValue("@RegionID", txtID.Text);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                try
                {

                    if (reader.Read() == true)
                    {
                        //modificar
                        SqlCommand cmdmodificar = new SqlCommand("sp_modifica_region", conn);
                        cmdmodificar.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdmodificar.Parameters.AddWithValue("@RegionDescription", txtID.Text);
                        cmdmodificar.Parameters.AddWithValue("@RegionID", txtID.Text);
                        reader.Close();
                        cmdmodificar.ExecuteNonQuery();
                        MessageBox.Show("Registro modificado correctamente");
                    }
                    else
                    {
                        //grabar
                        SqlCommand cmdgrabar = new SqlCommand("sp_graba_region", conn);
                        cmdgrabar.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdgrabar.Parameters.AddWithValue("@RegionID", txtID.Text);
                        cmdgrabar.Parameters.AddWithValue("@RegionDescription", txtDescripción.Text);
                        cmdgrabar.ExecuteNonQuery();
                        MessageBox.Show("Registro guardado correctamente");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
