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
    /// Interaction logic for NumofHostingUnitListbyOwner.xaml
    /// </summary>
    public partial class NumofHostingUnitListbyOwner : Window
    {
        public BL.IBL bl;
        public NumofHostingUnitListbyOwner()
        {
            try
            {
                InitializeComponent();
                bl = BL.FactoryAndSingltoneBL.GetIBL();
                this.NumofHostingUnitListbyOwnerDataGrid.ItemsSource = bl.GroupByNumOfHostingUnit();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            //יש בעיה בחלון, הוא מראה רק שורה אחת וגם לא מראה את מספר יחידות האירוח שיש למארח הזה
            // יש בעיה עם העמלה
        }
    }
}
        
   

