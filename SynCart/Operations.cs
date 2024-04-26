using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public static partial class Operations
    {
        static List<CustomerDetails> customersList = new List<CustomerDetails>();
        static List<OrderDetails> orderList =new List<OrderDetails>();
        static List<ProductDetails> productList = new List<ProductDetails>();

        static CustomerDetails currentLoggedInUser;
        static string line="-------------------------------------------------------------";
        public static void MainMenu()
          {
            Console.WriteLine($"{line}\nOnline Food Delivery Application \n{line}");
            string mainChoice="yes";
            do
            {
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<< MAIN MENU >>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("1.Customer Registration\n2.Login\n3.Exit");
                Console.Write("Select : ");
                int mainOption = int.Parse(Console.ReadLine());
                switch(mainOption)
                {
                    case 1:
                    {
                        Console.WriteLine("**************Customer Registration************");
                        CustomerRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*************** Login ****************");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        mainChoice="no";
                        Console.WriteLine($"Exited Successfully\n{line}");
                        break;
                    }

                }

            }while(mainChoice=="yes");
          }// end of main menu 

          public static void CustomerRegistration()
          {

          }
          public static void Login()
          {
                Console.Write("Enter your customerID number : ");
            string customerID = Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(CustomerDetails customer in customersList)
            {
                // check id is valid or not 
                if(customerID==customer.CustomerID)
                {
                    flag=false;
                    currentLoggedInUser=customer;
                    Console.WriteLine("Login successfully.......");
                    SubMenu();
                }
            // create sub menu 
            }
            if(flag)
            {
                Console.WriteLine($"The Customer ID you entered is not a valid one or Not Registered \n{line}");
            }
          }// end of login 

          public static void SubMenu()
        {
            // display submenu details 
            //looping the structure 
            string subChoice = "yes";
            do
            {
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<< SUB MENU >>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("1.Purchase\n2.Order History\n3.Cancel Order\n4.Wallet Balance\n5.Wallet Recharge\n6.Exit");
                Console.Write("Select : ");
                int subOption = int.Parse(Console.ReadLine()); 
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("----------Purchase-----------");
                        Purcahse();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("---------------Order History----------------");
                        OrderHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("-------------Cancel Order------------------");
                       CancelOrder();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("-----------------Wallet Balance-----------------");
                       WalletBalance();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("-----------------Wallet Recharge -----------------");
                       WalletRecharge();
                        break;
                    }
                    case 6:
                    {
                        subChoice="no";
                        Console.WriteLine("------------Exit from Sub Menu -----------------");
                        break;
                    }
                }

            }while(subChoice == "yes");
            
        }//end of sub menu

          public static void AddDefaultData()
          {
                CustomerDetails customer1 = new CustomerDetails("Ravi","Chennai","9885858588",50000,"ravi@mail.com");
                CustomerDetails customer2 = new CustomerDetails("Baskaran","Chennai","9885858088",60000,"baskaran@mail.com");

                customersList.AddRange(new List<CustomerDetails>(){customer1,customer2});

                OrderDetails order1 = new OrderDetails("CID1001","PID101",20000,DateTime.Now,2,OrderStatus.Ordered);
                OrderDetails order2 = new OrderDetails("CID1002","PID103",40000,DateTime.Now,2,OrderStatus.Ordered);

                orderList.AddRange(new List<OrderDetails>(){order1,order2});

                    /*PID101	Mobile (Samsung)	10	10000	3
                    PID102	Tablet (Lenovo)	5	15000	2
                    PID103	Camara (Sony)	3	20000	4
                    PID104	iPhone 	5	50000	6
                    PID105	Laptop (Lenovo I3)	3	40000	3
                    PID106	HeadPhone (Boat)	5	1000	2
                    PID107	Speakers (Boat)	4	500	2*/

                ProductDetails product1 =new ProductDetails("Mobile (Samsung)",10,10000,3);
                ProductDetails product2 =new ProductDetails("Tablet (Lenovo)",5,15000,2);
                ProductDetails product3 =new ProductDetails("Camara (Sony)",3,20000,4);
                ProductDetails product4 =new ProductDetails("iPhone",5,50000,6);
                ProductDetails product5 =new ProductDetails("Laptop (Lenovo I3)",3,40000,3);
                ProductDetails product6 =new ProductDetails("HeadPhone (Boat)",5,1000,2);
                ProductDetails product7 =new ProductDetails("Speakers (Boat)",4,500,2);

                productList.AddRange(new List<ProductDetails>(){product1,product2,product3,product4,product5,product6,product7});
          }
    }
}