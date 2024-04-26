using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    public static class Operations

    {
        // create a object 
        static UserDetails currentLoggedInUser ;
        // create static Lists
        static List <UserDetails> usersList = new List<UserDetails>();
        static List <BookDetails> booksList = new List<BookDetails>();
        static List <BorrowDetails> borrowList = new List<BorrowDetails>();
        public static void Defaultdata()
        {
            // create objects 
            UserDetails user1 = new UserDetails("Ravichandran ",Gender.Male ,Department.EEE,9938388333,"ravi@gmail.com",100);
            UserDetails user2 = new UserDetails("Priyadharshini",Gender.Female ,Department.CSE,9944444455,"priya@gmail.com",150);
            // add objects  data to the lists
            usersList.AddRange(new List<UserDetails>(){user1,user2});
            // objects for book details 
            BookDetails book1 = new BookDetails("C#","Author1",3);
            BookDetails book2 = new BookDetails("HTML","Author2",5);
            BookDetails book3 = new BookDetails("CSS","Author3",3);
            BookDetails book4 = new BookDetails("JS","Author4",3);
            BookDetails book5 = new BookDetails("TS","Author5",2);
            // add objects to the booklist
            booksList.AddRange(new List<BookDetails>(){book1,book2,book3,book4,book5});
            // objects for borrow details
            BorrowDetails borrow1 = new BorrowDetails("BID1001","SF3001" , new DateTime (2023,09,10),2,Status.Borrowed,0);
            BorrowDetails borrow2 = new BorrowDetails("BID1002","SF3002" , new DateTime (2023,09,12),1,Status.Borrowed,0);
            BorrowDetails borrow3 = new BorrowDetails("BID1003","SF3003" , new DateTime (2023,09,14),1,Status.Returned,16);
            BorrowDetails borrow4 = new BorrowDetails("BID1004","SF3004" , new DateTime (2023,09,11),2,Status.Borrowed,0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005","SF3005" , new DateTime (2023,09,09),1,Status.Returned,20);
            // add objects to the Lists
            borrowList.AddRange(new List<BorrowDetails>(){borrow1,borrow2,borrow3,borrow4,borrow5});

        }// end default method 
        public static void  MainMenu()
        {
            // breaker 
            bool flag = true;
            do
            {
                // greetings 
                Console.WriteLine("---------------- Main Menu---------------");
                 // show main menu 
                // control the flow 
                Console.WriteLine("1.UserRegistration\n2.UserLogin\n3.Exit");
                Console.Write("Select : ");
                int mainChoice;
                bool tempMainChoice = int.TryParse(Console.ReadLine(),out mainChoice);
                while(!tempMainChoice || mainChoice>3)
                {
                    Console.WriteLine("Invalid input Enter correct input ");
                    tempMainChoice = int.TryParse(Console.ReadLine(),out mainChoice);
                }
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("**********User Registration*************");
                        UserRegistration();
                        // calling user registration function

                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*************User Login************");
                        UserLogin();
                        // calling user log in function
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*******Exit Succesfully********");
                        flag=false;
                        break;
                    }
                }
            }while(flag);

        }// end of mainmenu
        public static void UserRegistration()
        {
  // need to get data from the user
        Console.WriteLine("-------------User Registration--------------");
        Console.Write("Enter your Name : ");
        string name = Console.ReadLine();
        Console.Write("Enter your Gender (Male, Female, Transgender) : ");
        Gender gender; 
        bool tempGender = Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        while(!tempGender)
        {
            Console.WriteLine("Invalid Input.Enter correct input");
            tempGender = Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        }
        Console.Write("Enter your Department (ECE, EEE, CSE) : ");
        Department department ;
        bool tempDepartment= Enum.TryParse<Department>(Console.ReadLine(),true,out department);
        while(!tempDepartment)
        {
            Console.WriteLine("Invalid Input.Enter correct input");
            tempDepartment= Enum.TryParse<Department>(Console.ReadLine(),true,out department);
        }
        Console.Write("Enter your Mobile Number : ");
        long mobileNumber ;
        bool tempMobileNumber= long.TryParse(Console.ReadLine(),out mobileNumber);
        while(!tempMobileNumber)
        {
            Console.WriteLine("Invalid Input.Enter correct input");
            tempMobileNumber= long.TryParse(Console.ReadLine(),out mobileNumber);
        }
        Console.Write("Enter your Mail ID : ");
        string mailID = Console.ReadLine();
        Console.Write("Enter your wallet balance greater than 0 : ");
        int balance ;
        bool tempBalance= int.TryParse(Console.ReadLine(),out balance);
        while(!tempBalance)
        {
            Console.WriteLine("Invalid Input.Enter correct input");
            tempBalance= int.TryParse(Console.ReadLine(),out balance);
        }
        // create a objectt 
        UserDetails user = new UserDetails(name,gender,department,mobileNumber,mailID,balance);
        // add it to the list
        usersList.Add(user);
        // show the registration message 
        Console.WriteLine($"Registered successfully . And your Registration ID is : {user.UserID}");
        Console.WriteLine("Thankyou for the Registration");
        }
        public static void UserLogin()
        {
            Console.Write("Enter your User ID : ");
            string userID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach(UserDetails user in usersList)
            {
                if(userID.Equals(user.UserID))
                {
                    currentLoggedInUser = user;
                    flag = false;
                    Console.WriteLine("Login successfully.......");
                    // calling sub menu
                    SubMenu();
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid User ID. Please enter a valid one");
            }

        }// user login ends
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("----------------Sub Menu--------------");
                Console.WriteLine("\n1.Borrowbook.\n2.ShowBorrowedhistory.\n3.ReturnBooks\n4.WalletRecharge\n5.Exit");
                Console.Write("Select : ");
                int subChoice; 
                bool tempsubChoice = int.TryParse(Console.ReadLine(),out subChoice);
                while(!tempsubChoice || subChoice>5)
                {
                    Console.WriteLine("Invalid input Enter correct input ");
                    tempsubChoice = int.TryParse(Console.ReadLine(),out subChoice);
                }
                switch(subChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("********Borrow Book********");
                        // calling function
                        BorrowBook();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**********Borrow History***********");
                        ShowBorrowHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("***********Return Books***********");
                        ReturnBooks();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("************Wallet Reacharge**********");
                        WalletRecharge();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Taking BAck to Main menu");
                        flag = false;
                        break;
                    }
                }

            }while(flag);
        }// end of sub menu 

        public static void BorrowBook()
        {
            // show lists of book
            ShowBookDetails();
            // ask user to pick one book iD
            Console.Write("Enter the Book ID : ");
            string bookID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach(BookDetails book in booksList)
            {
                if(bookID == book.BookID)
                {
                    flag = false;
                    // ask the user to enter the count
                    Console.Write("Enter the counts of the book you want :");
                    int userCount ;
                    bool tempuserCount = int.TryParse(Console.ReadLine(), out userCount );
                    while (!tempuserCount)
                    {
                        Console.WriteLine("Invalid Input.Enter correct input");
                        tempuserCount = int.TryParse(Console.ReadLine(), out userCount );
                    }
                    // compare the count 
                    if (book.BookCount>userCount)
                    {
                        foreach(BorrowDetails borrow in borrowList.ToList())
                        {
                            if(currentLoggedInUser.UserID==borrow.UserID)
                            {
                                if(borrow.BookCount>3)
                                {
                                    Console.WriteLine("You have borrowed 3 books already");
                                    
                                }
                                else if (borrow.BookCount + userCount > 3)
                                {
                                    Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {borrow.BookCount} and requested count is {userCount}, which exceeds 3 ");
                                }
                                else
                                {
                                    Console.WriteLine("You are eligible to borrow the book");
                                    // reduce the count
                                    int bookCount = borrow.BookCount--;
                                    // create the object
                                    BorrowDetails borrow1 = new BorrowDetails(bookID,currentLoggedInUser.UserID,DateTime.Now,bookCount,Status.Borrowed,0);
                                    // add it to the list
                                    borrowList.Add(borrow1);
                                    Console.WriteLine("Book Borrowed successfully");
                                }
                                break;

                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Books are not available for the selected count");
                        foreach(BorrowDetails borrow in borrowList)
                        {
                            if(bookID==borrow.BookID)
                            {
                                DateTime date = borrow.BorrowedDate.AddDays(15);
                                Console.WriteLine($"Book will be available in the {date} ."); 
                                break;
                            }
                        }

                    }

                }

            }
            if(flag)
            {
                Console.WriteLine("Invalid Book ID.");
            }

        }// end of borrowbook
        public static void ShowBookDetails()
        {
            //show List of books 
            Console.WriteLine($"|{"Book ID"}|{"Book Name"}|{"Author Name"}|{"Book count"}|");
            foreach(BookDetails books in booksList)
            {
                Console.WriteLine($"|{books.BookID}|{books.BookName}|{books.AuthorName}|{books.BookCount}|");
            }
        }// end of show book details
        public static void ShowBorrowHistory()
        {
            Console.WriteLine("Book borrow History");
            Console.WriteLine($"|{"Borrow ID"}|{"Book ID"}|{"User ID"}|{"Borrow Date"}|{"Book Count"}|{"Borrrow Status"}|{"{Paid fine Amount}|"}");
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentLoggedInUser.UserID==borrow.UserID )
                {
                    Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate}|{borrow.BookCount}|{borrow.Status}|{borrow.PaidFineAmount}|");
                }
            
            }
            
        }// end of showborrowhistory
        public static void ReturnBooks()
        {
            // show the borrowed book details with return date 
            Console.WriteLine($"|{"Borrow Id"}|{"Book Id"}|{"User Id"}|{"Borrowed Date"}|{"Return Date"}|{"Borrow Book Count"}|{"Status"}|{"Paid fine amount"}|");
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentLoggedInUser.UserID == borrow.UserID&&borrow.Status ==Status.Borrowed)
                {
                    DateTime returnDate = borrow.BorrowedDate.AddDays(15);
                    Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate}|{returnDate}|{borrow.BookCount}|{borrow.Status}|{borrow.PaidFineAmount}"); 
                    int  dueTime = (int)(DateTime.Now - returnDate).TotalDays; 
                    int fineAmount;
                    Console.WriteLine("select the borrowed Id :");
                    string borrowId = Console.ReadLine().ToUpper();
                    bool flag = true;
                    foreach(BorrowDetails borrowed in borrowList)
                    {
                        if(borrowId == borrowed.BorrowID && currentLoggedInUser.UserID==borrowed.UserID)
                        {
                            flag=false;
                            if (dueTime > 15)
                            {
                                fineAmount = (dueTime - 15 )* borrowed.BookCount;
                                if(currentLoggedInUser.WalletBalance>fineAmount)
                                {
                                    borrowed.Status = Status.Returned;
                                    borrowed.BookCount += borrowed.BookCount;
                                    borrowed.PaidFineAmount +=fineAmount;
                                    Console.WriteLine("Book Returned Successfully.........");
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient balance. Please rechange and proceed");
                                    Console.WriteLine($"Your fine amount is {fineAmount}");
                                }
                            }
                            else
                            {
                                borrowed.Status=Status.Returned;
                                borrowed.BookCount +=borrowed.BookCount;
                                Console.WriteLine("Book Returned Successfully.........");
                                
                            }

                        }
                    }
                    if(flag)
                    {
                        Console.WriteLine("Invalid borrow id.");
                    }
                }
                
            }

        }//end of Return Books
        public static void WalletRecharge()
        {
            Console.WriteLine("Wallet Recharge.........");
            // asking user for recharge 
            Console.Write("Are you wish to Recharge the wallet (yes/no):  ");
            string userChoice = Console.ReadLine().ToLower();
            if(userChoice.Equals("yes"))
            { 
                bool flag = true;
                foreach(UserDetails user in usersList)
                {
                    if (currentLoggedInUser.UserID == user.UserID )
                    {
                        flag=false;
                        // get the amount to be reacharged
                        Console.Write("Enter the amount to be recharged : ");
                        int amount ;
                        bool tempAmount= int.TryParse(Console.ReadLine(),out amount );
                        while(!tempAmount)
                        {
                            Console.WriteLine("Invalid Input.Enter the correct value ");
                            tempAmount= int.TryParse(Console.ReadLine(),out amount );
                        }
                        // calling walletrecharge function
                        currentLoggedInUser.WalletRecharge(amount);
                        Console.WriteLine($"Your Updated Wallet balance : {currentLoggedInUser.WalletBalance}");

                    }
                }
                if(flag)
                {
                    Console.WriteLine("Invalid UserID");
                }

            }
        }// end of wallwt recharge 
    
    }
}