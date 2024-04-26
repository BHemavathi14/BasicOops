using System;
using System.IO;

namespace StudentAdmission
{
    public static  class FileHandling
    {
        // create a folder 
        //the folder name and project folder name must be same 
        // whenever you create file close it 
        public static void Create()
        {
            if(!Directory.Exists("StudentAdmission"))
            {
                Console.WriteLine("Creating folder.....");
                Directory.CreateDirectory("StudentAdmission");
            }

            // file for student info 
            if(!File.Exists("StudentAdmission/StudentInfo.csv"))
            {
                Console.WriteLine("Creating file....");
                File.Create("StudentAdmission/StudentInfo.csv").Close();
            }
            // file to create dept info 
            if(!File.Exists("StudentAdmission/DepartmentInfo.csv"))
            {
                Console.WriteLine("Creating file....");
                File.Create("StudentAdmission/DepartmentInfo.csv").Close();

            }
            // file to create admission info 
            if (!File.Exists("StudentAdmission/AdmissionInfo.csv"))
            {
                Console.WriteLine("Creating file....");
                File.Create("StudentAdmission/AdmissionInfo.csv").Close();
            }
        }// end of create 

        // method for write the data to csv files
        public static void WriteToCSV()
        {
            // write data student Lidt data to csv
            // create array to store data 
            string [] student = new string[Operations.studentsList.Count];
            for(int i=0;i<Operations.studentsList.Count;i++)
            {
                student[i]=Operations.studentsList[i].StudentID+","+Operations.studentsList[i].StudentName+","+Operations.studentsList[i].FatherName+","+Operations.studentsList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentsList[i].Gender+","+Operations.studentsList[i].PhysicsMark+","+Operations.studentsList[i].ChemistryMark+","+Operations.studentsList[i].PhysicsMark;
            } 
            File.WriteAllLines("StudentAdmission/StudentInfo.csv",student);
            
            // Department info 
            string [] admission = new string [Operations.admissionList.Count];
            for(int i=0;i<Operations.admissionList.Count;i++)
            {
                admission[i] =Operations.admissionList[i].AdmissionID+","+Operations.admissionList[i].StudentID+","+Operations.admissionList[i].DepartmentID+","+Operations.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("StudentAdmission/AdmissionInfo.csv",admission);

            // Admisssion info 
            string [] department = new string[Operations.departmentList.Count];
            for(int i=0;i<Operations.departmentList.Count;i++)
            {
                department[i]=Operations.departmentList[i].DepartmentID+","+Operations.departmentList[i].DepartmentName+","+Operations.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("StudentAdmission/DepartmentInfo.csv",department);
        }// end of writeToCsv

        public static void ReadFromCSV()
        {
            string []  students = File.ReadAllLines("StudentAdmission/StudentInfo.csv");
            foreach(string student in students )
            {
                StudentDetails student1 = new StudentDetails(student);
                Operations.studentsList.Add(student1);
            }
            
            // read from departmentcsv file and add it to the list 
            string[] departments = File.ReadAllLines("StudentAdmission/DepartmentInfo.csv");
            foreach(string department in departments)
            {
                DepartmentDetails department1 = new DepartmentDetails(department);
                Operations.departmentList.Add(department1);
            }
            string[] admissions = File.ReadAllLines("StudentAdmission/AdmissionInfo.csv");
            foreach(string admission in admissions )
            {
                AdmissionDetails admission1 = new AdmissionDetails(admission);
                Operations.admissionList.Add(admission1);
            }
            
        }
        
    }
}