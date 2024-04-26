using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{

    public enum Gender { Select, Male, Female, Transgender }
    public enum WorkLocation { Select, Chennai, Us, Kenya }
        public class PayrollManagement
        {
            private static int s_employeeId = 1000;

            public string Name { get; set; }
            public string Role { get; set; }
            public string TeamName { get; set; }
            public string EmployeeId { get;set; }
            public DateTime DateofJoining { get; set; }
            public int WorkingDays { get; set; }
            public int NumOfLeave { get; set; }
            public Gender Gender { get; }
            public WorkLocation Location { get;}
           


            public PayrollManagement()
            {
                Gender = Gender.Select;
                Location = WorkLocation.Select;
            }
            public PayrollManagement(string name , string role ,Gender gender , string teamName , WorkLocation location , DateTime joinDate , int month, int leave)
            {
                s_employeeId++;
                EmployeeId ="SF"+s_employeeId;

                Name = name;
                Role = role;
                Gender =gender;
                TeamName = teamName;
                Location = location;
                DateofJoining = joinDate;
                WorkingDays = month;
                NumOfLeave = leave;
                

            }
        }
    
    
}