using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey
        {
            get; set;
        }
        private string PrivateName1;
        public string PrivateName
        {
            set { PrivateName1 = value; }
            get { return PrivateName1; }
        }
        
        private string FamilyName1;
        public string FamilyName
        {
            set { FamilyName1 = value; }
            get { return FamilyName1; }
        }
        private string MailAddress1;
        public string MailAddress
        {
            set { MailAddress1 = value; }
            get { return MailAddress1; }
        }
        private statusMakeChange Status1;
        public statusMakeChange Status
        {
            get { return Status1; }
            set { Status1 = value; }
        }
        private DateTime RegistrationDate1;
        public DateTime RegistrationDate
        {
            get { return RegistrationDate1; }
            set { RegistrationDate1 = value; }
        }
        private DateTime EntryDate1;
        public DateTime EntryDate
        {
            get { return EntryDate1; }
            set { EntryDate1 = value; }
        }
       private DateTime ReleaseDate1;
        public DateTime ReleaseDate
        {
            get { return ReleaseDate1; }
            set { ReleaseDate1 = value; }
        }
        private placeOfVecation Area1;
        public placeOfVecation Area
        {
            set { Area1 = value; }
            get { return Area1; }
        }
        private City SubArea1;
        public City SubArea
        {
            set { SubArea1 = value; }
            get { return SubArea1; }
        }
        private typeOfVecation Type1;
        public typeOfVecation Type
        {
            set { Type1 = value; }
            get { return Type1; }

        }

        private int Adults1;
        public int Adults
        {
            set { Adults1 = value; }
            get { return Adults1; }
        }
        private int Children1;
        public int Children
        {
            set { Children1 = value; }
            get { return Children1; }
        }
        public int Persons {

            //set { Persons=Adults + Children; }
            get { return Adults + Children; }
        }
        private Possibility Pool1;
        public Possibility Pool
        {
            set { Pool1 = value; }
            get { return Pool1; }
        }
        private Possibility Jacuzzi1;
        public Possibility Jacuzzi
        {
            set { Jacuzzi1 = value; }
            get { return Jacuzzi1; }
        }
        private Possibility Garden1;
        public Possibility Garden
        {
            set { Garden1= value; }
            get { return Garden1; }
        }
        private Possibility ChildrensAttractions1;
        public Possibility ChildrensAttractions
        {
            set { ChildrensAttractions1 = value; }
            get { return ChildrensAttractions1; }
        }

        public override string ToString()
        {
            string m =" The num of the guest request is: "+ GuestRequestKey+ "\n The name is: " + PrivateName1 + " " + FamilyName1 + "\n Teh gmail adress is: " + MailAddress1 + "\n The status of the order is: " 
                + Status1 + "\n The registration date is: " + RegistrationDate1 + "\n The begin date vacantion preferred is: " + EntryDate1 
                + "\n The desirable date for ending the holiday is: " + ReleaseDate1 + "\n The desirable area for the vacantion is: " + Area1 + "\n The desirable area for the vacantion is:" + SubArea1 
                + "\n The desitrable type of the hosting unit:" + Type1 + " \n The num of adult: " + Adults1 + "\n The num of children is: " + Children1 + "\n Did you want a pool? " + Pool1+
                 "\n Did you want a jacuzzi? " + Jacuzzi1 + " \n Did you want a garden? "+Garden1
                + "\n Did you want childrens attractions? " + ChildrensAttractions1 + "" +"\n";                                                                                                  
            return m;
        }

    }
}
