using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    public class Product
    {
        public string name;
        public decimal price;

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }   

        public void Print()
        {
            Console.WriteLine($"{name} {price}");
        }
    }

    public class Order
    {
        public List<Product> productsOrder;
        public decimal fullPrice;
        public Order(List<Product> products)
        {
            productsOrder = products;
                       
            foreach(var product in products)
            {
                fullPrice += product.price;
            }
        }
    }

    public class Store
    {
        public List<Product> products;

        public List<Product> basket;

        public List<Order> orders;
        public Store()
        {

            products = new List<Product>
            {
                new Product("Bread", 25),
                new Product("Milk", 100),
                new Product("Cokies", 55),
                new Product("Cream", 150),
                new Product("Yogurt", 65),
                new Product("Juice", 80)
            };

            basket = new List<Product>();
            orders = new List<Order>();
        }

        public void ShowCatalog()
        {
            Console.WriteLine("The products catalog:");
            ShowProducts(products);
        }

        public void ShowProducts(List<Product> showProducts)
        {
            int number = 1;
            foreach (Product product in showProducts)
            {
                Console.Write(number + ". ");
                product.Print();
                number++;
            }
        }

        public void ShowBasket()
        {
            Console.WriteLine("The buscet containt");
            ShowProducts(basket);
        }

        public void AddToBasket(int numberProduct)
        {
            basket.Add(products[numberProduct - 1]);
            Console.WriteLine($"The product {products[numberProduct - 1].name} added to the busket is access");
            Console.WriteLine($"In basket {basket.Count} some of products");
        }

        internal void CreateOrder()
        {
            Order order = new Order(basket);
            orders.Add(order);

            basket.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Store onlineStore = new Store();

            Console.WriteLine("Hello, change some actions");
            Console.WriteLine("1. To show the catalog of product?");
            Console.WriteLine("Make the actions number, to do");

            int numberAction = Convert.ToInt32(Console.ReadLine());

            switch (numberAction)
            {
                case 1: onlineStore.ShowCatalog(); break;
                default:
                    Console.WriteLine("Took actions number on the list.");
                    break;
            }
            bool yes = false;
            do 
            { 
                Console.WriteLine("Should you add the product to the busket? Write \"yes\" or \"no\".");
                yes = IsYes(Console.ReadLine());
                if (yes)
                {
                    onlineStore.ShowCatalog();
                    Console.WriteLine("Write the product number, to add to busket");
                    int productNumber = Convert.ToInt32(Console.ReadLine());
                    onlineStore.AddToBasket(productNumber);
                }
            } while (yes);


            // 3. See at the basket.

            Console.WriteLine("Should you look to the busket? Write \"yes\" or \"no\".");
            yes = IsYes(Console.ReadLine());
            if (yes)
            {
                onlineStore.ShowBasket();
            }

            // 4. Make an order.

            Console.WriteLine("Should you make the order? Write \"yes\" or \"no\".");
            yes = IsYes(Console.ReadLine());
            if (yes)
            {
                onlineStore.CreateOrder();
            }

                // Delay.
                Console.ReadKey();
        }

        static bool IsYes(string answer)
        {
            return answer.ToLower() == "yes";
        }
    }
}
