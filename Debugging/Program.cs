using System;
using System.Linq;
namespace Debugging;
class Program
{
   public static void Main(string[] args)
            {
                /*DateTime dob = new DateTime();
               
                */
                TimeOnly time  = new TimeOnly(12,4,5);
                TimeOnly time1 = TimeOnly.Parse(Console.ReadLine());
                Console.WriteLine(time1);


                
            }
                       
}

