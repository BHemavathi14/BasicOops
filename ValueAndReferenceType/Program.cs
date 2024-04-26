using System;
namespace ValueAndReferenceType;
class Program
{
    public  static void Main(string[] args)
    {
        /*int num1 =10;
        Console.WriteLine(num1);
        int num2 =num1;
        Console.WriteLine(num2);
        num1 = 20;
        Console.WriteLine(num2);

        Student student =new Student();
        student.Name1= "hemavathi";

        Console.WriteLine(student.Name1);

        Student sample2 = student ;
        Console.WriteLine(student.Name1);
        student.Name1 ="bhee";

        Console.WriteLine(student.Name1);
        Console.WriteLine(sample2.Name1);

        string str = Console.ReadLine();
        char[] array = str.ToCharArray();
        string empStr = "";
        for (int i = array.Length-1; i >= 0; i--)
        {
            string s = array[i].ToString().ToUpper();
            empStr += s;

        }
        Console.WriteLine(empStr);*/
                Console.Write("enter row:");
                int n = int.Parse(Console.ReadLine());
                int i,j,k;
                
                for(i=1;i<=n;i++)
                {
                    string s ="";
                    for(k=1;k<=n-i;k++)
                    {
                        Console.Write(" ");
                    }
                    for(j=1;j<=i;j++)
                    {
                        s +="* ";
                        
                    }
                    Console.Write(s.TrimEnd());
                    Console.WriteLine(" ");
                }
                for(i=1;i<=n-1;i++)
                {
                    string d="";
                    for(k=1;k<=i;k++)
                    {
                        Console.Write(" ");
                    }
                    for(j=n-i;j>=1;j--)
                    {
                        d+="* ";
                    }
                    Console.Write(d.TrimEnd());
                    Console.WriteLine();
                }
            }        
}