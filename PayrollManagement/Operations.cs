using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PayrollManagement
{
    public static class Operations
    {
        // create  static List
        static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
        static List<AttendanceDetails> attendanceList = new List<AttendanceDetails>();
        // create object for employee details class for further use
        static EmployeeDetails currentLoggedInEmployee;
        static string line ="--------------------------------------------------------------------";
 
        public static void MainMenu()
        {
            Console.WriteLine("Payroll Management System for Syncfusion Software Private Limited");
            Console.WriteLine(line);
            // breaker statement
            bool flag = true;
            do
            {
            // need to show main menu details 
            Console.WriteLine("-------------MAIN MENU-----------------");
            Console.Write("1.Employee Registration\n2.Employee Login\n3.Exit\n");
            //getting user input
            Console.Write("Select your choice: ");
            int mainChoice ;
            bool tempMainOption = int.TryParse(Console.ReadLine(),out mainChoice);
            while(!tempMainOption)
            {
                Console.WriteLine("Invalid Input");
                Console.Write("Select your choice: ");
                tempMainOption = int.TryParse(Console.ReadLine(),out mainChoice);
            }
            // structure the flow 
            switch(mainChoice)
            {
                // control the flow 
                case 1 :
                {
                    Console.WriteLine("***********Employee Registration**********");
                    EmployeeRegistration();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("************Employee Login**************");
                    EmployeeLogin();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("************Exit successfully*************");
                    flag = false;
                    break;
                }
            }

            }while(flag);
        }// main menu ends
        // Employee registration method
        public static void EmployeeRegistration()
        {
            // need to get employee details 
            Console.Write("Enter your Full Name : ");
            string fullName = Console.ReadLine();

            // dob
            DateTime dob ;
            Console.Write("Enter your Gender : ");
            bool tempDateTime = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            while (!tempDateTime)
            {
               Console.WriteLine("Invalid Input. Enter a valid DateTime");
                tempDateTime = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            }
            Console.Write("Enter your Mobile NUmber : ");
            long mobileNumber;
            bool tempMobileNumber = long.TryParse(Console.ReadLine(),out mobileNumber);
            while(!tempMobileNumber)
            {
                Console.WriteLine("Invalid Input. Enter a valid Mobile Number");
                tempMobileNumber = long.TryParse(Console.ReadLine(),out mobileNumber);
            }
            Console.Write("Enter your Gender (Male/Female) : ");
            Gender gender;
            bool tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            while(!tempGender)
            {
                Console.WriteLine("Invalid Input. Enter a valid Gender");
                tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            }
            Branch branch;
            Console.Write("Enter your Branch (Eymard, Karuna, Madhura) : ");
            bool tempBranch = Enum.TryParse(Console.ReadLine(),true,out branch);
            while(!tempBranch)
            {
                Console.WriteLine("Invalid Input. Enter a valid Branch");
                tempBranch = Enum.TryParse(Console.ReadLine(),true,out branch);
            }
            Team team ;
            Console.Write("Enter your Team (Network, Hardware, Developer, Facility) : ");
            bool tempTeam = Enum.TryParse(Console.ReadLine(),true,out team);
            while(!tempTeam)
            {
                Console.WriteLine("Invalid Input. Enter a valid team.");
                tempTeam = Enum.TryParse(Console.ReadLine(),true,out team);
            }
            // create object for employee details
            EmployeeDetails employee = new EmployeeDetails(fullName,dob,mobileNumber,gender,branch,team);
            // add it to employee list
            employeeList.Add(employee);
            // user message 
            Console.WriteLine($"Employee added successfully your id is: {employee.EmployeeId}\n");  
            Console.WriteLine(line);
        }// reg ends
        //employee login method
        public static void EmployeeLogin()
        {
            Console.Write("Enter your Employee Id : ");
            string employeeId = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach(EmployeeDetails employee in employeeList)
            {
                if(employeeId.Equals(employee.EmployeeId))
                {
                    currentLoggedInEmployee=employee;
                    flag = false;
                    SubMenu();                    
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid user id or ");
            }

        }// user login ends
        
        public static void SubMenu()
        {
            bool flag =true;
            do
            {
                Console.WriteLine("--------------------Sub Menu--------------------");
                Console.WriteLine("1.Add Attendance\n2.Display Details\n3.Calculate Salary\n4.Exit");
                Console.Write("Select Option : ");
                int subOption;
                bool tempSubOption = int.TryParse(Console.ReadLine(),out subOption);
                while(!tempSubOption)
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Select Option : ");
                    tempSubOption = int.TryParse(Console.ReadLine(),out subOption);
                }
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("**********Add Attendance**************");
                        AddAttendance();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**************Display Details*************");
                        DisplayDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("***************Calculate Salary*******************");
                        CalculateSalary();
                        break;
                    }
                    case 4:
                    {
                        flag = false;
                        break;
                    }
                }

            }while(flag);
        }// sun menu ends 

