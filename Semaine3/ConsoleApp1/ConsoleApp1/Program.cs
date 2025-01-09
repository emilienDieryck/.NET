// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Models;




NorthwindContext context = new NorthwindContext();

/*
Console.WriteLine("Entrez le nom de la ville : ");
String? entry = Console.ReadLine();
IEnumerable<Customer> customers = (from c in context.Customers
                                  where c.City == entry
                                  select c);

foreach (Customer customer in customers)
{
    Console.WriteLine(" {0} ", customer.ContactName);
    
}
*/

IQueryable<Product> products = (from p in context.Products
                                join c in context.Categories
                                on p.CategoryId equals c.CategoryId
                                where p.Category.CategoryName.Equals("Beverages")
                                || p.Category.CategoryName.Equals("Condiments")
                                select p);


Console.WriteLine(products.Count());   
foreach (Product product in products)
{
    Console.WriteLine( "{0}", product.ProductName);
   
}