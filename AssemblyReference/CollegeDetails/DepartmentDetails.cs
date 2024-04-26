using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CollegeDetails
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
    }
}