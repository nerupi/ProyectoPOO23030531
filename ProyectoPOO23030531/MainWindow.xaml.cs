﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoPOO23030531
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void miSalir1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void miSumar_Click(object sender, RoutedEventArgs e)
        {
            Prácticas.wpfSuma x = new Prácticas.wpfSuma();
            x.Show();
        }

        private void miRegiones_Click(object sender, RoutedEventArgs e)
        {
                Datos.frmregiones x = new Datos.frmregiones();
                x.Owner = this;
                x.Show();
        }

        private void miCategorías_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmcategorías x = new Datos.frmcategorías();
            x.Owner = this;
            x.Show();
        }

        private void miPaqueteria_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmpaqueteria x = new Datos.frmpaqueteria();
            x.Owner = this;
            x.Show();
        }
    }
}
