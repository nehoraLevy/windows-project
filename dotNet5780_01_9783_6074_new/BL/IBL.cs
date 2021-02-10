using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
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

        //return the DataSource lists
        List<BE.HostingUnit> getHostingUnit();
        List<BE.GuestRequest> getGuestRequest();
        List<BE.Order> GetOrders();
        List<BE.BankBranch> GetBankBranch();

        //additional functions
        int DayOfMonth(int month);
        bool AvailableHostingUnit2(BE.HostingUnit hostingUnit, DateTime date, int num);
        List<BE.HostingUnit> AvailableHostingUnit(DateTime date, int num);
        int NumOfDays(params DateTime[] dates);
        List<BE.Order> ExpiringOrder(int numOfDayToExpiring);
        List<BE.GuestRequest> AllGuestRequestIf(Func<BE.GuestRequest, bool> func = null);
        int NumOfOrdersPerRequest(BE.GuestRequest guestRequest);
        int NumOfOrdersPerHostingUnit(BE.HostingUnit hostingUnit);

        //Grouping
        List<IGrouping<BE.placeOfVecation, BE.GuestRequest>> GroupByPlace();

        List<IGrouping<int, BE.GuestRequest>> GroupByNumOfPerson();

        List<IGrouping<int, BE.HostingUnit>> GroupByNumOfHostingUnit();

        List<IGrouping<BE.City, BE.HostingUnit>> GroupOfHostingUnitsByPlace();

        List<IGrouping<BE.statusOfTheOrder, BE.Order>> GroupOfOrderByStatus();

        List<IGrouping<BE.statusMakeChange, BE.GuestRequest>> GroupOfGuestRequestByStatus();


    }
}
