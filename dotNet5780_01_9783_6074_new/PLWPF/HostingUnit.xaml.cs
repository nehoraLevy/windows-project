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
    /// Interaction logic for HostingUnit.xaml
    /// </summary>
    public partial class HostingUnit : Window
    {
        public HostingUnit()
        {
            InitializeComponent();
        }

        private void AddHostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            new AddHostingUnit().Show();
            this.Close();
        }

        private void PersonalSite_Click(object sender, RoutedEventArgs e)
        {
            new HostingUnitSite().Show();
            this.Close();
        }
    }
}
