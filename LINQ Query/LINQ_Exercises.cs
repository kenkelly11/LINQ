using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            //Exercise1(); // done
            //Exercise2(); // done
            //Exercise3(); // done
            //Exercise4(); // done
            //Exercise5(); // done

            //Exercise6(); // done
            //Exercise7(); // done
            //Exercise8(); // done
            //Exercise9(); // done
            //Exercise10(); // done

            //Exercise11(); // done
            //Exercise12(); // done
            //Exercise13(); // done
            //Exercise14(); // done
            //Exercise15(); // done

            //Exercise16(); // done
            //Exercise17(); // done
            //Exercise18(); // done
            //Exercise19(); // done

            //Exercise20(); // done
            //Exercise21(); // review
            //Exercise22(); // done
            //Exercise23(); // done
            //Exercise24(); // done
            //Exercise25(); // done
            //Exercise26(); // done

            Exercise27(); // done//
            Exercise28(); // review
            Exercise29(); // review
            Exercise30(); // review
            Exercise31(); // review

        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion





        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        /// 

        
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var outOfStock = (from p1 in products
                              where p1.UnitsInStock <= 0
                              select p1);

            PrintProductInformation(outOfStock);
            Console.ReadLine();
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            var stockThreeBucks =  from p in products
                                             where p.UnitsInStock > 0
                                             where p.UnitPrice > 3.0M 
                                             select p;

            PrintProductInformation(stockThreeBucks);
            Console.ReadLine();
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var customersWashington = from c in customers
                                      where c.Region == "WA"
                                      select c;

            PrintCustomerInformation(customersWashington);
            Console.ReadLine();

            // come back and try to print orders as well (if enough time)
        }


        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var products = DataLoader.LoadProducts();

            var anon = from a in products
                       select a.ProductName;

            foreach (var productName in anon)
            {
                Console.WriteLine("{0, -35}", productName); 
                
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var products = DataLoader.LoadProducts();

            decimal twenty = 1.25M;

            var anon25 = from a25 in products
                         select new
                         {
                             a25.ProductName,
                             a25.ProductID,
                             newPrice = (a25.UnitPrice * twenty),
                             a25.UnitsInStock
                         };

            foreach (var anon in anon25)
            {
                // what do the numbers mean?
                Console.WriteLine("{0, 75}", anon);
                
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var products = DataLoader.LoadProducts();

            var anonUpper = from au in products
                            select new
                            {
                                ProductName = au.ProductName.ToUpper(),
                                Category = au.Category.ToUpper()
                            };

            foreach (var au in anonUpper)
            {
                Console.WriteLine("{0, -35}", au);
                //Console.ReadLine();
            }

            Console.ReadLine();
            //PrintProductInformation(anonUpper);
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var unitsLessThanThree = from units in products
                                     select new
                                     {
                                         ReOrder = units.UnitsInStock < 3 ? 1: 0 // ternary expression
                                     };

            foreach (var units in unitsLessThanThree)
            {
               
                    Console.WriteLine("{0, -35}", units);
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var products = DataLoader.LoadProducts();

            var unitsStockValue = from v in products
                                  select new
                                  {
                                      StockValue = v.UnitPrice + v.UnitsInStock
                                  };

            foreach (var units in unitsStockValue)
            {
                Console.WriteLine("{0, -35}", units);
            }
                
            Console.ReadLine();

        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            // NumbersA is an array, not a list.
            
            int[] numbers = DataLoader.NumbersA;

            List<int> evens = new List<int>();


            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evens.Add(number);
                    Console.WriteLine(number);
                    
                }
                    
            }

            //Console.WriteLine(evens);
            Console.ReadLine();
            
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customers = DataLoader.LoadCustomers();

            var customersLessThan500 = customers.Where(customer => 
                                       customer.Orders.Any(order => order.Total < 500));

            PrintCustomerInformation(customersLessThan500);
            Console.ReadLine();
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var firstOdds = DataLoader.NumbersC.Where(number => 
                            number % 2 == 1).Take(3);

            foreach (int odd in firstOdds)
            {
                Console.WriteLine("{0, -10}", odd);
            }
            
            Console.ReadLine();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] numbers = DataLoader.NumbersB;

            List<int> numbersB = new List<int>();

            // is it this simple?
            var numbersExcludeThree = numbers.Skip(3);

            foreach (int number in numbersExcludeThree)
            {
                numbersB.Add(number);
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customer = DataLoader.LoadCustomers();

            var customerWashington = from w in customer
                                     where w.Region == "WA"
                                     select new
                                     {
                                         w.CompanyName,
                                         Orders = w.Orders.First()
                                     };

            foreach (var c in customerWashington)
            {
                Console.WriteLine(c.CompanyName + "-" + c.Orders.OrderID);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {

            var lessThanSix = DataLoader.NumbersC.TakeWhile(number => number < 6);

            foreach (var number in lessThanSix)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {

            var divisibleByThree = DataLoader.NumbersC.SkipWhile(number => 
                                   number % 3 != 0);

            foreach (var number in divisibleByThree)
            {

                Console.WriteLine(number);

            }

            Console.ReadLine();
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var products = DataLoader.LoadProducts();

            // is there a built in orderby keyword that can sort them alphabetically?
            var abcProducts = from product in products
                              orderby product.ProductName
                              select product.ProductName;

            foreach (var a in abcProducts)
            {
                Console.WriteLine("{0}", a);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var products = DataLoader.LoadProducts();

            var unitsDescending = from product in products
                                  orderby product.UnitsInStock descending
                                  select product;

            PrintProductInformation(unitsDescending);
            Console.ReadLine();
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
          
            List<Product> products = DataLoader.LoadProducts();

            var categoriesThenPrice = products.OrderBy(product => 
                                      product.Category).ThenByDescending(product => 
                                      product.UnitPrice);

            PrintProductInformation(categoriesThenPrice);
            Console.ReadLine();
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] numbers = DataLoader.NumbersB;

            var numbersB = from number in numbers
                           orderby number descending
                           select number;

            foreach(int number in numbersB)
            {
                Console.WriteLine("{0, -35}", number);
            }
            
            Console.ReadLine();

        }








        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var groups = DataLoader.LoadProducts().GroupBy(product =>
                         product.Category);

            string lineFormat = "{0, -15}";


            foreach (var group in groups)
            {
                Console.WriteLine();
                Console.WriteLine("CATEGORY: {0}", group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine(lineFormat, product.ProductName);
                }
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();

            // this creates the formatting
            var orderByYear = customers.Select(customer => new
            {
                customer.CompanyName,
                groupedOrders = customer.Orders.OrderBy(order =>
                order.OrderDate).GroupBy(order => order.OrderDate.Year)
            });

            foreach(var customer in orderByYear)
            {
                Console.WriteLine(customer.CompanyName);
                foreach (var year in customer.groupedOrders)
                {
                    Console.WriteLine(year.Key);
                    foreach (var order in year)
                    {
                        Console.WriteLine("\t{0:MM} - ${1}", order.OrderDate, order.Total);
                    }
                }

                Console.WriteLine("==================================");
                Console.WriteLine();
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {

            var products = DataLoader.LoadProducts();

            //var q = from c in products
                    //select c.Category.Distinct();
            var printProductCategories = products.Select(product =>
                                         product.Category).Distinct();

            foreach (var category in printProductCategories)
            {
                Console.WriteLine(category);
            }

            Console.ReadLine();

            // experiment with this rather than method syntax
            

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts();

            // productExists is a collection. 
            var productExists = from product in products
                                where product.ProductID == 789
                                select product;


            if (productExists.Count() > 0)
            {
                Console.WriteLine("789 Exists!");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("789 Does not Exist.");
                Console.ReadLine();
            }
            
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var products = DataLoader.LoadProducts();

            var outOfStock = (from product in products
                             where product.UnitsInStock == 0
                             select product.Category).Distinct();

            Console.WriteLine("Here is every category with at least one product out of stock: ");
            foreach (var p in outOfStock)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var products = DataLoader.LoadProducts();


            var noneOutOfStock = (from product in products
                                 where product.UnitsInStock != 0
                                 select product.Category).Distinct();

            Console.WriteLine("Here is every category with no products out of stock: ");
            foreach (var p in noneOutOfStock)
            {
                
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var odds = DataLoader.NumbersA.Where(number =>
                       number % 2 == 1);

            Console.WriteLine(odds.Count());
            Console.ReadLine();
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            //var ordersCount = Order.Count();

            var customerAndOrder = from customer in customers
                                   //group customer.CustomerID by customer.Orders into customerGroup
                                   select new
                                   {
                                       CustomerID = customer.CustomerID,
                                       OrderCount = customer.Orders.Count()
                                   };

            
            foreach (var customer in customerAndOrder)
            {
                // Console.WriteLine needs the string interpolation ( {0}, {1} ) when printing more than one thing!!
                Console.WriteLine("{0} {1}", customer.CustomerID, customer.OrderCount);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var products = DataLoader.LoadProducts();

            var categoryCount = products.GroupBy(product =>
            product.Category).Select(group => new 
            {
                group.Key, // what is .Key? 
                totalProducts = group.Count() // count of all products in group
            });

            foreach (var category in categoryCount)
            {
                Console.WriteLine(category.Key);
                Console.WriteLine(category.totalProducts);
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var products = DataLoader.LoadProducts();

            var categoryCount = products.GroupBy(product =>
            product.Category).Select(group => new
            {
                group.Key,
                totalUnits = group.Sum(product => product.UnitsInStock)
            });

            foreach (var category in categoryCount)
            {
                Console.WriteLine(category.Key);
                Console.WriteLine(category.totalUnits);
            }

            Console.ReadLine();
                  
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var products = DataLoader.LoadProducts();

            var results = from product in products
                          group product by product.Category into newGroup
                          select new
                          {
                              Key = newGroup.Key,
                              LowestPrice = newGroup.Min(m => m.UnitPrice)
                          };

            foreach (var result in results)
            {
                Console.WriteLine($"Product Category: {result.Key}"); // what does the $ mean?
                Console.WriteLine($"Lowest Priced Product: {result.LowestPrice:C}"); // what is the :C? 
                Console.WriteLine();
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var products = DataLoader.LoadProducts();

            // uses both LINQ and Method syntax!

            var results = from product in products
                          group product by product.Category into newGroup
                          select new
                          {
                              Key = newGroup.Key, // the Key is the product category, specified on line 807
                              AverageUnitPrice = newGroup.Average(a => a.UnitPrice)
                          };

            var topThreeResults = results.OrderByDescending(o =>
                                  o.AverageUnitPrice).Take(3);

            foreach (var result in topThreeResults)
            {
                Console.WriteLine($"Category: {result.Key}");
                Console.WriteLine($"Average Unit Price: {result.AverageUnitPrice:C}");
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
