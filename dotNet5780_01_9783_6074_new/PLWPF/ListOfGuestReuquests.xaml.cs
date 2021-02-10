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
    /// Interaction logic for ListOfGuestReuquests.xaml
    /// </summary>
    public partial class ListOfGuestReuquests : Window
    {
        public BL.IBL bl;
        public ListOfGuestReuquests()
        {
            InitializeComponent();
            bl = BL.FactoryAndSingltoneBL.GetIBL();
            this.ListOfGuestReuquestsDataGrid.ItemsSource = bl.getGuestRequest();

            // חושבת שכדאי להוסיף את בחלון הזה grouping ולחשוב איך לעשות שבאמת זה יראה טוב..
        }
    }
}
