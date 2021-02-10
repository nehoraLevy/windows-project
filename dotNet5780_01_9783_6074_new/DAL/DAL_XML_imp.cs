using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Linq;
using BE;
using System.Xml.Serialization;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
namespace DAL
{
    /// <summary>
    /// implementatin of IDAL by XML files
    /// </summary>
    public class DAL_XML_imp : Idal
    {
        XElement configRoot;
        XElement GuestRequestRoot;
        XElement BankBranchRoot;
        private readonly string configPath = "config.xml";
        private readonly string guestRequestPath ="guestRequest.xml";
        private readonly string hostingUnitPath = "hostingUnit.xml";
        private readonly string orderPath = "order.xml";
        const string bankPath = @"atm.xml";//bank path
        public static List<BE.HostingUnit> hostingUnitlist = new List<HostingUnit>();
        public static List<BE.Order> orderlist = new List<Order>();
        public DAL_XML_imp()
        {
            if (!File.Exists(configPath))
            {
                SaveConfigToXml();
            }
            else
            {
                configRoot = XElement.Load(configPath);
                BE.Configuration.GuestRequestKeyS = Convert.ToInt32(configRoot.Element("GuestRequestKeyS").Value);
                BE.Configuration.OrderKeyS = Convert.ToInt32(configRoot.Element("OrderKeyS").Value);
                BE.Configuration.HostingUnitKeyS = Convert.ToInt32(configRoot.Element("HostingUnitKeyS").Value);
                BE.Configuration.CommissionPerClosedOrder = Convert.ToInt32(configRoot.Element("CommissionPerClosedOrder").Value);
                BE.Configuration.NumDaysExpiringOrder = Convert.ToInt32(configRoot.Element("NumDaysExpiringOrder").Value);

            }
            if (!File.Exists(guestRequestPath))
            {
                CreateGuestReguestFile();
            }
            else GuestRequestRoot = XElement.Load(guestRequestPath);

            if (!File.Exists(hostingUnitPath))//we use XmlSerializer
            {
                SaveToXML(hostingUnitlist, hostingUnitPath);
            }
            else hostingUnitlist = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            if (!File.Exists(orderPath))//we use XmlSerializer
            {
                SaveToXML(orderlist, orderPath);
            }
            else orderlist = LoadFromXML<List<Order>>(orderPath);
            if (!File.Exists(bankPath))//we use XmlSerializer
            {
                BankBranchRoot = XElement.Load(bankPath);
                //SaveToXML(new List<BankBranch>(), bankPath);
            }
            else BankBranchRoot = XElement.Load(bankPath); 
            //BankBranchlist = LoadFromXML<List<BankBranch>>(bankPath);

        }
        /// <summary>
        /// Save To XML tamplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="path"></param>
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source); file.Close();
        }
        public void SaveGuestRequestList(List<BE.GuestRequest> guestRequestList)
        {
            GuestRequestRoot = new XElement("GuestRequest");
            try
            {
                foreach (GuestRequest item in guestRequestList)
                {
                    XElement GuestRequestKey = new XElement("GuestRequestKey", item.GuestRequestKey);
                    XElement PrivateName = new XElement("PrivateName", item.PrivateName);
                    XElement FamilyName = new XElement("FamilyName", item.FamilyName);
                    XElement MailAddress = new XElement("MailAddress", item.MailAddress);
                    XElement Status = new XElement("Status", item.Status);
                    XElement RegistrationDate = new XElement("RegistrationDate", item.RegistrationDate);
                    XElement EntryDate = new XElement("EntryDate", item.EntryDate);
                    XElement ReleaseDate = new XElement("ReleaseDate", item.ReleaseDate);
                    XElement Area = new XElement("Area", item.Area);
                    XElement SubArea = new XElement("SubArea", item.SubArea);
                    XElement Type = new XElement("Type", item.Type);
                    XElement Adults = new XElement("Adults", item.Adults);
                    XElement Children = new XElement("Children", item.Children);
                    XElement Pool = new XElement("Pool", item.Pool);
                    XElement Jacuzzi = new XElement("Jacuzzi", item.Jacuzzi);
                    XElement Garden = new XElement("Garden", item.Garden);
                    XElement ChildrensAttractions = new XElement("ChildrensAttractions", item.ChildrensAttractions);
                    XElement guestRequest = new XElement("GuestRequest", GuestRequestKey, PrivateName, FamilyName, MailAddress, Status, RegistrationDate, EntryDate, ReleaseDate, Area, SubArea, Type, Adults, Children, Pool, Jacuzzi, Garden, ChildrensAttractions);
                    GuestRequestRoot.Add(guestRequest);
                }
                GuestRequestRoot.Save(guestRequestPath);

            }
            catch (Exception)
            { }
        }
        private void CreateGuestReguestFile()
        {
            GuestRequestRoot = new XElement("GuestRequestRoot");
            GuestRequestRoot.Save(guestRequestPath);
        }
        private void LoadGuestRequest()
        {
            try
            {
                GuestRequestRoot = XElement.Load(guestRequestPath);
            }
            catch
            {
                throw new Exception("file load problem");
            }
        }
        private void LoadBankBranch()
        {
            try
            {
                BankBranchRoot = XElement.Load(bankPath);
            }
            catch
            {
                throw new Exception("file load problem");
            }
        }
        public void addGuestRequest(BE.GuestRequest guestRequest)
        {
            XElement GuestRequestKey = new XElement("GuestRequestKey", configRoot.Element("GuestRequestKeyS").Value);
            //קידום המפתח בקונפיג
            int temp = int.Parse(configRoot.Element("GuestRequestKeyS").Value);
            temp++;
            configRoot.Element("GuestRequestKeyS").Value = Convert.ToString(temp);
            configRoot.Save(configPath);
            XElement PrivateName = new XElement("PrivateName", guestRequest.PrivateName);
            XElement FamilyName = new XElement("FamilyName", guestRequest.FamilyName);
            XElement MailAddress = new XElement("MailAddress", guestRequest.MailAddress);
            XElement Status = new XElement("Status", guestRequest.Status);
            XElement RegistrationDate = new XElement("RegistrationDate", guestRequest.RegistrationDate);
            XElement EntryDate = new XElement("EntryDate", guestRequest.EntryDate);
            XElement ReleaseDate = new XElement("ReleaseDate", guestRequest.ReleaseDate);
            XElement Area = new XElement("Area", guestRequest.Area);
            XElement SubArea = new XElement("SubArea", guestRequest.SubArea);
            XElement Type = new XElement("Type", guestRequest.Type);
            XElement Adults = new XElement("Adults", guestRequest.Adults);
            XElement Children = new XElement("Children", guestRequest.Children);
            XElement Pool = new XElement("Pool", guestRequest.Pool);
            XElement Jacuzzi = new XElement("Jacuzzi", guestRequest.Jacuzzi);
            XElement Garden = new XElement("Garden", guestRequest.Garden);
            XElement ChildrensAttractions = new XElement("ChildrensAttractions", guestRequest.ChildrensAttractions);
            XElement guestRequest1 = new XElement("GuestRequest", GuestRequestKey, PrivateName, FamilyName, MailAddress, Status, RegistrationDate, EntryDate, ReleaseDate, Area, SubArea, Type, Adults, Children, Pool, Jacuzzi, Garden, ChildrensAttractions);
            GuestRequestRoot.Add(guestRequest1);
            GuestRequestRoot.Save(guestRequestPath);
        }
        public void updateGuestRequest(BE.GuestRequest guestRequest)
        {
            XElement guestRequestElement = (from g in GuestRequestRoot.Elements()
                                            where int.Parse(g.Element("GuestRequestKey").Value) == guestRequest.GuestRequestKey
                                            select g).FirstOrDefault(); //חיפוש הסטודנט הנדרש
            if (guestRequestElement == null)
                throw new Exception("not found");
            else guestRequestElement.Element("Status").Value = (guestRequest.Status).ToString();//מותר לעדכן רק את הסטטוס
            GuestRequestRoot.Save(guestRequestPath);
        }
        public List<BE.GuestRequest> GetGuestRequest()
        {
            LoadGuestRequest();
            List<BE.GuestRequest> guestRequests=new List<GuestRequest>();
            try
            {
                guestRequests =
                    (from g in GuestRequestRoot.Elements()
                     select new GuestRequest()
                     {
                         GuestRequestKey=int.Parse(g.Element("GuestRequestKey").Value),
                         PrivateName = g.Element("PrivateName").Value,
                         FamilyName = g.Element("FamilyName").Value,
                         MailAddress = g.Element("MailAddress").Value,
                         Status = (statusMakeChange)Enum.Parse(typeof(BE.statusMakeChange), g.Element("Status").Value),
                         RegistrationDate = DateTime.Parse(g.Element("RegistrationDate").Value),
                         EntryDate = DateTime.Parse(g.Element("EntryDate").Value),
                         ReleaseDate = DateTime.Parse(g.Element("ReleaseDate").Value),
                         Area = (placeOfVecation)Enum.Parse(typeof(BE.placeOfVecation), g.Element("Area").Value),
                         SubArea = (City)Enum.Parse(typeof(BE.City), g.Element("SubArea").Value),
                         Type = (typeOfVecation)Enum.Parse(typeof(BE.typeOfVecation), g.Element("Type").Value),
                         Adults = int.Parse(g.Element("Adults").Value),
                         Children = int.Parse(g.Element("Children").Value),
                         Pool = (Possibility)Enum.Parse(typeof(BE.Possibility), g.Element("Pool").Value),
                         Jacuzzi = (Possibility)Enum.Parse(typeof(BE.Possibility), g.Element("Jacuzzi").Value),
                         Garden = (Possibility)Enum.Parse(typeof(BE.Possibility), g.Element("Garden").Value),
                         ChildrensAttractions = (Possibility)Enum.Parse(typeof(BE.Possibility), g.Element("ChildrensAttractions").Value)

                     }).ToList();


            }
            catch
            {
                guestRequests = null;
            }
            return (guestRequests.Select(t => t.Copy())).ToList();
        }

        public List<BE.BankBranch> GetBankBranch()
        {
            LoadBankBranch();
            List<BE.BankBranch> bankBranches;
            try
            {
                bankBranches = (from b in BankBranchRoot.Elements()
                                select new BankBranch()
                                {
                                    BankNumber = int.Parse(b.Element("קוד_בנק").Value),
                                    BankName = b.Element("שם_בנק").Value,
                                    BranchNumber = int.Parse(b.Element("קוד_סניף").Value),
                                    BranchAddress = b.Element("כתובת_ה-ATM").Value,
                                    BranchCity = b.Element("ישוב").Value
                                }).ToList();
            }
            catch
            {
                bankBranches = null;
            }
            bankBranches=(bankBranches.Select(t => t.Copy())).ToList();
            //////foreach (var u in bankBranches) //מחיקת כפילויות, לבדוק למה לא עובד
            //////{
            //////    bankBranches.RemoveAll(t => t.BankNumber == u.BankNumber);
            //////}
            return bankBranches;
        }


        private void SaveConfigToXml()
        {
            configRoot = new XElement("config");
            try
            {
                configRoot.Add(new XElement("GuestRequestKeyS", BE.Configuration.GuestRequestKeyS),
                    new XElement("HostingUnitKeyS", BE.Configuration.HostingUnitKeyS),
                    new XElement("OrderKeyS", BE.Configuration.OrderKeyS),
                    new XElement("CommissionPerClosedOrder", BE.Configuration.CommissionPerClosedOrder),
                    new XElement("NumDaysExpiringOrder", BE.Configuration.NumDaysExpiringOrder));
                configRoot.Save(configPath);
            }
            catch (Exception)
            { }
        }


        /// <summary>
        /// Load From XML tamplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }
        /// <summary>
        /// dtor
        /// </summary>
        ~DAL_XML_imp()
        {
            GuestRequestRoot.Save(guestRequestPath);
            SaveToXML<List<HostingUnit>>(hostingUnitlist, hostingUnitPath);
            SaveToXML<List<Order>>(orderlist, orderPath);
            BankBranchRoot.Save(bankPath);
            SaveConfigToXml();
        }
        #region HostingUnit
        public void addHostingUnit(BE.HostingUnit hostingUnit)
        {
            
            hostingUnit.HostingUnitKey = Convert.ToInt32(configRoot.Element("HostingUnitKeyS").Value);
            int temp = int.Parse(configRoot.Element("HostingUnitKeyS").Value);
            temp++;
            configRoot.Element("HostingUnitKeyS").Value = Convert.ToString(temp);
            configRoot.Save(configPath);
            BE.HostingUnit ExsistHostingUnit = hostingUnitlist.FirstOrDefault(t => t.HostingUnitName == hostingUnit.HostingUnitName);
            if (ExsistHostingUnit != null)
                throw new Exception("The HostingUnit is already exsist");
            hostingUnitlist.Add(hostingUnit.Copy());
            SaveToXML<List<HostingUnit>>(hostingUnitlist, hostingUnitPath);
        }
        public void deleteHostingUnit(string HostingUnitName)
        {
            int count = hostingUnitlist.RemoveAll(a => a.HostingUnitName == HostingUnitName);
            if (count == 0)
                throw new Exception("not found");
            SaveToXML<List<HostingUnit>>(hostingUnitlist, hostingUnitPath);
        }
        public void updateDiaryHostingUnit(BE.HostingUnit hostingUnit)
        {
            hostingUnitlist.RemoveAll(t => t.HostingUnitName == hostingUnit.HostingUnitName);
            hostingUnitlist.Add(hostingUnit);
            SaveToXML<List<HostingUnit>>(hostingUnitlist, hostingUnitPath);
        }
        public void updateHostingUnit(string hostingUnitName, bool flag)
        {
            BE.HostingUnit hostingUnit = hostingUnitlist.FirstOrDefault(t => t.HostingUnitName == hostingUnitName);
            hostingUnit.Owner.CollectionClearance = flag;
            hostingUnitlist.RemoveAll(t => t.HostingUnitName == hostingUnit.HostingUnitName);
            hostingUnitlist.Add(hostingUnit);
            SaveToXML<List<HostingUnit>>(hostingUnitlist, hostingUnitPath);
        }
        public List<BE.HostingUnit> GetHostingUnit()
        {
            return hostingUnitlist.Select(t => t.Copy()).ToList();
        }
        #endregion

        #region Order
        public bool addOrder(int GuestRequestKey, int HostingUnitKey)
        {
            BE.Order order = new BE.Order();
            order.OrderKey = Convert.ToInt32(configRoot.Element("OrderKeyS").Value);
            int temp = int.Parse(configRoot.Element("OrderKeyS").Value); //קידום מפתח
            temp++;
            configRoot.Element("OrderKeyS").Value = Convert.ToString(temp);
            configRoot.Save(configPath);
            order.GuestRequestKey = GuestRequestKey;
            order.HostingUnitKey = HostingUnitKey;
            order.Status = BE.statusOfTheOrder.send_email;
            order.CreateDate = DateTime.Now;
            order.OrderDate = DateTime.Now;
            orderlist.Add(order.Copy());
            SaveToXML<List<Order>>(orderlist, orderPath);
            return true;
        }
        public void updateOrder(BE.Order order)
        {
            int count = orderlist.RemoveAll(a1 => a1.OrderKey == order.OrderKey);
            if (count == 0)
                throw new Exception("not found");
            orderlist.Add(order.Copy());
            SaveToXML<List<Order>>(orderlist, orderPath);
        }
        public List<BE.Order> GetOrders()
        {
            return orderlist.Select(t => t.Copy()).ToList();
        }
        #endregion

       

    }
}







