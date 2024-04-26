using System;

namespace BankAccountOpening
{
    public enum Gender {Select , Male , Female , Transgender}
    public class AccountDetails
    {

        private static int s_customerId=1000;
        public string CustomerName { get; set; }
        public int Balance { get; set; }
        public long PhoneNumber { get; set; }
        public string MailId { get; set; }
        public DateTime Dob { get; set; }
        public string CustomerId{ get; }

        public Gender Gender {get;set;}


        public AccountDetails()
        {
            Gender= Gender.Select;
            Balance =0;
        }
        public AccountDetails(string name , DateTime dob , Gender gender , long mobileNumber , string mail)
        {
            s_customerId++;
            CustomerId = "HDFC"+s_customerId;
            CustomerName = name;
            Dob = dob;
            Gender = gender;
            PhoneNumber=mobileNumber;
            MailId=mail;

        }

        
    }


}
