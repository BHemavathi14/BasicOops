using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public enum OrderStatus {Default, Ordered, Cancelled}
    public class OrderDetails
    {
        /*•	OrderID (Auto Increment – OID1001)
        •	CustomerID
        •	ProductID
        •	TotalPrice 
        •	PurchaseDate
        •	Quantity
        •	OrderStatus – (Enum- Default, Ordered, Cancelled)
        */

        private static int s_orderID=100;
        public string OrderID { get; } 
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
         
       


        public OrderDetails(string customerID , string productID, int totalPrice,DateTime purchaseDate,int qunatity, OrderStatus orderStatus)//DateTime shippingDuration)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=qunatity;
            OrderStatus=orderStatus;
            CustomerID=customerID;
            
        }

    }
}