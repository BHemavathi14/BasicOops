using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculation
{
    public class EbBillCalc
    {
        // field
        private static int s_meterId =1000;
        public string UserName { get; set; }
        public long MobileNumber { get; set; }
        public string MailId { get; set; }
        public int UnitsUsed { get; set; }
        public string MeterId { get;  }

        public EbBillCalc(string name,long mobileNumber,string mail,int units)
        {
            s_meterId++;
            MeterId = "EB"+s_meterId;
            MobileNumber =mobileNumber;
            MailId = mail;
            UnitsUsed = units;
        }
    }
}