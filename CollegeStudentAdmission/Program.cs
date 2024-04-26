using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
namespace CollegeStudentAdmission;
class Program
{
    static  List<StudentDetails> studentList = new List<StudentDetails>();
    static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
    static List<AdmissionDetails> adList = new List<AdmissionDetails>();
    public static void Main(string[] args)
    {
       
        
        Console.WriteLine("Welcome to Syncfusion College of Engineering and Technology");
        Console.WriteLine("***********************************************************");
        bool flag=true;
        do
        {
            Console.WriteLine("\n1.Student Registration \n2.Student Login \n3.Department wise seat availability\n4.Exit");
            Console.Write("Select : ");
            int userChoice = int.Parse(Console.ReadLine());

            if(userChoice==1)
            {
                Console.Write("Enter your Name : ");
                string name = Console.ReadLine();
                Console.Write("Enter your Father Name : ");
                string fatherName = Console.ReadLine();
                Console.Write("Enter your DOB in this format dd/MM/yyyy : ");
                DateTime Dob = new DateTime();
                bool temp = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out Dob);
                Console.Write("Enter your Gender ( Male Female Transgender ) : ");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
                Console.Write("Enter Your Physics Mark : ");
                int physics = int.Parse(Console.ReadLine());
                Console.Write("Enter Your Chemistry Mark : ");
                int chemistry = int.Parse(Console.ReadLine());
                Console.Write("Enter Your Maths Mark : ");
                int maths = int.Parse(Console.ReadLine());
                StudentDetails student = new StudentDetails(name, fatherName, dob, gender, physics, chemistry, maths);
                studentList.Add(student);
                Console.WriteLine($"\nStudent Registered Successfully and StudentID is {student.StudentId}\n");
            }
            else if(userChoice==2)
            {
                Console.WriteLine("\nWelcome to Login Portal");
                Console.Write("Enter your Login id:");
                string LoginId = Console.ReadLine();
                bool check=true;
                foreach(StudentDetails student in studentList)
                {
                    if(LoginId==student.StudentId)
                    {
                        check=false;
                        Console.WriteLine("\nLogin successfully.....");
                        bool flag3=true;
                        do
                        {
                            Console.WriteLine("\na.  Check Eligibility\nb.  Show Details\nc.  Take Admission\nd.  Cancel Admission\ne.  Show Admission Details\nf.  Exit\n");
                            Console.Write("Select: ");
                            char choice = char.Parse(Console.ReadLine());
                            switch(choice)
                            {
                                case 'a':
                                {
                                    bool eligibility=student.Average(student.Physics,student.Chemistry,student.Maths);
                                    if(eligibility)
                                    {
                                        Console.WriteLine("\nStudent is eligible ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nStudent is not eligible");
                                    }
                                    break;
                                }
                                  case 'b':
                                {
                                    student.StudentsDetails();
                                    break;
                                }
                                  case 'c':
                                {
                                        Console.WriteLine("Want to add Department Details(yes/no)");
                                        string input =Console.ReadLine().ToLower();
                                        if(input=="yes")
                                        {
                                            Console.WriteLine("\n Adding Department Details");
                                            Console.Write("How many departments are you going to add:");
                                            int n = int.Parse(Console.ReadLine());
                                            for (int i = 0; i < n; i++)
                                            {
                                                Console.Write("Enter Department Name: ");
                                                string name = Console.ReadLine();
                                                Console.Write("Enter seats availability:");
                                                int seats = int.Parse(Console.ReadLine());
                                                DepartmentDetails department = new DepartmentDetails(seats, name, student.StudentId);
                                                departmentList.Add(department);
                                            }

                                        }
                                        
                                        deptDetails();
                                        Console.Write("\nchoose department Id: ");
                                        string deptId =Console.ReadLine();
                                        foreach(DepartmentDetails dept in departmentList)
                                        {
                                            if(deptId==dept.DepartmentId)
                                                {
                                                    bool eligibility = student.Average(student.Physics, student.Chemistry, student.Maths);
                                                    if (eligibility)
                                                    {
                                                        Console.WriteLine("Student is eligible ");
                                                        if(dept.Seats>0)
                                                        {
                                                            bool flag1=true;
                                                            foreach(AdmissionDetails ad in adList)
                                                            {
                                                                if(student.StudentId==ad.StudentId)
                                                                {
                                                                    flag1=false;
                                                                    Console.WriteLine($"Admission already Taken.Your Admission id is {ad.AdmissionId}");
                                                                }
                                                            }
                                                            if(flag1)
                                                            {
                                                                Console.Write("\nEnter the Date:");
                                                                DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                                                                Console.WriteLine("Select the Status(Booked/Cancelled):");
                                                                AdStatus status = Enum.Parse<AdStatus>(Console.ReadLine(),true);
                                                                dept.Seats--;
                                                                AdmissionDetails admission = new AdmissionDetails(date,status,student.StudentId,dept.DepartmentId);
                                                                adList.Add(admission);
                                                                Console.WriteLine($"Admission took successfully. Your Admision id is {admission.AdmissionId}");

                                                            }
                                                            
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nStudent is not eligible");
                                                    }

                                                }
                                    }
                                    break;
                                }
                                  case 'd':
                                {
                                    Console.WriteLine($"\nStudent Admission Details");
                                    foreach(AdmissionDetails ad in adList)
                                    {
                                        if(LoginId==ad.StudentId)
                                        {
                                                Console.WriteLine($"Department id: {ad.DepartmentId}");
                                                Console.WriteLine($"Admission Id : {ad.AdmissionId}");
                                                Console.WriteLine($"Your Status : {ad.Status}");
                                                Console.WriteLine($"Date : {ad.Date}");
                                                foreach(DepartmentDetails dept in departmentList)
                                                {
                                                    if(ad.DepartmentId==dept.DepartmentId)
                                                    {
                                                        dept.Seats +=1;
                                                        Console.WriteLine("Select the Status(Booked/Cancelled):");
                                                        AdStatus status = Enum.Parse<AdStatus>(Console.ReadLine(),true);
                                                        ad.Status = status;
                                                    }
                                                }
                                                Console.WriteLine($"Admission cancelled successfully");

                                            }
                                    }
                                   
                                    break;
                                }
                                  case 'e':
                                {
                                    AdmissiosDet();
                                    break;
                                }
                                default:
                                {
                                    flag3=false;
                                    break;
                                }
                            }


                        }while(flag3);
                    }    
                }
                if(check)
                {
                    Console.Write("\nInvalid Student Id\n");
                }
            }
            else if(userChoice==3)
            {
                deptDetails();
            }
            else
            {
                flag=false;
            }

        }while(flag);
        
    }
    
    public static void deptDetails()
    {
        Console.WriteLine("Department Details");
        Console.Write("Department Id\tDepartment Name  \tSeats");
        Console.WriteLine();
        foreach(DepartmentDetails dept in departmentList)
        {
            Console.Write($"{dept.DepartmentId}\t\t\t{dept.DepartmentName}\t\t{dept.Seats}");
            Console.WriteLine();
        }
    }

    public static void AdmissiosDet()
    {
        Console.Write("Admission Id  \t Department Id \t Student Id \t Admission Date \t Ad Status");
        Console.WriteLine();
        foreach(AdmissionDetails details in adList)
        {
            Console.WriteLine($"{details.AdmissionId}      \t{details.DepartmentId}      \t{details.StudentId}     \t{details.Date.ToString("dd/MM/yyyy")}        \t{details.Status}");
            Console.WriteLine();
        }

    }
}
