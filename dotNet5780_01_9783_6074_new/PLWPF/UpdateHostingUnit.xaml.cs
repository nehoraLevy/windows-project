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
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnit : Window
    {
        public BL.IBL bl;
        public UpdateHostingUnit() // יכול להיות שכדאי להוסיף בחלון הזה שינוי של שדות כמו בריכה, חצר , אטרקציות וכו
        {
            try
            {
                InitializeComponent();
                bl = BL.FactoryAndSingltoneBL.GetIBL();
                this.HostingUnitDataGrid.ItemsSource = bl.getHostingUnit(); 
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Button_Click_UpdateCollectionClearance(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flagCollectionClearance = (bool)this.collectionClearanceCheckBox.IsChecked;
                int index = this.HostingUnitDataGrid.SelectedIndex;
                bl.updateHostingUnit(bl.getHostingUnit()[index].HostingUnitName, flagCollectionClearance);
                MessageBox.Show("Your Collection Clearance Update!!");
                this.Close();
                //this.HostingUnitDataGrid.ItemsSource = bl.getHostingUnit();
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
 
                    MessageBox.Show(ex.Message);
            }
           



        }


        

    }
}
