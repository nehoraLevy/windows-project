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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {        public Manager()
        {
            InitializeComponent();
        }

        private void Button_Click_GuestRequestListbyPlace(object sender, RoutedEventArgs e)
        {
            new GuestRequestListPlace().Show();
            this.Close();
        }

        private void Button_Click_NumofHostingUnitListbyOwner(object sender, RoutedEventArgs e)
        {
            new NumofHostingUnitListbyOwner().Show();
            this.Close();
        }

        private void Button_Click_HostingUnitbyPlace(object sender, RoutedEventArgs e)
        {
            new HostingUnitbyPlace().Show();
            this.Close();
        }

        private void Button_Click_GuestRequestListbyNumofPersons(object sender, RoutedEventArgs e)
        {
            new GuestRequestListbyNumofPersons().Show();
            this.Close();
        }

        private void Button_Click_OrderListbyStatus(object sender, RoutedEventArgs e)
        {
            new OrderListbyStatus().Show();
            this.Close();

        }

        private void Button_Click_GuestRequestbyStatus(object sender, RoutedEventArgs e)
        {
            new GuestRequestbyStatus().Show();
            //this.Close();
        }
    }
}
