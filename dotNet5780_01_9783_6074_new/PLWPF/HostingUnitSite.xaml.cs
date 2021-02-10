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
    /// Interaction logic for HostingUnitSite.xaml
    /// </summary>
    public partial class HostingUnitSite : Window
    {
        public HostingUnitSite()
        {
            InitializeComponent();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            new Order().Show();
            this.Close();
        }
        private void UpdateHostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateHostingUnit().Show();
            this.Close();

        }

        private void DeleteHostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteHostingUnit().Show();
            this.Close();
        }
    }
}
