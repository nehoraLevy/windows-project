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
    /// Interaction logic for ListOfOrders.xaml
    /// </summary>
    public partial class ListOfOrders : Window
    {
        public BL.IBL bl;
        public ListOfOrders()
        {
            InitializeComponent();
            bl = BL.FactoryAndSingltoneBL.GetIBL();
            this.ListOfOrdersDataGrid.ItemsSource = bl.GetOrders();
            // עשיתי את כל השדות שיש בהזמנה
        }
    }
}
