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
    /// Interaction logic for GuestRequestListbyNumofPersons.xaml
    /// </summary>
    public partial class GuestRequestListbyNumofPersons : Window
    {
        public BL.IBL bl;
        public GuestRequestListbyNumofPersons()
        {
           
            try
            {
                InitializeComponent();
                bl = BL.FactoryAndSingltoneBL.GetIBL();
                this.GuestRequestListbyNumofPersonsDataGrid.ItemsSource = bl.GroupByNumOfPerson();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
