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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Linq;
using BE;
using System.Xml.Serialization;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        BL.IBL bl;
        
        BackgroundWorker backgroundWorker;
       public AddOrder()
        {
            InitializeComponent();
            bl = BL.FactoryAndSingltoneBL.GetIBL();
            this.TableGuestReuquestsDataGrid.ItemsSource = bl.getGuestRequest();
            this.TableHostingUnitsDataGrid.ItemsSource = bl.getHostingUnit();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += Bg_Dworker_Email;
            backgroundWorker.ProgressChanged += Worker_ProgressChanged; //לא בטוח שצריך את זה בכלל
            backgroundWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            //לא בטוח שצריך אותם בכלל
            //backgroundWorker.WorkerReportsProgress = true;
            //backgroundWorker.WorkerSupportsCancellation = true;

        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //object obj = e.Argument;
            //backgroundWorker.ReportProgress(1);
            //e.Result = "";
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private void AddOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // האינדקסים בטבלאות
                int IhostingUnit = this.TableHostingUnitsDataGrid.SelectedIndex;
                int IguestRequest = this.TableGuestReuquestsDataGrid.SelectedIndex;
                //שליחה לפונקציית הוספה של הזמנה
                bool flag = bl.addOrder(bl.getGuestRequest()[IguestRequest].GuestRequestKey, bl.getHostingUnit()[IhostingUnit].HostingUnitKey);
                backgroundWorker.RunWorkerAsync(IguestRequest);
                MessageBox.Show("The Order Add, And we send to the guest a Email");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void Bg_Dworker_Email(Object sender, DoWorkEventArgs e)
        {
            int index = Convert.ToInt32(e.Argument);
            BE.Order order = bl.GetOrders().FirstOrDefault(t => t.GuestRequestKey == bl.getGuestRequest()[index].GuestRequestKey);
            BE.HostingUnit hostingUnit = bl.getHostingUnit().FirstOrDefault(t => t.HostingUnitKey == order.HostingUnitKey);
            //MailMessage   יצירת אובייקט 
            MailMessage mail = new MailMessage();
            mail.To.Add(bl.getGuestRequest()[index].MailAddress);
            mail.From = new MailAddress("batyarivka@gmail.com");
            mail.Subject = "Message From Vacation Site, Suggestion to Hosting Unit";
            mail.Body = "We want to suggest you a Hosting Unit:" +
                "\n Hosting Unit Name: " +hostingUnit.HostingUnitName+"\n The Owner Details: " +
                "\n Owner Name:"+hostingUnit.Owner.PrivateName + " "+ hostingUnit.Owner.FamilyName+ "\n The Hosting Unit suggest a Jaccuzzy? " + hostingUnit.Jacuzzi+"\n The Hosting Unit suggest a pool?"+ hostingUnit.Pool+ "\n The Hosting Unit suggest children attractions?" + hostingUnit.ChildrensAttractions+"\n The location of the Hosting Unit"+ hostingUnit.SubArea+"\n Owner Phone Number: " + hostingUnit.Owner.PhoneNumber+"\n Owner Mail Address: "+ hostingUnit.Owner.MailAddress+"\n please reply to his mail if the suggestion interesting you. \n Thank you and have a nice day! \n";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("batyarivka@gmail.com", "0547767552");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception)
            {

            }

        }
    }
}
