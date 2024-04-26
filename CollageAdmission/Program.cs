using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace CollageAdmission;
class Program
{
    public static void Main(string[] args)
    {
        List<StudentDetails> studentList = new List<StudentDetails>();//<within this we have to give datatype >
        
        StudentDetails student2=new StudentDetails();
        StudentDetails student3=new StudentDetails();

        // use do while loop 
        string option="";
        do{
            // ACtion to be repeated
            Console.WriteLine("im inside a loop");
        StudentDetails student1=new StudentDetails();//very very important this line must be in loop otherwise new data not created and gives you error 
        Console.WriteLine("Enter your name:");
        student1.StudentName=Console.ReadLine();
         Console.WriteLine("Enter your Father name:");// 
        student1.FatherName=Console.ReadLine();

        studentList.Add(student1);

            Console.WriteLine("Do you want to continue:");
            option=Console.ReadLine();
            
            //loop breaker
        }while(option=="yes");

        

         Console.WriteLine("Enter your name:");
        student2.StudentName=Console.ReadLine();
         Console.WriteLine("Enter your Father name:");
        student2.FatherName=Console.ReadLine();
        studentList.Add(student2);


        Console.WriteLine("Enter your name:");
        student3.StudentName=Console.ReadLine();
         Console.WriteLine("Enter your Father name:");
        student3.FatherName=Console.ReadLine();
        studentList.Add(student3);


        // here we are give variables , so the variables can use anyone 


        //studentList.Add(student1);//foreach is a exposing loop
        foreach(StudentDetails student in studentList)
        {
            Console.WriteLine(student.FatherName);

        }







        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("Enteer your father name:");
        string fatherName = Console.ReadLine();
        Console.WriteLine("Enter your dob:");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

        // student2

         Console.WriteLine("Enter your name");
        string name1 = Console.ReadLine();
        Console.WriteLine("Enteer your father name:");
        string fatherName1 = Console.ReadLine();
        Console.WriteLine("Enter your dob:");
        DateTime dob1 = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

        // student 3

         Console.WriteLine("Enter your name");
        string name2 = Console.ReadLine();
        Console.WriteLine("Enteer your father name:");
        string fatherName2 = Console.ReadLine();
        Console.WriteLine("Enter your dob:");
        DateTime dob2 = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

        //for the usage of 


    }
}