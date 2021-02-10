//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace DS
//{
//    public class DataSource
//    {
//        public static List<BE.BankBranch> listBankBranch = new List<BE.BankBranch>
//                {
//                    new BE.BankBranch()
//                    {
//                        BankNumber = BE.Configuration.BankNumberS++,
//                        BankName = "discont",
//                        BranchNumber = 41,
//                        BranchAddress = "yaffo 220",
//                        BranchCity = "jerusalem"
//                    },
//                    new BE.BankBranch()
//                    {
//                        BankNumber = BE.Configuration.BankNumberS++,
//                        BankName = "leumi",
//                        BranchNumber = 51,
//                        BranchAddress ="herzel 110",
//                        BranchCity = "jerusalem"
//                    },
//                    new BE.BankBranch()
//                    {
//                        BankNumber = BE.Configuration.BankNumberS++,
//                        BankName = "mizrahi tfahot",
//                        BranchNumber = 61,
//                        BranchAddress = "givat shoul 38",
//                        BranchCity = "jerusalem"
//                    },
//                    new BE.BankBranch()
//                    {
//                        BankNumber = BE.Configuration.BankNumberS++,
//                        BankName = "discont",
//                        BranchNumber = 71,
//                        BranchAddress = " nezer david 10",
//                        BranchCity = "jerusalem"
//                    },
//                    new BE.BankBranch()
//                    {
//                        BankNumber = BE.Configuration.BankNumberS++,
//                        BankName = "bank yahav",
//                        BranchNumber = 81,
//                        BranchAddress = "bne brit 23",
//                        BranchCity = "ashdod"
//                    }
//        };
//        public static List<BE.HostingUnit> listHostingUnit = new List<BE.HostingUnit>()
//        {
//            new BE.HostingUnit()
//            {
//                HostingUnitKey=BE.Configuration.HostingUnitKeyS++,
//                HostingUnitName="Neve Zedek",
//                Owner=new BE.Host()
//                {
//                    HostKey=327009817,
//                    PrivateName ="nehora",
//                    FamilyName ="levy",
//                    PhoneNumber ="0542774427",
//                    MailAddress ="nehora20@gmail.com",
//                    BankAccountNumber=166685,
//                    BankBranchDetails= listBankBranch[0],
//                    CollectionClearance=false
//                },

//                Diary=new bool[32,13],
//                Area=BE.placeOfVecation.north,
//                SubArea=BE.City.Tsfat,
//                Type=BE.typeOfVecation.tent,
//                Adults=5, 
//                Children=9, 
//                Pool=true,
//                Jacuzzi=true,
//                Garden=false, 
//                ChildrensAttractions=true
//            },
//            new BE.HostingUnit()
//            {
//                HostingUnitKey=BE.Configuration.HostingUnitKeyS++,
//                HostingUnitName="Nezer David",
//                Owner=new BE.Host()
//                {
//                   HostKey=327009783,
//                    PrivateName ="batya rivka",
//                    FamilyName ="tamsot",
//                    PhoneNumber ="0544988867",
//                    MailAddress ="batyarivka@gmail.com",
//                    BankAccountNumber=166685,
//                    BankBranchDetails= listBankBranch[1],
//                    CollectionClearance=true
//                },
//                Diary=new bool[32,13],
//                Area=BE.placeOfVecation.all_cities,
//                SubArea=BE.City.Jerusalem,
//                Type=BE.typeOfVecation.hotel_room,
//                Adults=5,
//                Children=9,
//                Pool=true,
//                Jacuzzi=true,
//                Garden=true,
//                ChildrensAttractions=false
//            }
//        };
//        public static List<BE.Order> listOrder = new List<BE.Order>()
//        {
//            new BE.Order()
//            {
//                //GuestRequestKey=BE.Configuration.GuestRequestKeyOrderS++,
//                //HostingUnitKey=BE.Configuration.HostingUnitKeyOrderS++,
//                OrderKey=BE.Configuration.OrderKeyS++,
//                Status=BE.statusOfTheOrder.not_deal_with,
//                CreateDate=new DateTime(2019,1,1),
//                OrderDate=new DateTime(2019,1,2)
//            },
//            new BE.Order()
//            {
//                //HostingUnitKey=BE.Configuration.HostingUnitKeyOrderS++,
//                //GuestRequestKey=BE.Configuration.GuestRequestKeyOrderS++,
//                OrderKey=BE.Configuration.OrderKeyS++,
//                Status=BE.statusOfTheOrder.The_vacantion_close,
//                CreateDate=new DateTime(2019,6,1),
//                OrderDate=new DateTime(2019,7,2)
//            }
//        };
//        public static List<BE.GuestRequest> listGuestRequest = new List<BE.GuestRequest>()
//        {
//            new BE.GuestRequest()
//            {
//                GuestRequestKey=BE.Configuration.GuestRequestKeyS++,
//                PrivateName="batya",
//                FamilyName="tamsot",
//                MailAddress="batya@gmail.com",
//                Status=BE.statusMakeChange.open,
//                RegistrationDate=new DateTime(2020,4,4),
//                EntryDate=new DateTime(2020,5,5),
//                ReleaseDate=new DateTime(2020,5,10),
//                Area=BE.placeOfVecation.jerusalem,
//                SubArea=BE.City.Jerusalem,
//                Type=BE.typeOfVecation.tent,
//                Adults=2,
//                Children=3,
//                Pool= BE.Possibility.possible,
//                Jacuzzi= BE.Possibility.necessary,
//                Garden=BE.Possibility.uninterested,
//                ChildrensAttractions=BE.Possibility.necessary,

//            },
//             new BE.GuestRequest()
//             {
//                GuestRequestKey=BE.Configuration.GuestRequestKeyS++,
//                PrivateName="nehora",
//                FamilyName="levy",
//                MailAddress="nehora@gmail.com",
//                Status=BE.statusMakeChange.open,
//                RegistrationDate=new DateTime(2020,6,7),
//                EntryDate=new DateTime(2020,6,7),
//                ReleaseDate=new DateTime(2020,6,10),
//                Area=BE.placeOfVecation.south,
//                SubArea=BE.City.Eilat,
//                Type=BE.typeOfVecation.hotel_room,
//                Adults=5,
//                Children=2,
//                Pool= BE.Possibility.possible,
//                Jacuzzi= BE.Possibility.necessary,
//                Garden=BE.Possibility.possible,
//                ChildrensAttractions=BE.Possibility.uninterested,
//             }
//        };
//    }
//}
