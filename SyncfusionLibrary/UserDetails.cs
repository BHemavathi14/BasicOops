using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    //enums 
   
    public enum Gender {Selected,Male,Female}
    public enum Department{Selected,ECE, EEE, CSE}

    public class UserDetails
    {
        /*a.	UserID (Auto Increment – SF3000)
b.	UserName
c.	Gender
d.	Department – (Enum – ECE, EEE, CSE)
e.	MobileNumber
f.	MailID
g.	WalletBalance
*/
        // Field
        // Static field
        private static int s_userID = 3000;
        // Properties
        public  string UserID  { get; } // REad only property
        public string UserName { get; set; }
        public Gender Gender {get; set;}
        public Department Department { get; set; }
        public long MobileNumber{ get; set; }
        public string MailID{ get; set; }
        public int WalletBalance { get; set; }

    // Constructor
    public UserDetails(string userName , Gender gender , Department department , long mobileNumber , string mailID , int walletBalance)
    {
        // auto incrementation 
        s_userID++;
        UserID = "SF"+s_userID;
        // assigning values 
        UserName = userName;
        Gender = gender;
        Department = department;
        MobileNumber = mobileNumber;
        MailID = mailID;
        WalletBalance = walletBalance;
    }

// Methods 
// get the recharge amount update wallet balance 
// wwallet recharge 
    public void WalletRecharge(int amount)
    {
        WalletBalance += amount;
    }
    // get the deduct amount update it
    //wallet deduction 
    public void WalletDeduct(int amount)
    {
        WalletBalance -= amount;
    }

    }
}