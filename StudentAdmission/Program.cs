using System;
using StudentAdmission;
namespace StudentAdmissiion;//File Scoped name space
public class Program
{
    public static void Main(string[] args)
    {
        // calling function to create files 
        FileHandling.Create();
        // Default data calling
        //Operations.AddDefaultData();
        // Calling Main Menu 
        FileHandling.ReadFromCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();
        
    }
}
