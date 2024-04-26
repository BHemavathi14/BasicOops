using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    /// <summary>
    /// DataType Gender is used to select a instance of <see cref="StudentDetails"/>Gender information 
    /// </summary>
    public enum Gender  {Select,Male,Female,Transgender}
    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails"/>
    /// Refer Documentation on <see href="www.syncfusion.com"/>
    /// </summary>
    public class StudentDetails
    {
        /// <summary>
        /// Static field s_studentId used to autoincrement studentID of the instance of <see cref="StudentDetails"/>
        /// </summary>
        private static int s_studentId = 3000;
        // Auto property
        // Type "prop" and press "tab" key 
        /// <summary>
        /// StudentName property used to hold StudentName of a instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <value></value>
        public string StudentName { get; set; }
        /// <summary>
        /// FatherName 
        /// </summary>
        /// <value></value>
        public string FatherName { get; set; }
        public DateTime  Dob { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }
        /// <summary>
        /// StudentID property used to hold a student's ID of instance of<see cref="Student Details"/>
        /// </summary>
        /// <value></value>
        public string StudentId { get;} // Read only property 
        /// <summary>
        /// Constructor student details used to initialize default values to its properties
        /// </summary> <summary>
        
        public StudentDetails()
        {
            StudentName="Enter your name";
            Gender = Gender.Select;
        }
        // parameterized Constructor
        /// <summary>
        /// Constructor StudentDetails used to initialize parameter values to its properties.
        /// </summary>
        /// <param name="name">name parameter used to asssign its value to associated property</param>
        /// <param name="fatherName">fatherName parameter used to asssign its value to associated property</param>
        /// <param name="dob">dob parameter used to asssign its value to associated property</param>
        /// <param name="gender">gender parameter used to asssign its value to associated property</param>
        /// <param name="physics">physics parameter used to asssign its value to associated property</param>
        /// <param name="chemistry">chemistry parameter used to asssign its value to associated property</param>
        /// <param name="maths">maths parameter used to asssign its value to associated property</param>
        public StudentDetails(string name,string fatherName, DateTime dob, Gender gender, int physics, int chemistry,int maths)
        {
            s_studentId ++;
            StudentId = "SF"+s_studentId;

            StudentName=name;
            FatherName = fatherName;
            Dob = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;


        }
        /// <summary>
        /// Method Average used to Check whether the instance of <see cref="StudentDetails"/>
        /// is eligible based on cut off
        /// </summary>
        /// <param name="physics"></param>
        /// <param name="chemistry"></param>
        /// <param name="maths"></param>
        /// <returns>Returns true if eligible , else false.</returns>
        public bool Average (int physics,int chemistry , int maths) 
        {
            double total = physics+chemistry+maths;
            double average = total/300;
            double percentage = average*100;

            if(percentage>=75)
            {
                return true;
            }
            return false;
        }
        public void StudentsDetails()
        {
            Console.WriteLine("\nStudent Details");
            Console.WriteLine($"Student Name: {StudentName}");
            Console.WriteLine($"Father Name: {FatherName}\n Dob: {Dob}\nGender: {Gender}\nPhysics: {Physics}\nChemistry: {Chemistry}\nMaths: {Maths}");
        }
    }


}