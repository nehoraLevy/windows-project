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
    /// Interaction logic for GuestRequestListPlace.xaml
    /// </summary>
    public partial class GuestRequestListPlace : Window
    {
           public BL.IBL bl;
        public GuestRequestListPlace()
        {
           
            try
            {
                InitializeComponent();
                bl = BL.FactoryAndSingltoneBL.GetIBL();
                this.GuestRequestListPlaceDataGrid.ItemsSource = bl.GroupByPlace();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
