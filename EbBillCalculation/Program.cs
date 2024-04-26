using System;
using System.Collections.Generic;
using EbBillCalculation;
namespace EbBillcalculation;
public class Program
{
    public static void Main(string[] args)
    {
        List<EbBillCalc>newBill = new List<EbBillCalc>();

        bool flag = true;
        Console.WriteLine("*********Welcome to EB bill calculation************");
        while(flag)
        {
            Console.Write("\nEnter your choice 1.Registtration 2.Login 3.Exit : ");
            int userChoice = int.Parse(Console.ReadLine());
            switch(userChoice)
            {
                case 1:
                    {
                        Console.Write("\nEnter your Name : ");
                        string name = Console.ReadLine();
                        Console.Write("Enter your Mobile Number : ");
                        long mobileNumber = long.Parse(Console.ReadLine());
                        Console.Write("Enter your MailId : ");
                        string mail = Console.ReadLine();
                        Console.Write("Enter the units used : ");
                        int units = int.Parse(Console.ReadLine());

                        EbBillCalc bill = new EbBillCalc(name, mobileNumber, mail, units);
                        newBill.Add(bill);
                        Console.WriteLine($"\nYour Registration was Successful.\nyour meter id is {bill.MeterId}");
                        break;
                    }
                    case 2:
                    {
                        bool flag1 = true;
                        Console.Write("\nWelcome to Login portal");
                        Console.Write("Enter your meter id : ");
                        string meterId = Console.ReadLine();
                        while (flag1)
                        {
                            foreach(EbBillCalc bill in newBill)
                            {
                                if(meterId == bill.MeterId)
                                {
                                    Console.Write("\nchoose 1.Calculate Amount 2.Display User Details 3.Exit : ");
                                    int userChoose =int.Parse(Console.ReadLine());
                                    switch(userChoose)
                                    {
                                        case 1 :
                                        {
                                            int units =Calculation(bill.UnitsUsed);
                                            Console.WriteLine($"Your Eb bill amount is {units} ");
                                            break;
                                        }
                                        case 2:
                                        {
                                            Console.WriteLine("\n******Details*******");
                                            Console.WriteLine($"user Name:{bill.UserName}\nMeter ID:{bill.MeterId}\nPhone number:{bill.MobileNumber}\nMail Id:{bill.MailId}");
                                            break;
                                        }
                                        default:
                                        {
                                            flag1=false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid User Id");
                                }
                            }    
                        }
                        break;
                    }
                    default :
                    {
                        flag = false;
                        break;
                    }
            }

        }
    }
    static int Calculation(int unit)
    {
        return unit*5;
    }
}
