using System;
using System.Collections.Generic;// list is defined in this list
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CollageAdmission
{
    public class StudentDetails
    {
        private string _studentName; // field are mostly in private because the information have to be safe
        // Field => store information
        // the attribute is in private so we can't access it directly soo we need properties to get and set the values
        //get return the value
        // set return the value

        // properties => display properties 
        private string _fatherName;
            public string StudentName
            {
                get
                     {return _studentName;}
                set
                    {_studentName=value;}

            }

        // autoproperty
        public DateTime dob{get;set;}
        public string FatherName { get; set; }

        // short cut to create property is prop tab
        // to create class vs code =>class => name 

        //default 
        public StudentDetails()
        {
            //initialize default values of every data type in the class
            StudentName="Enter your name:";
        }

        //parameter 
        public StudentDetails(string studentName,string fatherName)// must be camal case
        { 
            //Assign parameter values to the properties
            StudentName=studentName;
            FatherName = fatherName;
        }
        // destructor
        ~StudentDetails()
        {

        }
        // methods are used to explain behaviour
        // syntax public bool CheckEligibility ()

        public bool CheckEligibility(double 75)
        {
            double average =(double)(12+34+56)/3;

        }
    }
}