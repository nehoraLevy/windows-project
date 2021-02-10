using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            BL_imp bl = new BL_imp();
            //try
            {
                GuestRequest guestRequest = new GuestRequest()
                {
                    GuestRequestKey = BE.Configuration.GuestRequestKeyS++,
                    PrivateName = "bert",
                    FamilyName = "hash",
                    MailAddress = "non@gmail.com",
                    Status = statusMakeChange.open,
                    RegistrationDate = new DateTime(2020, 6, 7),
                    EntryDate = new DateTime(2020, 6, 7),
                    ReleaseDate = new DateTime(2020, 6, 10),
                    Area = placeOfVecation.south,
                    SubArea = City.Eilat,
                    Type = typeOfVecation.hotel_room,
                    Adults = 5,
                    Children = 2,
                    Pool = Possibility.uninterested,
                    Jacuzzi = Possibility.necessary,
                    Garden = Possibility.possible,
                    ChildrensAttractions = Possibility.uninterested,
                };
                bl.addGuestRequest(guestRequest);
                guestRequest.Status = statusMakeChange.deal_close_with_the_site;
                bl.updateGuestRequest(guestRequest);
                foreach (var v in bl.getGuestRequest())
                {
                    Console.WriteLine(v.ToString());
                }
            }
            //catch (Exception e)
            //{
            //    //Console.WriteLine(e.Message);
            //}
            //try
            {
                HostingUnit hostingUnit = new HostingUnit()
                {
                    HostingUnitKey=BE.Configuration.HostingUnitKeyS++,
                    Owner = new BE.Host()
                    {
                        HostKey = 378220965,
                        PrivateName = "batya rivka",
                        FamilyName = "tamsot",
                        PhoneNumber = "0544988867",
                        MailAddress = "batyarivka@gmail.com",
                        BankAccountNumber = 166685,
                        BankBranchDetails = bl.GetBankBranch().ElementAt(0),
                        CollectionClearance = true
                    },
                    HostingUnitName = "the sea",
                    //Diary = new bool[32, 13]
                };
                bl.addHostingUnit(hostingUnit);
                foreach (var v in bl.getHostingUnit())
                {
                    Console.WriteLine(v.ToString());
                }
                //bl.deleteHostingUnit(hostingUnit.HostingUnitName);
            }
            //catch (Exception e)
            //{
            //    //Console.WriteLine(e.Message);
            //}

            try
            {
                Order order = new Order();
                bl.addOrder(bl.getGuestRequest().ElementAt(0).GuestRequestKey, bl.getHostingUnit().ElementAt(0).HostingUnitKey);
                foreach (var v in bl.GetOrders())
                    if (v.GuestRequestKey == bl.getGuestRequest().ElementAt(0).GuestRequestKey)
                        order = v;
                order.Status = statusOfTheOrder.send_email;
                bl.updateOrder(order);
                foreach (var v in bl.GetOrders())
                {
                    Console.WriteLine(v.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (var v in bl.GetBankBranch())
            {
                Console.WriteLine(v.ToString());
            }
            IEnumerable<BE.HostingUnit> list = bl.AvailableHostingUnit(new DateTime(2010, 10, 10), 5);
            foreach (var v in list)
            {
                Console.WriteLine(v.ToString());
            }
            int num = bl.NumOfDays(new DateTime(2010, 10, 10), new DateTime(2010, 10, 14));
            IEnumerable<BE.Order> list1 = bl.ExpiringOrder(20);
            foreach (var v in list1)
            {
                Console.WriteLine(v.ToString());
            }
            IEnumerable<BE.GuestRequest> list3 = bl.AllGuestRequestIf(t => t.Pool == Possibility.possible);
            foreach (var v in list3)
            {
                Console.WriteLine(v.ToString());
            }
            IEnumerable<BE.GuestRequest> list4 = bl.AllGuestRequestIf(t => t.SubArea == City.Eilat);
            foreach (var v in list4)
            {
                Console.WriteLine(v.ToString());
            }
            int n = bl.NumOfOrdersPerRequest(bl.getGuestRequest().ElementAt(0));
            n = bl.NumOfOrdersPerHostingUnit(bl.getHostingUnit().ElementAt(0));
            foreach (var item in bl.GroupByPlace())
            {
                Console.WriteLine(item.Key);
                foreach (var w in item)
                    Console.WriteLine(w);
            }
            foreach (var item in bl.GroupByNumOfPerson())
            {
                Console.WriteLine(item.Key);
                foreach (var w in item)
                    Console.WriteLine(w);
            }
            foreach (var item in bl.GroupByNumOfHostingUnit())
            {
                Console.WriteLine(item.Key);
                foreach (var w in item)
                    Console.WriteLine(w);
            }
            foreach (var item in bl.GroupOfHostingUnitsByPlace())
            {
                Console.WriteLine(item.Key);
                foreach (var w in item)
                    Console.WriteLine(w);
            }
     
            Console.ReadLine();
        }
    }
}
            
