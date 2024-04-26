using System;
using CollegeDetails;

namespace Application;//File Scoped name space
public class Program
{
    public static void Main(string[] args)
    {
        // Default data calling
        Operations.AddDefaultData();
        // Calling Main Menu 
        Operations.MainMenu();
        
    }
}
