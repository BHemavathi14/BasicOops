using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeDetails
{
    public enum AdmissionStatus{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        /*a.	AdmissionID – (Auto Increment ID - AID1001)
b.	StudentID
c.	DepartmentID
d.	AdmissionDate
e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
*/

// Field
// Static - Field
    private static int s_admissionID=1000;
    // properties
    public string AdmissionID { get; } // Readonly property
    public string StudentID { get;set;} 
    public string DepartmentID { get; set; } 
    public DateTime AdmissionDate { get; set; }
    public AdmissionStatus AdmissionStatus { get; set; }

    // constructor
    public AdmissionDetails(string studentID, string departmentId , DateTime admissionDate , AdmissionStatus admissionStatus)
    {
        // Auto incrementation
        s_admissionID++;
        AdmissionID ="AID"+s_admissionID;
        StudentID=studentID;
        DepartmentID = departmentId;
        AdmissionDate = admissionDate;
        AdmissionStatus = admissionStatus;

    }
    
    }
}