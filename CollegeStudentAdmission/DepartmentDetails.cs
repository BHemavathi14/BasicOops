using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    public class DepartmentDetails
    {
        private static int s_departmentId=100;
        public string DepartmentId { get;set; }
        public int Seats { get; set; }
        public string DepartmentName { get; set; }
        public string StudentId { get; set; }

        public DepartmentDetails(int seat, string departmentName,string stdId)
        {
            s_departmentId ++;
            DepartmentId ="DID"+s_departmentId;
            Seats = seat;
            DepartmentName =departmentName;
            StudentId = stdId;
        }
    }
}