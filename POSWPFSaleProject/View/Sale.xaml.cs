﻿using POSWPFSaleProject.ViewModel;
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
    /// Interaction logic for Sale.xaml
    /// </summary>
    public partial class Sale : Window
    {

        public Sale()
        {
            InitializeComponent();
            SalesViewModel salesViewModel = new SalesViewModel();
            DataContext = salesViewModel;
        }

        private void txtSearchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }
    }
}
