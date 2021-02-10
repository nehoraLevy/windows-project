using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class BankAccount
    {
        private int BankNumber1;
        public int BankNumber
        {
            set { BankNumber1 = Configuration.BankNumberS++; }
            get { return BankNumber1; }
        }

        private string BankName1;
        public string BankName
        {
            set { BankName1 = value; }
            get { return BankName1; }
        }
        private string BranchNumber1;
        public string BranchNumber
        {
            set { BranchNumber1 = value; }
            get { return BranchNumber1; }
        }
        private string BranchAddress1;
        public string BranchAddress
        {
            set { BranchAddress1 = value; }
            get { return BranchAddress1; }
        }
        private string BranchCity1;
        public string BranchCity
        {
            set { BranchCity1 = value; }
            get { return BranchCity1; }
        }
        private int BankAccountNumber1;
        public int BankAccountNumber
        {
            set { BankAccountNumber1 = value; }
            get { return BankAccountNumber1; }
        }
        public override string ToString()
        {
            string m = "מספר בנק: " + BankNumber1 + " \nשם הבנק: " + BankName + " \nמספר הסניף: " + BranchNumber1 + " \nכתובת הסניף: " + BranchAddress1 + "\nעיר הסניף: " + BranchCity + "\nמספר חשבון הבנק: " + BankAccountNumber + " \n";
            return m;

        }
    }
}
