using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public static partial class Operations
    {
        public static void ShowMyDetails()
        {
            //personal details 
            Console.WriteLine($"Registration Number : {currentLoggedInUser.RegistrationNumber}\nName : {currentLoggedInUser.Name}\nAge : {currentLoggedInUser.Age}\nGender : {currentLoggedInUser.Gender}\nMobile Number : {currentLoggedInUser.MobileNumber}\nCity : {currentLoggedInUser.City}");

        }// end of show my details
        public static void TakeVaccination()
        {
            Console.WriteLine("|Vaccine id|vaccine Name|No Of Dose Available");
            foreach (VaccineClass vaccine in vaccineList)
            {
                Console.WriteLine($"|{vaccine.VaccineID}|{vaccine.VaccineName}|{vaccine.NoOfDoseAvailable}|");
            }
            Console.Write("Pick Vaccine id : ");
            string vaccineID = Console.ReadLine().ToUpper();
            int count = 0;
            string vaccinationId="";
            foreach (VaccinationClass vaccination in vaccinationList)
            {
                if (currentLoggedInUser.RegistrationNumber == vaccination.RegistrationNumber)
                {
                    count += 1;
                    vaccinationId=vaccination.VaccinationID;
                }
            }
            if (count == 0)
            {
                if (currentLoggedInUser.Age > 14)
                {
                    VaccinationClass vaccination = new VaccinationClass(currentLoggedInUser.RegistrationNumber, vaccineID, 1, DateTime.Now);
                    vaccinationList.Add(vaccination);
                    foreach (VaccineClass vaccine in vaccineList)
                    {
                        if (vaccineID == vaccine.VaccineID)
                        {
                            vaccine.NoOfDoseAvailable -= 1;
                            break;
                        }
                    }
                    Console.WriteLine("your 1st dose of vaccination completed successfully.");
                }
                else
                {
                    Console.WriteLine("You are not eligible to take vaccination.");
                }
            }
            else if (count < 3)
            {
                bool flag = true;
                foreach (VaccinationClass vaccination in vaccinationList)
                {
                    if (vaccineID == vaccination.VaccineID && currentLoggedInUser.RegistrationNumber == vaccination.RegistrationNumber && vaccinationId==vaccination.VaccinationID)
                    {
                        flag = false;
                        TimeSpan span = DateTime.Now - vaccination.VaccinatedDate;
                        int days = (int)span.TotalDays;
                        if (days > 30)
                        {
                            VaccinationClass vaccination1 = new VaccinationClass(currentLoggedInUser.RegistrationNumber, vaccineID, vaccination.DoseNumber + 1, DateTime.Now);
                            foreach (VaccineClass vaccine in vaccineList)
                            {
                                if (vaccineID == vaccine.VaccineID)
                                {
                                   vaccine.NoOfDoseAvailable -=1;
                                    break;
                                }
                            }
                            Console.WriteLine($"your {vaccination1.DoseNumber} dose of vaccination completed successfully.");
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Come after completing 30 days of your vaccination.");
                            break;
                        }
                    }
                }
                if (flag)
                {
                    foreach (VaccineClass vaccine in vaccineList)
                    {
                        if (vaccineID == vaccine.VaccineID)
                        {
                            Console.Write($"You have selected different vaccine. You can vaccine with {vaccine.VaccineName} ");
                            break;
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
            }
        }// end of take vaccination
        public static void MyVaccinationHistory()
        {
            int count = 0;
            foreach (VaccinationClass vaccination in vaccinationList)
            {
                if (currentLoggedInUser.RegistrationNumber == vaccination.RegistrationNumber)
                {
                    count += 1;
                }
            }
            if (count >= 3)
            {
                Console.WriteLine("|Vaccination Id|Registration Number|Vaccine Id|Dose NUmber |Vaccinated Date|");
                foreach (VaccinationClass vaccination in vaccinationList)
                {
                    if (currentLoggedInUser.RegistrationNumber == vaccination.RegistrationNumber)
                    {
                        Console.WriteLine($"{vaccination.VaccinationID}|{vaccination.RegistrationNumber}|{vaccination.VaccineID}|{vaccination.DoseNumber}|{vaccination.VaccinatedDate.ToString("dd/MM/yyyy")}|");
                    }
                }
            }
            else
            {
                Console.WriteLine("you have no history to show");
            }
        }//end of my vaccination history
        public static void NextDueDate()
        {
             DateTime vaccinatedDate =DateTime.Now;
            int count=0;
            foreach (VaccinationClass vaccination in vaccinationList)
            {
                if (currentLoggedInUser.RegistrationNumber == vaccination.RegistrationNumber)
                {
                    count += 1;
                    vaccinatedDate=vaccination.VaccinatedDate;
                }
            }
            if(count==0)
            {
                Console.WriteLine("you can take vaccine now");
            }
            else if (count<3)
            {
                Console.WriteLine($"your next due is {vaccinatedDate.AddDays(30).ToString("dd/MM/yyyy")}");
            }
            else
            {
                Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");
            }


        }//end of next due date 

    }
}