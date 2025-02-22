using POSWPFSaleProject.ViewModel;
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

namespace POSWPFSaleProject.View
{
    /// <summary>
    /// Interaction logic for authentication.xaml
    /// </summary>
    public partial class authentication : Window
    {
        public authentication()
        {
            InitializeComponent();
            LoginViewModel loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnminimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Sale sale = new Sale();
            sale.WindowState = WindowState.Maximized;
            sale.Show();
        }
    }
}
