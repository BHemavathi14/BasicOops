using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public class VaccinationClass
    {
        /*•	VaccinationID (Auto increment – VID3001)
            •	Registration Number (Beneficiary Reg. num)
            •	VaccineID
            •	DoseNumber – (1,2,3)
            •	Vaccinated Date (DateTime.Now)
            */
    
        private static int s_vaccinationID=3000;
        public string VaccinationID { get;  }
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public int DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }

        public VaccinationClass(string registrationNumber,string vaccineID,int doseNumber,DateTime vaccinationDate)
        {
            s_vaccinationID++;
            VaccinationID="VID"+s_vaccinationID;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinationDate;

        }
    }
}