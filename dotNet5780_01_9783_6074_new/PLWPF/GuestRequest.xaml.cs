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
    /// Interaction logic for GuestRequest.xaml
    /// </summary>
    public partial class GuestRequest : Window
    {
        BE.GuestRequest guestRequest;
        BL.IBL bl;

        
        public GuestRequest()
        {
            try
            {
                InitializeComponent();
                guestRequest = new BE.GuestRequest();
                this.DataContext = guestRequest;
                bl = BL.FactoryAndSingltoneBL.GetIBL();
                this.AreaComboBox.ItemsSource = Enum.GetValues(typeof(BE.placeOfVecation));
                this.SubAreaComboBox.ItemsSource = Enum.GetValues(typeof(BE.City));
                this.TypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.typeOfVecation));
                this.PoolComboBox.ItemsSource = Enum.GetValues(typeof(BE.Possibility));
                this.JacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.Possibility));
                this.GardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.Possibility));
                this.ChildrenAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.Possibility));

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                guestRequest.MailAddress = this.MailAdressTextBox.Text;
                guestRequest.PrivateName = this.PrivateNameTextBox.Text;
                guestRequest.FamilyName = this.FamilyNameTextBox.Text;
                guestRequest.Adults = int.Parse(this.AdultsTextBox.Text);
                guestRequest.Children = int.Parse(this.ChildrenTextBox.Text);
                guestRequest.RegistrationDate = DateTime.Now;
                string str = this.EnteryDateDatePicker.SelectedDate.ToString();
                guestRequest.EntryDate = Convert.ToDateTime(str);
                str = this.ReleaseDateDatePicker.ToString();
                guestRequest.ReleaseDate = Convert.ToDateTime(str);
                this.DataContext = guestRequest;
                bl.addGuestRequest(guestRequest);
                MessageBox.Show("The Guest Request add");
                this.Close();
            }
            catch(FormatException)
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
