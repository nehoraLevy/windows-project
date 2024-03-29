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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HostingUnitbyPlace.xaml
    /// </summary>
    public partial class HostingUnitbyPlace : Window
    {
        public BL.IBL bl;
        public HostingUnitbyPlace()
        {
            try
            {
                InitializeComponent();
                bl = BL.FactoryAndSingltoneBL.GetIBL();
                this.HostingUnitbyPlaceDataGrid.ItemsSource = bl.GroupOfHostingUnitsByPlace();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

    }
}
