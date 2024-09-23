using System;
using System.Collections.Generic;
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

namespace ProyectoPOO23030531.Prácticas
{
    /// <summary>
    /// Lógica de interacción para wpfSuma.xaml
    /// </summary>
    public partial class wpfSuma : Window
    {
        public wpfSuma()
        {
            InitializeComponent();
        }

        private void btnsuma_Click(object sender, RoutedEventArgs e)
        {
            clOperaciones op = new clOperaciones();
            op.Valor1 = decimal.Parse(txtvalor1.Text);
            op.Valor2 = decimal.Parse(txtvalor2.Text);
            txtresultados.Text = op.suma().ToString();
        }

        private void txtvalor1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.Decimal || e.Key == Key.OemPeriod || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {     
               MessageBox.Show("Introduzca valores numéricos");
               e.Handled = true;
            }
        }

        private void txtvalor2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.Decimal || e.Key == Key.OemPeriod || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Introduzca valores numéricos");
                e.Handled = true;
            }
        }
    }
}
