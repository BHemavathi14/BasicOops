using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public static partial class Operations
    {
        public static void Purcahse()
        {
            bool flag = true;
            Console.WriteLine("|Product ID|Product Name|Price|Stock|Shipping Duration|");
            foreach(ProductDetails product in productList)
            {
                Console.WriteLine($"|{product.ProductID}|{product.ProductName}|{product.Price}|{product.Stock}|{product.ShippingDuration}|");
            }
            Console.WriteLine("Select a Product using Product ID : ");
            string productId = Console.ReadLine().ToUpper(); 
            foreach(ProductDetails product in productList)
            {
                if(product.ProductID==productId)
                {
                    flag=false;
                    Console.Write("How much Quantity you want : ");
                    int quantity = int.Parse(Console.ReadLine());
                    if(quantity<product.Stock)
                    {
                        int totalAmount = (quantity*product.Price)+50;
                        if(currentLoggedInUser.WalletBalance>totalAmount)
                        {
                            currentLoggedInUser.DeductAmount(totalAmount);
                            product.Stock-=quantity;
                            OrderDetails order = new OrderDetails(currentLoggedInUser.CustomerID,product.ProductID,totalAmount,DateTime.Now,quantity,OrderStatus.Ordered);
                            Console.WriteLine($"Order Placed Successfully. Order ID: {order.OrderID}\nYour order will be delivered on {order.PurchaseDate.AddDays(product.ShippingDuration).ToString("dd/MM/yyyy")} ");
                            orderList.Add(order);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
                    }
                }
                
            }
            if(flag)
            {
                Console.WriteLine("Invalid Product ID");
            }
          
        }// end of purchase

        public static void OrderHistory()
        {
            bool flag =true;
            Console.WriteLine("|Order Id|Product Id|Customer Id|Purchase Date|Total Price|Qunatity|Order Status|");
            foreach(OrderDetails order in orderList)
            {
                if(currentLoggedInUser.CustomerID==order.CustomerID)
                {
                    flag=false;
                    Console.WriteLine($"|{order.OrderID}|{order.ProductID}|{order.CustomerID}|{order.PurchaseDate}|{order.TotalPrice}|{order.Quantity}|{order.OrderStatus}|");
                }
            }
            if(flag)
            {
                Console.WriteLine("No History found");
            }

        }// end of orderHistory
        public static void CancelOrder()
        {
            bool flag =true;
            Console.WriteLine("|Order Id|Product Id|Customer Id|Purchase Date|Total Price|Qunatity|Order Status|");
            foreach(OrderDetails order in orderList)
            {
                if(currentLoggedInUser.CustomerID==order.CustomerID)
                {
                    flag=false;
                    Console.WriteLine($"|{order.OrderID}|{order.ProductID}|{order.CustomerID}|{order.PurchaseDate}|{order.TotalPrice}|{order.Quantity}|{order.OrderStatus}|");
                }
            }
            if(flag)
            {
                Console.WriteLine("No History found");
            }
            else
            {
                Console.WriteLine("Enter the order Id : ");
                string orderId = Console.ReadLine().ToUpper();
                bool flag2=true;
                foreach(OrderDetails order in orderList)
                {
                    if(orderId==order.OrderID)
                    {
                        flag2=false;
                        currentLoggedInUser.WalletRecharge(order.TotalPrice);
                        foreach(ProductDetails product in productList)
                        {
                            if(order.ProductID == product.ProductID)
                            {
                                product.Stock +=order.Quantity;
                                break;
                            }
                        }
                        order.OrderStatus=OrderStatus.Cancelled;
                        Console.WriteLine($"Order :{order.OrderID} cancelled successfully");
                    }
                }
                if(flag2)
                {
                    Console.WriteLine("Invalid OrderID");
                }
            }

        }//end of cancel order
        public static void WalletBalance()
        {
             Console.WriteLine($"Your Wallet Balance is {currentLoggedInUser.WalletBalance}");
        }// end of wallet balance 
        public static void WalletRecharge()
        {
            Console.Write("Enter the Amount to be Recharged : ");
            int amount = int.Parse(Console.ReadLine());
            currentLoggedInUser.WalletRecharge(amount);
           

        }// end of wallet recharge 
    }
}