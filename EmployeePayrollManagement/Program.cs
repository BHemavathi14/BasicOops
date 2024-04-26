using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace EmployeePayrollManagement;
class Program
{
    public static void Main(string[] args)
    {
        int userChoice;
        bool flag=true;
        List<PayrollManagement> employeeList = new List<PayrollManagement>();
        Console.WriteLine("\n****************WELCOME******************");
        do
        {
            Console.Write("Select 1.Registration 2.Login 3.Exit : ");
            userChoice = int.Parse(Console.ReadLine());
            if(userChoice == 1)
            {
                // role,worklocation,gender,team name , date of joining , no of working days leave taken 
                Console.Write("Enter your name : ");
                string name = Console.ReadLine();
                Console.Write("Enter your role : ");
                string role = Console.ReadLine();
                Console.Write("Enter your gender : ");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
                Console.Write("Enter your team name : ");
                string teamName = Console.ReadLine();
                Console.Write("Enter your WorkLocation : ");
                WorkLocation location = Enum.Parse<WorkLocation>(Console.ReadLine(),true);
                Console.Write("Enter your Date of Joining : ");
                DateTime joinDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                Console.Write("Enter the days in month : ");
                int month = int.Parse(Console.ReadLine());
                Console.Write("Enter Number of leave taken : ");
                int leave = int.Parse(Console.ReadLine());
                PayrollManagement user1 = new PayrollManagement(name,role,gender,teamName,location,joinDate,month,leave);
                employeeList.Add(user1);
                Console.WriteLine($"\nYour Rgistration was successful.Your Registration id is {user1.EmployeeId}");

            }
            else if(userChoice==2)
            {
                bool flag1=true;
                Console.Write("\nEnter your Login id : ");
                string loginId = Console.ReadLine();


                foreach(PayrollManagement user in employeeList)
                {
                    if(loginId ==user.EmployeeId)
                    {
                        Console.WriteLine("\nLogin successful........");
                        do
                        {
                            Console.WriteLine("Please select the option given below..");
                            Console.Write("Enter 1.Salary Details 2.Employee Details 3.Exit : ");
                            int userSelect = int.Parse(Console.ReadLine());
                            if(userSelect==1)
                            {
                                int salary = (user.WorkingDays-user.NumOfLeave)*500;
                                Console.WriteLine($"Your salary for this month is {salary}");
                            }
                            else if (userSelect==2)
                            {
                                Console.WriteLine("\n******************Employee Details*******************");
                                Console.WriteLine($"Name:{user.Name}\nJob Role:{user.Role}\nTeam Name:{user.TeamName}");
                                Console.WriteLine($"Employee Id:{user.EmployeeId}\nDate of Joining:{user.DateofJoining}");
                                Console.WriteLine($"Company Location:{user.Location}\nWorking Dats:{user.WorkingDays}\nNumber of Leave Taken:{user.NumOfLeave}");
                            }
                            else
                            {
                                flag1=false;
                            }

                        }while(flag1);    
                    }
                }
            }
            else
            {
                flag=false;
            }
        }while(flag);
        
    }
}
