using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        private int HostKey1;
        public int HostKey
        {
            get { return HostKey1; }
            set { HostKey1 = value; }
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
        private string PhoneNumber1;
        public string PhoneNumber
        {
            set { PhoneNumber1 = value; }
            get { return PhoneNumber1; }
        }
        private bool CollectionClearance1;
        public bool CollectionClearance
        {
            set { CollectionClearance1 = value; }
            get { return CollectionClearance1; }
        }
        private string MailAddress1;
        public string MailAddress
        {
            set { MailAddress1 = value; }
            get { return MailAddress1; }
        }
        private BankBranch BankBranchDetails1;
        public BankBranch BankBranchDetails
        {
            set { BankBranchDetails1 = value; }
            get { return BankBranchDetails1; }
        }
        private long BankAccountNumber1;
        public long BankAccountNumber
        {
            set { BankAccountNumber1 = value; }
            get { return BankAccountNumber1; }
        }
        public override string ToString()
        {
            string s = "\n The ID number of the owner is: " + HostKey + "\n The name is : " + PrivateName1 + " " + FamilyName1 + "\n The phone number is :" + PhoneNumber1 + "\n  The gmail adress is: " + MailAddress1 + "\n The bank detail is: " + BankBranchDetails.ToString() + "\n permission of the bank: " + CollectionClearance+ "\n The num of the bank accaount: " + BankAccountNumber+  "\n";      
            return s;


        }
    }
}
