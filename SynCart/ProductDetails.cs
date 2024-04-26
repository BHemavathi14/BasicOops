using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class ProductDetails
    {
        /*•	ProductID (Auto Increment – PID101)
        •	ProductName
        •	Price
        •	Stock 
        */

        private static int s_productID =100;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int ShippingDuration { get; set; }

        public  ProductDetails(string productName,int stock,int price,int shippingDuration)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            Price=price;
            Stock=stock;
            ShippingDuration=shippingDuration;
        }
    }
}