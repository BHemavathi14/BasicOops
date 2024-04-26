using System;
using System.Collections.Generic;
namespace BankAccountOpening;
class Program
{
    public static void Main(string[] args)
    {
        List<AccountDetails>accountList = new List<AccountDetails>();
        int userChoice;
        bool flag = true;
        //AccountDetails account2 = new AccountDetails();
      
        
        do
        {
            Console.WriteLine("Welcome to the HDfc Bank Account");
            Console.WriteLine("Please selecet 1.Regiastration 2.Login 3.exit");
            userChoice = int.Parse(Console.ReadLine());
            if(userChoice==1)
            {
                Console.Write("Enter your Name : ");
                string name = Console.ReadLine();
                Console.Write("Enter your DOB : ");
                DateTime dob= DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                Console.Write("Enter your Gender ( Male Female Transgender ) : ");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
                Console.Write("Enter your mobile number : ");
                long mobileNumber = long.Parse(Console.ReadLine());
                Console.Write("Enter your MailId : ");
                string mail = Console.ReadLine();

                AccountDetails account1 = new AccountDetails(name,dob,gender,mobileNumber,mail);
                accountList.Add(account1);

                Console.WriteLine($"\nYour Registration was succesful your customer id is {account1.CustomerId}\n");
                
            }
            else if (userChoice==2)
            {
                Console.Write("Enter your login id :");
                string loginId = Console.ReadLine();
                foreach(AccountDetails account in accountList)
                { 
                    bool flag1 = true;
                    if(loginId == account.CustomerId)
                    {
                        Console.WriteLine("\nLogin was successful");
                        do
                        {
                            
                            Console.WriteLine("1.Deposit 2.Withdraw 3.Balance check 4.Exit");
                            int userSelect =int.Parse(Console.ReadLine());
                            if(userSelect == 1)
                            {
                                Console.Write("\nEnter the Amount to Deposit :");
                                account.Balance += int.Parse(Console.ReadLine());
                                Console.WriteLine("Successfully deposited.");
                            }
                            else if (userSelect ==2)
                            {
                                if(account.Balance>0)
                                {
                                    Console.Write("\nEnter the Amount to withdraw : ");
                                    account.Balance -= int.Parse(Console.ReadLine());
                                    Console.WriteLine("Here is your cash Enjoy....");
                                }
                                else
                                {
                                    Console.WriteLine("\nYour account balance is too low");
                                }
                               
                            }
                            else if(userSelect == 3)
                            {
                                Console.WriteLine($"\nYour Account Balance is {account.Balance}");
                            }
                            else
                            {
                                flag1=false;
                            }

                        }while(flag1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid User Id");
                    }
                     
                }
            }
            else
            {
                flag=false;
            }


        }while(flag);
        
    }
}

