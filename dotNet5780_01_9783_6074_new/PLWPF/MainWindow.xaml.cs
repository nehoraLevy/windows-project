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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Window GuestRequest = new GuestRequest();

            GuestRequest.Show();
            this.Close();

        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            new Manager().Show();
            this.Close();

        }

        private void HostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            new HostingUnit().Show();
            this.Close();

        }
    }
}
