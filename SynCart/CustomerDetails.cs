using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {
        /*•	CustomerID (Auto Increment -CID1000)
        •	Name
        •	City
        •	MobileNumber
        •	WalletBalance
        •	EmailID
        */ 
        private int _balance;
        private static int s_customerID=1000;
        public string CustomerID { get; set; }
        public string Name { get; set; } 
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public int WalletBalance { get{return _balance;}}
        public string EmailID { get; set; }

        public CustomerDetails(string name,string city , string mobileNUmber,int walletBalance,string emailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            MobileNumber=mobileNUmber;
            _balance=walletBalance;
            EmailID=emailID;

        }

        public void WalletRecharge(int amount)
        {
            _balance += amount;
        }
        public void DeductAmount(int amount)
        {
            _balance -= amount;
        }

    }
}