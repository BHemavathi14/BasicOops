using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CollegeDetails;

namespace Application
{
    // which operation does not depend on object, we can specify that as static
    //Static class
    public static class Operations
    {
        // Local/Global Object Creation => this object is created for we can use object in any other methods 
        static StudentDetails currentLoggedInStudent;
        // Static List Creation
        static List<StudentDetails> studentsList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        // Main Menu method 
        public static void MainMenu()
        {
            Console.WriteLine("Welcome to Syncfusion College of Engineering and Technology");
            string mainChoice = "yes";
            do
            {
                Console.WriteLine("*********************MAIN MENU ***************************");
                // Need to show the main menu option.
                // Need to get an input from user and Validate.
                Console.WriteLine("\n1.Student Registration\n2.Student Login\n3.Department wise seat availability\n4.Exit");
                Console.Write("Select an Option: ");
                int mainOption;
                bool tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                //error handling
                while(!tempMainOption || mainOption>4)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                }
                //Need to create mainmenu structure 
                switch (mainOption)
                {
                    case 1:
                        {
                            
                            Console.WriteLine("***********Student Registration*********************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            
                            Console.WriteLine("******************Student Login*********************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*********************Departmentwise Seat Availability*********************");
                            DepartmentwiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            mainChoice="no";
                            Console.WriteLine("********************Application Exited Successfully*************************");
                            break;
                        }
                }
                // Need to iterate until the option is exit.
            } while (mainChoice=="yes");
        }// Main menu ends

