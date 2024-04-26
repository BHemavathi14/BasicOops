using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum VaccineName{Covishield, Covaccine}
    public class VaccineClass
    {
        /*a.	VaccineID {Auto Incremented ID – CID2001}
            b.	VaccineName {Enum – Covishield, Covaccine}
            c.	NoOfDoseAvailable
            */
        private static int s_vaccineID=2000;
        public string VaccineID { get; }
        public VaccineName VaccineName{ get; set; }
        public int NoOfDoseAvailable { get; set; }

        public VaccineClass(VaccineName vaccineName,int noOfDoseAvailable)
        {
            s_vaccineID++;
            VaccineID="CID"+s_vaccineID;
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;
        }
    }
}