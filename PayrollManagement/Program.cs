
using System;
namespace PayrollManagement;
class Program
{
    public static void Main(string[] args)
    {
        // calling default values
        Operations.AddDefaultValues();
        // calling main menu
        Operations.MainMenu();
    }

}