        // Student Registration
        public static void StudentRegistration()
        {
            // Need to get required details 
            Console.Write("Enter your Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your father Name : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your DOB as Specified dd/Mm/yyyy  format : ");
            DateTime dob ;
            bool tempDateTime = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            while (!tempDateTime)
            {
                System.Console.WriteLine("Invalid Input. Enter a valid DateTime");
                tempDateTime = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            }
            Console.Write("Enter your Gender (Male/Female) : ");
            Gender gender;
            bool tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            while(!tempGender)
            {
                System.Console.WriteLine("Invalid Input. Enter a valid Gender");
                tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            }
            Console.Write("Enter your Physics Mark : ");
            int physicsMark;
            bool tempPhysics = int.TryParse(Console.ReadLine(), out physicsMark);
            while(!tempPhysics)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempPhysics = int.TryParse(Console.ReadLine(), out physicsMark);
            }
            Console.Write("Enter your Chemistry Mark : ");
            int chemistryMark;
            bool tempChemistry = int.TryParse(Console.ReadLine(), out chemistryMark);
            while(!tempChemistry)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempChemistry = int.TryParse(Console.ReadLine(), out chemistryMark);
            }
            Console.Write("Enter your Maths Mark : ");
            int mathsMark;
            bool tempMaths = int.TryParse(Console.ReadLine(), out mathsMark);
            while(!tempMaths)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempMaths = int.TryParse(Console.ReadLine(), out mathsMark);
            }
            // Need to create an object
            StudentDetails student = new StudentDetails(name,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
            // Need to add in the List 
            studentsList.Add(student);
            // Need to display confirmation message and ID
            Console.WriteLine($"Registration Successful . Student ID : {student.StudentID}");

        } // Registration ends

        // student Login
        public static void StudentLogin()
        {
            //Need to get ID input 
            Console.Write("Enter your Student Id : ");
            string loginID = Console.ReadLine().ToUpper();
            //validate by its presence in this list.
            bool flag = true;
            foreach(StudentDetails student in studentsList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    //
                    flag = false;
                    //assigning current user to global variable 
                    currentLoggedInStudent = student;
                    Console.WriteLine("Logged In successfully ");
                    // need to call sub menu
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid Login ID or ID is not present");
            }
            //if not - invalid

        }//student Login ends 

        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("********************SUB MENU********************");
                // need to submenu option
                Console.WriteLine("\n1.Check Eligibility\n2.Show Details\n3.Take Admission\n4.Cancel Admission\n5.Show Admission Details\n6.Exit");
                //getting user option
                Console.Write("Enter Your Option : ");
                int subOption;
                bool temp = int.TryParse(Console.ReadLine(),out subOption);
                while(!temp || subOption>6)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    temp = int.TryParse(Console.ReadLine(),out subOption);
                }
                // iteration
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("*********Check Eligibility*********");
                        CheckEligibility();
                        break;
                    }
                    case 2 :
                    {
                        Console.WriteLine("**********Show Details**********");
                        ShowDetails();
                        break;
                    }
                    case 3 :
                    {
                        Console.WriteLine("**********Take Admission***********");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("***********Cancel Admission***********");
                        CancelAdmission();
                        break;
                    }
                    case 5 :
                    {
                        Console.WriteLine("***********Admission Details***********");
                        AdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("Taking back to MainMenu");
                        subChoice = "no";
                        break;
                    }
                }


            }while(subChoice == "yes");

        }//submenu ends 

        //Check Eligibility
        public static void CheckEligibility()
        {
            //Get the cutoff value as input 
            Console.Write("Enter the cutOff value : ");
            double cutOff ;
            bool tempCutOff = double.TryParse(Console.ReadLine(),out cutOff);
            while(!tempCutOff)
            {
                Console.WriteLine("Inavild input . Enter correct input");
                tempCutOff = double.TryParse(Console.ReadLine(),out cutOff);
            }
            // check eligible or not 
            if(currentLoggedInStudent.CheckEligibility(cutOff))
            {
                Console.WriteLine("Student is eligible.");
            }
            else
            {
                Console.WriteLine("Student is not eligible.");
            }
        }//checkeligibility ends

        //show details 
        public static void ShowDetails()
        {
            //Need to show current student details
            Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}|");
            Console.WriteLine();

        }// show details ends

        // Take admission
        public static void TakeAdmission()
        {
            //Need to show department details 
            DepartmentwiseSeatAvailability();
            //Ask the department ID from the user
            Console.Write("Select a department ID:");
            string departmentID=Console.ReadLine().ToUpper();
            //Check the iD is present or not 
            bool flag = true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=false;
                    // check the student is eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        // check the seat availability 
                        if(department.NumberOfSeats>0)
                        {
                            //check student already taken any admission
                            bool flag1 = true;
                            foreach(AdmissionDetails admission in admissionList )
                            {
                                int count=0;
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&&admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    flag1 = false;
                                   count++;  
                                }
                                if(count==0 && currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                                {
                                    flag1 = false;
                                    // create admission object
                                    AdmissionDetails admissionTake = new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                    //reduce seat count
                                    department.NumberOfSeats--;
                                    //add to the admission list
                                    admissionList.Add(admissionTake);
                                    //display admission successful message
                                    Console.WriteLine($"You have taken admission successfully . Admission ID:{admissionTake.AdmissionID}");
                                    break;
                                }
                                   
                            }
                            if(flag1)
                            {
                                
                                Console.WriteLine("You have already taken an admission");
                                
                            }
                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You are Not Eligible due to low CutOff");
                    } 
                    break; // to break unwated loops
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID is not present");
            }
            

        }// take admission ends

        // cancel admission
        public static void CancelAdmission()
        {
            //check the student is taken any admission and display it 
            bool flag = true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&&admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    flag = false;
                    //cancel the found admission
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
            // return the seat to department 
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            Console.WriteLine("Admission cancelled successfully");
                            break;
                        }
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("You have not a Admission to cancel.");
            }

        }// cancel admission ends

        // admission details 
        public static void AdmissionDetails()
        {
            if(admissionList.Count>0)
            {
                //need to show current logged in student's admission details
                Console.WriteLine("|Admission ID|Student ID|Department ID|Admission Date|Admission Status|");
                foreach (AdmissionDetails admission in admissionList)
                {
                    if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                    {
                        Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
                    }
                }
            }
            else
            {
                Console.WriteLine("");
            }
            
        }

        // Departmentwise seats availability Details
        public static void DepartmentwiseSeatAvailability()
        {
            if(departmentList.Count>0)
            {
                Console.WriteLine("|DepartmentID|Department Name|NumberOfSeats|");
                // Need to show all department details 
                foreach (DepartmentDetails department in departmentList)
                {
                    if (department.NumberOfSeats > 0)
                    {
                        Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartmentName,-15}|{department.NumberOfSeats,-13}|");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Department Details ");
            }
        }// end departmentwise seat avilability

        // Adding Default Data
        public static void AddDefaultData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2 = new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentsList.Add(student1);
            studentsList.Add(student2);

            //studentsList.AddRange(new List<StudentDetails>{student1,student2});
            //studentsList.Add( new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95))
            // In date time (year,month,date)
            DepartmentDetails department1 = new DepartmentDetails("EEE",29);
            DepartmentDetails department2 = new DepartmentDetails("CSE",29);
            DepartmentDetails department3 = new DepartmentDetails("MECH",30);
            DepartmentDetails department4 = new DepartmentDetails("ECE",30);

            departmentList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});
            AdmissionDetails admission1 = new AdmissionDetails("SF3001","DID101",new DateTime(2022,05,11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002","DID102",new DateTime(2022,05,12), AdmissionStatus.Admitted);
            //AdmissionDetails Admission1 =new AdmissionDetails(student.StudentID,) 
            admissionList.AddRange(new List<AdmissionDetails>(){admission1,admission2});  
        }// default data ends

        
    }
}