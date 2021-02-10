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
//לעבור על העמוד הזה וגם על הבדיקה של היחידות אירוח ועל הפונקציה של הGUSTREQUEST 
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {
        BL.IBL bl;
        public UpdateOrder()
        {
            InitializeComponent();
            bl = BL.FactoryAndSingltoneBL.GetIBL();
            this.TableOrderDataGrid.ItemsSource = bl.GetOrders();
        }

        private void UpdateOrder_Button_Click(object sender, RoutedEventArgs e)//The_vacantion_close
        {
            try
            {
                // האינדקסים בטבלאות
                int IOrder = this.TableOrderDataGrid.SelectedIndex;
                BE.Order order = new BE.Order();
                order.GuestRequestKey = bl.GetOrders()[IOrder].GuestRequestKey;
                order.HostingUnitKey = bl.GetOrders()[IOrder].HostingUnitKey;
                order.OrderKey = bl.GetOrders()[IOrder].OrderKey;
                order.Status = BE.statusOfTheOrder.The_vacantion_close;
                order.CreateDate = bl.GetOrders().ElementAt(IOrder).CreateDate;
                order.OrderDate = bl.GetOrders().ElementAt(IOrder).OrderDate;
                //שליחה לפונקציית עידכון של הזמנה
                bl.updateOrder(order);
                   MessageBox.Show("The Order Close");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelOrder_Button_Click(object sender, RoutedEventArgs e)//The_vacantion_cancel
        {
            try
            {
                
                //האינדקסים בטבלאות
                int IOrder = this.TableOrderDataGrid.SelectedIndex;
                if (bl.GetOrders()[IOrder].Status == BE.statusOfTheOrder.close_because_expired)
                {
                    throw new Exception("The Order is Expired");
                }
                BE.Order order = new BE.Order();
                order.GuestRequestKey = bl.GetOrders()[IOrder].GuestRequestKey;
                order.HostingUnitKey = bl.GetOrders()[IOrder].HostingUnitKey;
                order.OrderKey = bl.GetOrders()[IOrder].OrderKey;
                order.Status = BE.statusOfTheOrder.The_vacantion_cancel;
                order.CreateDate = bl.GetOrders()[IOrder].CreateDate;
                order.OrderDate = bl.GetOrders()[IOrder].OrderDate;
                //שליחה לפונקציית עידכון של הזמנה
                bl.updateOrder(order);
                MessageBox.Show("The Order Cancel");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
