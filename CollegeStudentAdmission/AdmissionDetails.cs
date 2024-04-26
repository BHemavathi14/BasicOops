using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    /// <summary>
    /// This AdStatus is used to select a instance of <see cref="AdmissionDetails"/>
    /// </summary>
    public enum AdStatus {Selected,Booked,Cancelled}
    /// <summary>
    /// class Admission Details is used to select a instance of <see cref="AdmissionDetails"/>
    /// Refer documentation on <see href="www.Syncfusion.com" />
    /// </summary>
    public class AdmissionDetails
    {
        /// <summary>
        /// static field s_admissionId is 
        /// </summary>
        private static int s_admissionId=1000;
        public string AdmissionId { get;}
        public DateTime Date { get; set; }
        public AdStatus Status { get; set; }
        
        public string StudentId { get; set; }
        public string DepartmentId { get; set; }

        public AdmissionDetails()
        {
            Status=AdStatus.Selected;

        }
        public AdmissionDetails(DateTime date,AdStatus status,string sId,string dId)
        {
            s_admissionId++;
            AdmissionId ="AID"+s_admissionId;
            Date = date;
            Status=status;
            StudentId=sId;
            DepartmentId=dId;
        }
        public void AdCancel()
        {

        }
        
    }
    
}