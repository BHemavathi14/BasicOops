using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public static partial class Operations
    {
        static List<BeneficiaryClass> benificiaryList=new List<BeneficiaryClass>();
        static List<VaccinationClass> vaccinationList = new List<VaccinationClass>();
        static List<VaccineClass> vaccineList = new List<VaccineClass>();
        static BeneficiaryClass currentLoggedInUser;

        public static void AddDefaultData()
        {
            /*BID1001	Ravichandran	21	Male	8484484	Chennai
            BID1002	Baskaran	22	Male	8484747	Chennai
            */
            BeneficiaryClass benificiary1 = new BeneficiaryClass("Ravichandran",21,Gender.Male,"8484484","Chennai");
             BeneficiaryClass benificiary2 = new BeneficiaryClass("Baskaran",22,Gender.Male,"84846794","Chennai");
             benificiaryList.Add(benificiary1);
             benificiaryList.Add(benificiary2);
            
            /*BID1001	CID2001	1	11/11/2021
                BID1001	CID2001	2	11/03/2022
                BID1002	CID2002	1	04/04/2022
                */
            VaccinationClass vaccination1 =new VaccinationClass("BID1001","CID2001",1,new DateTime(2021,11,11));
            VaccinationClass vaccination2 =new VaccinationClass("BID1001","CID2001",2,new DateTime(2022,03,11));
            VaccinationClass vaccination3 =new VaccinationClass("BID1002","CID2002",1,new DateTime(2022,04,04));

            vaccinationList.AddRange(new List<VaccinationClass>(){vaccination1,vaccination2,vaccination3});

            /*Covishield	50
            Covaccine	50
            */

            VaccineClass vaccine1 = new VaccineClass(VaccineName.Covishield,50);
            VaccineClass vaccine2 = new VaccineClass(VaccineName.Covaccine,50);

            vaccineList.Add(vaccine1);
            vaccineList.Add(vaccine2);

        }// end of adddefault data

        public static void MainMenu()
        {
            string mainOption="yes";
            do
            {
                Console.WriteLine("<<<<<<<<<<<<<<<MAIN MENU>>>>>>>>>>>>>>>>>");
                Console.WriteLine("1.Beneficiary Registration\n2.Login\n3.Get Vaccine Info\n4.Exit");
                Console.Write("select : ");
                int mainChoice=int.Parse(Console.ReadLine());
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("----------------------Beneficiary Registration-----------------------");
                        BenificiaryRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("----------------------Login-----------------------------");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("-------------------Get Vaccine Info-----------------------");
                        GetVaccineInfo();
                        break;
                    }
                    case 4:
                    {
                        mainOption="no";
                        break;
                    }
                }


            }while(mainOption=="yes");
            
        }// end of main function

        public static void BenificiaryRegistration()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter your Gender (maale/female) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your mobile Number : ");
            string mobile  = Console.ReadLine();
            Console.Write("Enter your City :");
            string city= Console.ReadLine();

            BeneficiaryClass person = new BeneficiaryClass(name,age,gender,mobile,city);
            benificiaryList.Add(person);
            Console.WriteLine($"{name} your Registration is successful.Registration number is {person.RegistrationNumber}");
        }// end of user registration

        public static void Login()
        {
            /*1.	Show My Details
2.	Take Vaccination
3.	My Vaccination History
4.	Next Due Date
5.	Exit
*/
            string subChoice="yes";
            Console.Write("Enter your Registration Number ID : ");
             string registrationNumber =Console.ReadLine().ToUpper();
             bool flag = true;
            foreach (BeneficiaryClass person in benificiaryList)
            {
                if (registrationNumber == person.RegistrationNumber)
                {
                    flag=false;
                    currentLoggedInUser=person;
                    do
                    {
                        Console.WriteLine("<<<<<<<<<<<<<<<SUB MENU>>>>>>>>>>>>>>>>>");
                        Console.WriteLine("\n1.Show My Details\n2.Take Vaccinations\n3.My Vaccination History\n4.Next Due Date\n5.Exit");
                        Console.Write("select : ");
                        int subOption = int.Parse(Console.ReadLine());
                        switch (subOption)
                        {
                            case 1:
                                {
                                    Console.WriteLine("----------Show My Details-------------");
                                    ShowMyDetails();
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("------------Take Vaccinations---------------");
                                    TakeVaccination();
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("-----------------My Vaccination History-----------------");
                                    MyVaccinationHistory();
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("----------------Next Due Date-------------------");
                                    NextDueDate();
                                    break;
                                }
                            case 5:
                                {
                                    subChoice = "no";
                                    break;
                                }
                        }

                    } while (subChoice == "yes");
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid user Id");
            }
        }// end of user login 
        public static void GetVaccineInfo()
        {
            Console.WriteLine("|Vaccine id|vaccine Name|No Of Dose Available");
            foreach (VaccineClass vaccine in vaccineList)
            {
                Console.WriteLine($"|{vaccine.VaccineID}|{vaccine.VaccineName}|{vaccine.NoOfDoseAvailable}|");
            }
        }


    }
}