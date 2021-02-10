using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey
        {
            set;
            get;
        } 
        public int GuestRequestKey
        {
            set;
            get;
        }
        public int OrderKey
        {
            set;
            get;
        }
        private statusOfTheOrder Status1;
        public statusOfTheOrder Status
        {
            set { Status1 = value; }
            get { return Status1; }
        }
        private DateTime CreateDate1;
        public DateTime CreateDate
        {
            set { CreateDate1 = value; }
            get { return CreateDate1; }
        }
        private DateTime OrderDate1;
        public DateTime OrderDate
        {
            set { OrderDate1 = value;}
            get { return OrderDate1; }
        }

        public override string ToString()
        {
            string m = "The num of the hosting unit is:  " + HostingUnitKey + "\n The ID number of the guest request is:  " + GuestRequestKey + "\n The ID nuber of the order is: " + OrderKey + "\n The status of the order is: " + Status1 + "\n The date of create date is: " + CreateDate + "\nThe order date(sending mail) is: " + OrderDate + "\n";
            return m;

        }
    }
}