public static void AddAttendance()
{
    // Ask he wants to check in 
    // Ask Date 
    Console.WriteLine("Do you want to check-in (yes/no) : ");
    string userChoice = Console.ReadLine().ToLower();
    if(userChoice =="yes")
    {
    Console.Write("Enter the date in this format MM/dd/yyyy : ");
    DateTime date;
    bool tempDate = DateTime.TryParseExact(Console.ReadLine(),"M/d/yyyy",null,System.Globalization.DateTimeStyles.None,out date);
    while(!tempDate)
    {
        Console.WriteLine("Invalid Input.Enter correct Input");
        tempDate = DateTime.TryParseExact(Console.ReadLine(),"M/d/yyyy",null,System.Globalization.DateTimeStyles.None,out date);
    }
    Console.WriteLine("Enter the Time of check-in in 24 hour format (HH:mm) : ");
    TimeOnly checkIn;
    bool tempCheckIn= TimeOnly.TryParseExact(Console.ReadLine(),"H:mm",null,System.Globalization.DateTimeStyles.None,out checkIn);
    while(!tempCheckIn)
    {
        Console.WriteLine("Invalid Input.Enter correct Input");
        tempCheckIn= TimeOnly.TryParseExact(Console.ReadLine(),"H:mm",null,System.Globalization.DateTimeStyles.None,out checkIn);
    }
    // Ask he wants to check out 
    Console.WriteLine("Do you want to check-out (yes/no) :");
    string userChoice1= Console.ReadLine().ToLower();
    TimeOnly checkOut = new TimeOnly(0,0) ;
    if(userChoice1 == "yes")
    {
        Console.WriteLine("Enter the Time of check-in in 24 hour format (HH:mm) : ");
        bool tempCheckOut= TimeOnly.TryParseExact(Console.ReadLine(),"H:mm",null,System.Globalization.DateTimeStyles.None,out checkOut);
        while(!tempCheckOut)
        {
            Console.WriteLine("Invalid Input.Enter correct Input");
            tempCheckOut= TimeOnly.TryParseExact(Console.ReadLine(),"H:mm",null,System.Globalization.DateTimeStyles.None,out checkOut);
        }
        // calculate woking hours , if > 8 hours  , take it as 8 hour
        TimeSpan workedHours = checkOut-checkIn; 
        int workingHour =(int) workedHours.TotalHours;
        if(workingHour>8)
        {
            workingHour=8;
        }
          //create object add to list 
        AttendanceDetails attendance = new AttendanceDetails(currentLoggedInEmployee.EmployeeId,date,checkIn,checkOut,workingHour);
        attendanceList.Add(attendance);
         //  message  to the user 
        Console.WriteLine($"Check-in and Checkout Successful and today you have worked {workingHour} Hours");
    }
    else
    {
        Console.WriteLine("Invalid Input");
    }
    
    }
    else
    {
        Console.WriteLine("Invalid Input");
    }
}// end of Addattendance

public static void DisplayDetails()
{
     
    foreach(EmployeeDetails employee in employeeList)
    {
       
        if(currentLoggedInEmployee.EmployeeId == employee.EmployeeId)
        {
            Console.WriteLine("|Employee Id |Full name |DOB |Mobile Number |Gender | Branch | Team");
            Console.WriteLine($"|{currentLoggedInEmployee.EmployeeId}|{currentLoggedInEmployee.FullName}|{currentLoggedInEmployee.DOB}|{currentLoggedInEmployee.MobileNumber}|{currentLoggedInEmployee.Gender}|{currentLoggedInEmployee.Branch}|{currentLoggedInEmployee.Team}\n{line}");

        }
    }
    

}
public static void CalculateSalary()
{
    bool flag=true;
    Console.WriteLine("|Attendance Id |Employee ID |Date |Check-In |Check-Out |Hours Worked|");
    // traversing attendance details of current month
    foreach(AttendanceDetails attendance in attendanceList)
    {
        if(currentLoggedInEmployee.EmployeeId==attendance.EmployeeID && attendance.Date.Month == DateTime.Now.Month)
        { 
            flag=false;
            Console.WriteLine($"{attendance.AttendanceID}|{attendance.EmployeeID}|{attendance.Date.ToShortTimeString}|{attendance.CheckInTime}|{attendance.CheckOutTime}|{attendance.HoursWorked}");

        }
    }
    if(flag)
    {
        Console.WriteLine("You have no history in the current month ");
    }
     bool flag1 = true;
     int totalSalary =0;
    foreach(AttendanceDetails attendance in attendanceList)
    {  // calculating employee salary of current montth and working hour must be greater than =7
        if(currentLoggedInEmployee.EmployeeId==attendance.EmployeeID && attendance.HoursWorked>=7&& attendance.Date.Month == DateTime.Now.Month)
        { 
            flag1 = false;
           totalSalary +=500;
        }
    }
    if(flag1)
    {
        Console.WriteLine("May be you worked less than 7 hours");
    }
    Console.WriteLine($"Your Salary is {totalSalary}\n{line}");

}

        public static void AddDefaultValues()
        {
            EmployeeDetails employee1 = new EmployeeDetails("Ravi",new DateTime(1999/11/1),9958858888,Gender.Male,Branch.Eymard,Team.Developer);
            employeeList.Add(employee1);
            AttendanceDetails attendance = new AttendanceDetails("SF3001",new DateTime(2022,05,15),new TimeOnly(9,0),new TimeOnly(6,0),8);
            AttendanceDetails attendance1 = new AttendanceDetails("SF3002",new DateTime(2023,05,15),new TimeOnly(9,10),new TimeOnly(6,10),8);
            attendanceList.Add(attendance);
            attendanceList.Add(attendance1);
          
        }


    }
}