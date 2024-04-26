using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        /*a.	DepartmentID – (AutoIncrement - DID101)
            b.	DepartmentName
            c.	NumberOfSeats
*/

        // Field 
        // private - static Field
        private static int s_departmentID= 100;
        // property
        public string DepartmentID { get; } // Read-only Property
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        // Constructor 
        public DepartmentDetails(string departmentName, int numberOfSeats)
        {
            //Auto Incrementation
            s_departmentID++;
            DepartmentID = "DID"+s_departmentID;
            // Value Assigning
            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }
        public DepartmentDetails(string department)
        {
            string[] values = department.Split(",");
            DepartmentID = values[0];
            s_departmentID=int.Parse(values[0].Remove(0,3));
            // Value Assigning
            DepartmentName = values[1];
            NumberOfSeats = int.Parse(values[2]);
        }
    }
}