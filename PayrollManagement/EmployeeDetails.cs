using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagement
{
    public enum Gender {Selected, Male,Female,Transgender}
    public enum Branch{Selected,Eymard,Karuna,Madhura}
    public enum Team{Selected ,Network, Hardware, Developer, Facility }
    /// <summary>
    /// This class used to create a student details
    /// </summary> <summary>
    /// 
    /// </summary>
    public class EmployeeDetails
    {
        //Field
        //Static Field 
        private static int s_employeeId=3000;

        /*  •	EmployeeID – (Auto Generated- SF3000)
            •	Full Name
            •	DOB
            •	MobileNumber
            •	Gender
            •	Branch – (Enum – Eymard, Karuna, Madhura)
            •	Team – (Network, Hardware, Developer, Facility)*/

        // Properties
        public string EmployeeId { get; } // ReadOnly Property
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public long MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public Branch Branch { get; set; }
        public Team Team { get; set; }
       

        public EmployeeDetails()
        {
            Gender=Gender.Selected;
            Branch=Branch.Selected;
            Team=Team.Selected;
        }
        // 
        public EmployeeDetails(string fullName,DateTime dob , long mobileNumber , Gender gender,Branch branch,Team team)
        {
            // Auto incrementation
            s_employeeId++;
            EmployeeId="SF"+s_employeeId;
            FullName = fullName;
            DOB = dob;
            MobileNumber = mobileNumber;
            Gender = gender;
            Branch = branch;
            Team = team;
        }
        
    }
}