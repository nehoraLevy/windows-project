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
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    ///    {

    public partial class AddHostingUnit : Window
    {
        public BE.HostingUnit hostingUnit;
        BL.IBL bl;

        public AddHostingUnit()  //הוספתי שדות
        {
            try
            {
                InitializeComponent();
                hostingUnit = new BE.HostingUnit();
                hostingUnit.Owner = new BE.Host();
                hostingUnit.Owner.BankBranchDetails = new BE.BankBranch();

                this.DataContext = hostingUnit;
                bl = BL.FactoryAndSingltoneBL.GetIBL();
                this.BankBranchDetailsDataGrid.ItemsSource = bl.GetBankBranch();
                this.AreaComboBox.ItemsSource = Enum.GetValues(typeof(BE.placeOfVecation));
                this.SubAreaComboBox.ItemsSource = Enum.GetValues(typeof(BE.City));
                this.TypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.typeOfVecation));

            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                hostingUnit.Owner.PrivateName = this.PrivateNameTextBox.Text;
                hostingUnit.Owner.FamilyName = this.FamilyNameTextBox.Text;
                hostingUnit.Owner.MailAddress = this.MailAddressTextBox.Text;
                hostingUnit.Owner.PhoneNumber =this.PhoneNumberTextBox.Text;
                hostingUnit.Owner.CollectionClearance = (bool)this.collectionClearanceCheckBox.IsChecked;
                hostingUnit.Owner.BankAccountNumber = long.Parse(this.BankAccountNumberTextBox.Text);
                hostingUnit.HostingUnitName = this.hostingUnitNameTextBox.Text;
                hostingUnit.Adults = int.Parse(this.AdultsTextBox.Text);
                hostingUnit.Children = int.Parse(this.ChildrenTextBox.Text);
                hostingUnit.Pool = (bool)this.PoolCheckBox.IsChecked;
                hostingUnit.Jacuzzi = (bool)this.JaccuziCheckBox.IsChecked;
                hostingUnit.Garden = (bool)this.GardenCheckBox.IsChecked;
                hostingUnit.ChildrensAttractions = (bool)this.ChildrenAttractionCheckBox.IsChecked;
                int index = this.BankBranchDetailsDataGrid.SelectedIndex;
                hostingUnit.Owner.BankBranchDetails = bl.GetBankBranch()[index];
                hostingUnit.Owner.HostKey= int.Parse(this.HostKeyTextBox.Text);
                hostingUnit.Diary = new bool[13,32]; // לבדוק מה עושים עם היומן
                this.DataContext = hostingUnit;
                bl.addHostingUnit(hostingUnit);
                MessageBox.Show("The Hosting Unit add");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();

            }
        }

        
    }
}       


        
       
    

