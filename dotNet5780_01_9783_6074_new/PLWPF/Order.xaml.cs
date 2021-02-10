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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            new UpdateOrder().Show();
            this.Close();// לא חושבת שכדאי לסגור את בחלון, בשביל מקרה שאחרי שהמארח הסתכל ברשימות הוא ירצה להוסיף או לעדכן
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            new AddOrder().Show();
            this.Close();//  לא חושבת שכדאי לסגור את בחלון, בשביל מקרה שאחרי שהמארח הסתכל ברשימות הוא ירצה להוסיף או לעדכן
        }

        private void ListOfOrdersOrder_Click(object sender, RoutedEventArgs e)
        {
            new ListOfOrders().Show();
            this.Close();

        }


    }
}
