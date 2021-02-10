using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        public static int HostingUnitKeyS= 10000001;
        public static int GuestRequestKeyS= 30000001;
        public static int OrderKeyS=20000001;
        public static int BankNumberS = 2;
        public static int CommissionPerClosedOrder=10;// סכום העמלה מכל עסקה, צריך לאתחל 
        public static int NumDaysExpiringOrder=30; //לפגות תוקף של הזמנה, צריך לאתחל

    }
}
