using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagement
{
   
    public class AttendanceDetails
    {
        /*
        •	AttendanceID – AID1001
        •	EmployeeID
        •	Date
        •	CheckInTime
        •	CheckOutTime
        •	HoursWorked
        */

        //Field 
        //Static Field
        private static int s_attendanceID = 1000;
        // Properties
        public string AttendanceID { get;} // ReadOnly property
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public int HoursWorked { get; set; }

        public AttendanceDetails(string employeeID,DateTime date,TimeOnly checkIn , TimeOnly checkOut, int hoursWorked)
        {
            // Auto incrementation
            s_attendanceID++;
            AttendanceID = "AID"+s_attendanceID;
            EmployeeID = employeeID;
            Date = date;
            CheckInTime = checkIn;
            CheckOutTime = checkOut;
            HoursWorked = hoursWorked;

        }
        
    }
}