using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {
        //GuestRequest
        void addGuestRequest(BE.GuestRequest guestRequest);
        void updateGuestRequest(BE.GuestRequest guestRequest);
        //HostingUnit
        void addHostingUnit(BE.HostingUnit hostingUnit);
        void deleteHostingUnit(string HostingUnitName);
        void updateHostingUnit(string hostingUnitName, bool flag);
        void updateDiaryHostingUnit(BE.HostingUnit v);
        //Order
        bool addOrder(int GuestRequestKey, int HostingUnitKey);
        void updateOrder(BE.Order order);
        // return the dataSource
        List<BE.HostingUnit> GetHostingUnit();
        List<BE.GuestRequest> GetGuestRequest();
        List<BE.Order> GetOrders();
        List<BE.BankBranch> GetBankBranch();


    }
}
