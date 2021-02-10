//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace DAL
//{
//    public class Dal_imp:Idal
//    {
//        #region GuestRequest 
//        public void addGuestRequest(BE.GuestRequest guestRequest)
//        {
//            guestRequest.GuestRequestKey = BE.Configuration.GuestRequestKeyS++;
//            DS.DataSource.listGuestRequest.Add(guestRequest.Copy());
//        }
//        public void updateGuestRequest(BE.GuestRequest guestRequest)
//        {
            
//            int count = DS.DataSource.listGuestRequest.RemoveAll(a => a.GuestRequestKey == guestRequest.GuestRequestKey);
//            if (count == 0)
//                throw new Exception("not found");
//            DS.DataSource.listGuestRequest.Add(guestRequest.Copy());
//        }
//        public List<BE.GuestRequest> GetGuestRequest()
//        {
//            return (from guest in DS.DataSource.listGuestRequest
//                   select guest.Copy()).ToList();
//        }
//        #endregion

//        #region HostingUnit
//        public void addHostingUnit(BE.HostingUnit hostingUnit)
//        {
//            hostingUnit.HostingUnitKey = BE.Configuration.HostingUnitKeyS++;
//            DS.DataSource.listHostingUnit.Add(hostingUnit.Copy());
//        }
//        public void deleteHostingUnit(string HostingUnitName)
//        {
//            int count = DS.DataSource.listHostingUnit.RemoveAll(a => a.HostingUnitName == HostingUnitName);///החלפתי לשם יחידת האירוח ולא למפתח כי אין דרך ללקוח להכיר את יחידת האירוח 
//            if (count == 0)
//                throw new Exception("not found");
//        }
//        public void updateDiaryHostingUnit(BE.HostingUnit v)
//        {
//            DS.DataSource.listHostingUnit.RemoveAll(t => t.HostingUnitName == v.HostingUnitName);
//            DS.DataSource.listHostingUnit.Add(v);
//        }
//        public void updateHostingUnit(string hostingUnitName, bool flag)
//        {
//            var v = DS.DataSource.listHostingUnit.FirstOrDefault(t => t.HostingUnitName == hostingUnitName);
//            v.Owner.CollectionClearance = flag;

//        }
//        public List<BE.HostingUnit> GetHostingUnit()
//        {
//            return (from hostingUnit in DS.DataSource.listHostingUnit
//                   select hostingUnit.Copy()).ToList();
//        }
//        #endregion

//        #region Order
//        public bool addOrder(int GuestRequestKey, int HostingUnitKey)
//        {
//            BE.Order order = new BE.Order();
//            order.OrderKey = BE.Configuration.OrderKeyS++;
//            order.GuestRequestKey = GuestRequestKey;
//            order.HostingUnitKey = HostingUnitKey;
//            order.Status = BE.statusOfTheOrder.send_email;
//            order.CreateDate = DateTime.Now;
//            order.OrderDate = DateTime.Now;
//          DS.DataSource.listOrder.Add(order.Copy());
//            return true;
//        }
//        public void updateOrder(BE.Order order)
//        {
//            int count = DS.DataSource.listOrder.RemoveAll(a1 => a1.OrderKey == order.OrderKey);
//            if (count == 0)
//                throw new Exception("not found");
//            DS.DataSource.listOrder.Add(order.Copy());
//        }
//        public List<BE.Order> GetOrders()
//        {
//            return (from order in DS.DataSource.listOrder
//                   select order.Copy()).ToList();
//        }
//        #endregion

//        #region BankBranch
//        public List<BE.BankBranch> GetBankBranch()
//        {
//            return (from bank in DS.DataSource.listBankBranch
//                   select bank.Copy()).ToList();
//        }
//        #endregion
//    }
//}
