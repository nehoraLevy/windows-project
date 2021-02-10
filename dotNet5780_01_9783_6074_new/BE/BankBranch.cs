using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {
        //private int BankNumber1;
        public int BankNumber
        {
            set;
            get;
        }

        private string BankName1;
        public string BankName
        {
            set { BankName1 = value; }
            get { return BankName1; }
        }
        private int BranchNumber1;
        public int BranchNumber
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
        
        public override string ToString()
        {
            string m = "\n The num of the bank is: " + BankNumber + " \n The num of the bank: " + BankName + " \n The branch bank number: " + BranchNumber1 + " \n The branch bank adress: " + BranchAddress1 + "\n the branch bank city: " + BranchCity + " \n";
            return m;

        }
    }
}
