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
    /// Interaction logic for DeleteHostingUnit.xaml
    /// </summary>
    public partial class DeleteHostingUnit : Window
    {
        
        public BL.IBL bl;
        public DeleteHostingUnit()
        {
            try
            {
                InitializeComponent();
                bl = BL.FactoryAndSingltoneBL.GetIBL();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        // חשבתי על אפשרות בחלון זה, לעשות קומבובוקס שמתוכו יבחר המארח את השם של היחידה למחיקה

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string name = this.hostingUnitNameTextBox.Text;
                bl.deleteHostingUnit(name);
                MessageBox.Show("Success");
                this.Close();
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
