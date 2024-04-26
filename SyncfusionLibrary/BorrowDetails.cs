using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    public enum Status {Select ,Default, Borrowed, Returned  }
    public class BorrowDetails
    {
        /*•	BorrowID (Auto Increment – LB2000)
•	BookID 
•	UserID
•	BorrowedDate – ( Current Date and Time )
•	BorrowBookCount 
•	Status –  ( Enum - Default, Borrowed, Returned )
•	PaidFineAmount
*/

    // field - static field 
    private static int s_borrowID = 2000;
    // properties
    public string BorrowID{ get; }// REad only property
    public string BookID { get; set; }
    public string UserID { get; set; }
    public DateTime BorrowedDate { get; set; }
    public int BookCount { get; set; }
    public Status Status {get; set;}
    public int PaidFineAmount { get; set; }

    // Constructors
    public BorrowDetails(string bookID ,string userID , DateTime borrowDate , int bookCount , Status status , int paidFineAmount)
    {
        // Auto incrementation
        s_borrowID++;
        BorrowID = "LB" + s_borrowID;
        // assigning values 
        BookID = bookID;
        UserID = userID;
        BorrowedDate = borrowDate;
        BookCount = bookCount;
        Status = status;
        PaidFineAmount = paidFineAmount;
    }   
    }
}