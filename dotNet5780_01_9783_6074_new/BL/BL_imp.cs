using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace BL
{
    public class BL_imp : IBL
    {
        DAL.Idal dal;
        public BL_imp()
        {
            dal = DAL.FactoryAndSingltoneDAL.GetIdal();
        }
        #region GuestRequest
        bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public void addGuestRequest(BE.GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate >= guestRequest.ReleaseDate)
                throw new Exception("The end of vecation happend before the begin");
            if (!IsValidEmail(guestRequest.MailAddress))
            {
                throw new Exception("the mail address is not valid");
            }
            dal.addGuestRequest(guestRequest);
        }
        public void updateGuestRequest(BE.GuestRequest guestRequest)
        {
            dal.updateGuestRequest(guestRequest);
        }
        public List<BE.GuestRequest> getGuestRequest()
        {
            return dal.GetGuestRequest();
        }
        public List<BE.GuestRequest> AllGuestRequestIf(Func<BE.GuestRequest, bool> func = null)
        {
            if (func == null)
            {
                throw new Exception("לא התקבל תנאי");
            }
            List<BE.GuestRequest> guestRequests = dal.GetGuestRequest().Where(t => func(t)).ToList();
            return guestRequests;
        }
        public int NumOfDays(params DateTime[] dates)
        {
            int i = 0;
            DateTime date1;
            DateTime date2 = DateTime.Now;
            foreach (var v in dates)
            {
                i++;
            }
            if (i == 2)
            {
                date1 = dates[0];
                date2 = dates[1];
            }
            else if (i == 1)
                date1 = dates[0];
            TimeSpan interval = dates[1] - dates[0];
            return interval.Days;

        }
        public bool CalcBetween(DateTime date, int y)
        {
            TimeSpan interval = date - DateTime.Now;
            if (interval.Days >= y)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region HostingUnit
        public void addHostingUnit(BE.HostingUnit hostingUnit)
        {
            if (!IsValidEmail(hostingUnit.Owner.MailAddress))
            {
                throw new Exception("the mail address is not valid");
            }
            dal.addHostingUnit(hostingUnit);
        }
        public void updateDiaryHostingUnit(BE.HostingUnit v)
        {
            dal.updateDiaryHostingUnit(v);
        }
        public void deleteHostingUnit(string HostingUnitName)
        {
            BE.HostingUnit a;//we have the name and we search the histing unit that mach this name
            foreach (var w in dal.GetHostingUnit())
                if (w.HostingUnitName == HostingUnitName)
                {
                    a = w;
                    var v = dal.GetOrders().Where(t => t.HostingUnitKey == a.HostingUnitKey);
                    foreach (var item in v)
                    {
                        if (item.Status == BE.statusOfTheOrder.not_deal_with || item.Status == BE.statusOfTheOrder.send_email) // הצעה במצב פתוח
                        {
                            throw new Exception("You can't delete this Hosting Unit when there is an open sugestion");
                        }
                    }
                    dal.deleteHostingUnit(HostingUnitName);
                    return;
                }
            throw new Exception("the hosting unit doesnt find");

        }
        public void updateHostingUnit(string hostingUnitName, bool flag)
        {
            var v = dal.GetHostingUnit().FirstOrDefault(t => t.HostingUnitName == hostingUnitName);
            if (v.Owner.CollectionClearance == true && flag == false)
            {
                foreach (var z in dal.GetHostingUnit())
                {
                    if (z.HostingUnitKey == v.HostingUnitKey)
                    {
                        foreach (var v1 in dal.GetGuestRequest())
                        {
                            if (v1.Status == BE.statusMakeChange.open)
                            {
                                throw new Exception(" You cannot cancle the Collection Clearance");
                            }
                        }
                    }
                }
            }
            dal.updateHostingUnit(hostingUnitName, flag);
        }
        public List<BE.HostingUnit> getHostingUnit()
        {
            return dal.GetHostingUnit();
        }
        public bool AvailableHostingUnit2(BE.HostingUnit hostingUnit, DateTime date, int numOfDays)
        {

            int day = date.Day;
            int month = date.Month;
            int dayInMonth = DayOfMonth(month);
            bool flag = true;//to check if the room is empty

            if (day + 1 > dayInMonth)
            {
                if (hostingUnit.Diary[month, day] == true && hostingUnit.Diary[month + 1, day] == false)//the last day of the pre order
                {
                    flag = true;
                }
            }
            else if (hostingUnit.Diary[month, day] == true && hostingUnit.Diary[month, day + 1] == false)
            {
                flag = true;
            }
            for (int i = day + 1; ((i <= dayInMonth) && (i <= day + numOfDays)); i++) // check in the month of the entery date  
            {

                if (hostingUnit.Diary[month, i] == true)
                {
                    flag = false;
                    break;
                }
            }
            for (int i = 1; (i <= day + numOfDays - dayInMonth); i++) // check in the next month   dayInMonth-about the prev month
            {
                if (hostingUnit.Diary[month + 1, i] == true)
                {
                    flag = false;
                    break;
                }
            }

            if (flag == false)
                return false;
            return true;
        }
        public delegate bool itsAvailable(BE.HostingUnit hostingUnit, DateTime date, int z);
        public List<BE.HostingUnit> AvailableHostingUnit(DateTime date, int numOfDays)
        {
            List<BE.HostingUnit> list = new List<BE.HostingUnit>();
            itsAvailable delegateItsAvailable = new itsAvailable(AvailableHostingUnit2);
            foreach (BE.HostingUnit v in dal.GetHostingUnit())
            {
                if (delegateItsAvailable(v, date, numOfDays))
                {
                    list.Add(v);
                }
            }
            return list;
        }
        int NumOfHostingUnit(BE.Host owner)
        {
            int i = 0;
            foreach (var v in dal.GetHostingUnit())
            {
                if (v.Owner.HostKey == owner.HostKey)
                    i++;
            }
            return i;
        }
        BE.City hostingUnitByPlace(int key)
        {
            foreach (var v in dal.GetHostingUnit())
            {
                if (v.HostingUnitKey == key)
                {
                    return v.SubArea;
                }
            }
            return BE.City.Tel_Aviv; // default city
        }
        #endregion

        #region Order
        public int DayOfMonth(int month)
        {
            switch (month)
            {
                case 1: return 31;
                case 2: return 29;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
            }
            return 1;
        }
        //אולי צריך בפונקציית ההוספה לבדוק שכל השדות מתאימים..בריכה, חצר וכו
        public bool addOrder(int GuestRequestKey, int HostingUnitKey)
        {
            foreach (var guestRequest in dal.GetGuestRequest())//מחפש את דרישת הלקוח עם תאריך כניסה ויציאה 
                if (guestRequest.GuestRequestKey == GuestRequestKey)
                {
                    if (guestRequest.Status == BE.statusMakeChange.deal_close_with_the_site || guestRequest.Status == BE.statusMakeChange.close_because_expired)
                    {
                        throw new Exception("An offer has already been submitted");
                    }
                    int num = NumOfDays(guestRequest.EntryDate, guestRequest.ReleaseDate); //מספר הימים בין התאריך התחלה לסיום
                    IEnumerable<BE.HostingUnit> listOfHostingUnit = AvailableHostingUnit(guestRequest.EntryDate, num); // רשימה של יחידות אירוח פנויות בתאריך זה ומספר הימים שרצה הלקוח
                    var hostingUnit = listOfHostingUnit.First(t => t.HostingUnitKey == HostingUnitKey);
                    // הוספתי בתנאי בדיקות שחלק מהשדות ביחידה ובדרישה מתאימות
                    if (hostingUnit != null && hostingUnit.Area == guestRequest.Area && hostingUnit.SubArea == guestRequest.SubArea && hostingUnit.Type == guestRequest.Type)
                    {
                        dal.addOrder(GuestRequestKey, HostingUnitKey);
                        return true;
                    }
                }
            return false;

        }



        public void updateOrder(BE.Order order)
        {
            if (order.Status == BE.statusOfTheOrder.The_vacantion_close)//אם האיש בחר לסגור את ההזמנה 
            {
                foreach (var w in dal.GetGuestRequest())
                {
                    if (order.GuestRequestKey == w.GuestRequestKey)
                    {
                        if (w.Status == BE.statusMakeChange.deal_close_with_the_site || w.Status == BE.statusMakeChange.close_because_expired)
                        {
                            throw new Exception("An offer has already been submitted");
                        }
                        foreach (var z in dal.GetHostingUnit())
                        {
                            if (z.HostingUnitKey == order.HostingUnitKey)
                            {
                                int numOfDays;
                                int day = w.EntryDate.Day;
                                int month = w.EntryDate.Month;
                                int dayInMonth = DayOfMonth(month);
                                if (month == w.ReleaseDate.Month)//אם חודש הכניסה שווה לחודש היציאה
                                    numOfDays = w.ReleaseDate.Day - day;
                                else numOfDays = w.ReleaseDate.Day + DayOfMonth(month) - day;
                                for (int i = day; ((i <= dayInMonth) && i <= day + numOfDays); i++) // check in the month of the entery date  
                                {
                                    z.Diary[month, i] = true;

                                }
                                for (int i = 1; i < day + numOfDays - dayInMonth - 1; i++) //put true in the next month
                                {
                                    z.Diary[month + 1, i] = true;
                                }
                                z.commission += (numOfDays * BE.Configuration.CommissionPerClosedOrder);
                                updateDiaryHostingUnit(z);
                                w.Status = BE.statusMakeChange.deal_close_with_the_site;
                                dal.updateGuestRequest(w);
                                dal.updateOrder(order);
                                return;
                            }
                        }

                    }
                    //dal.updateGuestRequest(w);
                }
            }
            else if (order.Status == BE.statusOfTheOrder.The_vacantion_cancel)//אם האיש בחר לבטל את ההזמנה 
            {
                dal.updateOrder(order);
                BE.GuestRequest guestRequest = dal.GetGuestRequest().FirstOrDefault(t => t.GuestRequestKey == order.GuestRequestKey);
                guestRequest.Status = BE.statusMakeChange.open;
                dal.updateGuestRequest(guestRequest);
            }


        }
        public List<BE.Order> GetOrders()
        {
            return dal.GetOrders();
        }
        public List<BE.Order> ExpiringOrder(int numOfDayToExpiring)
        {
            Func<DateTime, int, bool> func = CalcBetween;
            List<BE.Order> orders = dal.GetOrders().Where(t => (func(t.CreateDate, numOfDayToExpiring) || func(t.OrderDate, numOfDayToExpiring))).ToList();
            return orders;
        }
        public int NumOfOrdersPerRequest(BE.GuestRequest guestRequest)
        {
            int key = guestRequest.GuestRequestKey;
            var v = dal.GetOrders().Where(t => t.GuestRequestKey == key);
            int i = 0;
            foreach (var v1 in v)
                i++;
            return i;

        }
        public int NumOfOrdersPerHostingUnit(BE.HostingUnit hostingUnit)
        {
            var v = dal.GetOrders().Where(t => (t.HostingUnitKey == hostingUnit.HostingUnitKey && (t.Status == BE.statusOfTheOrder.The_vacantion_close || t.Status == BE.statusOfTheOrder.send_email)));
            int i = 0;
            foreach (var v1 in v)
                i++;
            return i;
        }
        #endregion

        #region BankBranch
        public List<BE.BankBranch> GetBankBranch()
        {
            return dal.GetBankBranch();
        }

        #endregion

        #region Grouping
        public List<IGrouping<BE.placeOfVecation, BE.GuestRequest>> GroupByPlace()
        {
            return (from guestRequest in dal.GetGuestRequest()
                    group guestRequest by guestRequest.Area into g
                    select g).ToList();
        }
        public List<IGrouping<int, BE.GuestRequest>> GroupByNumOfPerson()
        {
            return (from guestRequest in dal.GetGuestRequest()
                    group guestRequest by (guestRequest.Children + guestRequest.Adults)).ToList();
        }
        public List<IGrouping<int, BE.HostingUnit>> GroupByNumOfHostingUnit()
        {
            return (from hostingUnit in dal.GetHostingUnit()
                    group hostingUnit by (NumOfHostingUnit(hostingUnit.Owner))).ToList();
        }
        public List<IGrouping<BE.City, BE.HostingUnit>> GroupOfHostingUnitsByPlace()
        {
            return (from hostingUnit in dal.GetHostingUnit()
                    group hostingUnit by hostingUnitByPlace(hostingUnit.HostingUnitKey)).ToList();

        }
        public List<IGrouping<BE.statusOfTheOrder, BE.Order>> GroupOfOrderByStatus()
        {
            return (from order in dal.GetOrders()
                    group order by order.Status).ToList();
        }
        public List<IGrouping<BE.statusMakeChange, BE.GuestRequest>> GroupOfGuestRequestByStatus()
        {
            return (from guestRequest in dal.GetGuestRequest()
                    group guestRequest by guestRequest.Status).ToList();
        }

        #endregion
        void UpdateStatusOrder(Object obj) // תהליכון שסוגר הזמנות
        {
            foreach (var order in dal.GetOrders())
            {
                if (order.Status == BE.statusOfTheOrder.send_email)
                {
                    int days = NumOfDays(order.OrderDate);
                    if (days >= 30)
                    {
                        order.Status = BE.statusOfTheOrder.close_because_expired;
                        dal.updateOrder(order);
                        BE.GuestRequest guestRequest = dal.GetGuestRequest().FirstOrDefault(t => t.GuestRequestKey == order.GuestRequestKey);
                        guestRequest.Status = BE.statusMakeChange.close_because_expired;
                        dal.updateGuestRequest(guestRequest);

                    }
                }

            }
        }

        public void Main(string[] args)
        {
            Thread t = new Thread(UpdateStatusOrder);
            Thread.Sleep(86400);//השהיה של יום לבדוק אם זה נכון
            t.Start();
        }


    }
}


//in IBL interface:
//void Shutdown();

//in IDAL interface:
//void Shutdown();

//in DAL implementation:
//    sealed class DalObject : Idal // Singleton - similarly in DalXml
//    {
//        public static DalObject Instance { get; } = new DalObject();
//        DalObject()
//        {
//            // DAL initializations ...
//            (myThread = new Thread(BackgroundAudit)).Start();
//        }
//        // IDAL implementations

//        // Multithreading stuff
//        Thread myThread;
//        volatile bool stopFlag = false;
//        public void Shutdown() { stopFlag = true; myThread.Interrupt(); }
//        void BackgroundAudit()
//        {
//            // initialize audit stuff
//            while (!stopFlag)
//            {
//                try { Thread.Sleep(5000); } catch (ThreadInterruptedException ex) { }
//                if (stopFlag) break;
//                try
//                {
//                    // do the work...
//                }
//                catch (ThreadInterruptedException ex) { }
//            }
//            // gracefully release any audit resources
//        }
//    }

//in BL implemtation:
//   public void Shutdown() { dal.Shutdown(); }

//in PLWPF closing:
//  myBl.Shutdown();
//    }
