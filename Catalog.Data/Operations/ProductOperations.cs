using Catalog.Data.Database;
using Catalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.Operations
{
    public class ProductOperations
    {
        public static List<string> allCode = new List<string>();
        ProductDatabaseCsv op = new ProductDatabaseCsv();
        public void AddProduct()
        {
            Product product = new Product();
            Console.WriteLine(" Id : " + product.Id + "\t");

            Console.WriteLine("Please enter product name: ");
            product.Name = Console.ReadLine();


            Console.WriteLine("Please enter a Shortcode for the product(max 4 characters):");
            Boolean check = true;
            while (check)
            {
                Boolean found = false;
                product.ShortCode = Console.ReadLine();
                if (allCode.Count == 0)
                {
                    allCode.Add(product.ShortCode);
                    check = false;
                }
                else
                {

                    allCode.ForEach((e) => { if (e == product.ShortCode) { found = true; } });
                    if (found == true)
                    {
                        Console.WriteLine("code already exist!! enter new");
                    }
                    else
                    {
                        allCode.Add(product.ShortCode);
                        check = false;
                    }
                }
            }

            Console.WriteLine("Please enter description: ");
            product.Description = Console.ReadLine();


            Console.WriteLine("Please enter product manufacturer: ");
            product.Manufacturer = Console.ReadLine();

            Console.WriteLine("Please enter product price: ");
            product.SellingPrice = Convert.ToInt32(Console.ReadLine());

            
            op.addProductToCsvFile(product);
        }
        public void ListAllProducts()
        {
            Console.WriteLine("Id\t\tName\t\tShortCode\t\tDescription\t\tManufacturer\t\tPrice");
            op.displayProductFromCsvFile().ForEach(item =>
            {
                Console.WriteLine(item.Id + "\t\t" + item.Name + "\t\t" + item.ShortCode + "\t\t\t" + item.Description + "\t\t\t" + item.Manufacturer + "\t\t\t" + item.SellingPrice);
            }
            );
        }
        public void DeleteProduct()
        {

            Console.WriteLine("Please select an option to delete");
            int id = Convert.ToInt32(Console.ReadLine());

            op.deleteProductFromCsvFile(id);
        }

        public void SearchProduct()
        {
            Console.WriteLine("Enter Id to search");
            int id = int.Parse(Console.ReadLine());
            Product item=op.findProduct(id);
            Console.WriteLine("Id: " + item.Id + "\t" + "Name: " + item.Name + "\t" + "ShortCode: " + item.ShortCode + "\t" + "Description: " + 
                item.Description + "Manufacturer: " + item.Manufacturer + "Price: " + item.SellingPrice);
            //Console.Write("1. search by Id\t");
            //Console.Write("2. search by Name\t");
            //Console.WriteLine("3. search by ShortCode");
            //Console.WriteLine(" ");

            //int choice = Convert.ToInt32(Console.ReadLine());
            //if (choice == 1)
            //{
            //    Console.WriteLine("Enter Id");
            //    int id = Convert.ToInt32(Console.ReadLine());
            //    var res = Products.Where(p => p.Id == id).ToList();
            //    Console.WriteLine(" ");
            //    res.ForEach(item => Console.WriteLine("Id: " + item.Id + "\t" + "Name: " + item.Name + "\t" + "ShortCode: " + item.ShortCode + "\t" + "Description: " + item.Description + "Manufacturer: " + item.Manufacturer + "Price: " + item.SellingPrice));
            //}
            //if (choice == 3)
            //{
            //    Console.WriteLine("Enter ShortCode");
            //    string code = (Console.ReadLine().ToLower());
            //    var res = Products.Where(p => p.ShortCode.ToLower() == code).ToList();
            //    Console.WriteLine(" ");
            //    res.ForEach(item => Console.WriteLine("Id: " + item.Id + "\t" + "Name: " + item.Name + "\t" + "ShortCode: " + item.ShortCode + "\t" + "Description: " + item.Description + "Manufacturer: " + item.Manufacturer + "Price: " + item.SellingPrice));
            //}
            //if (choice == 2)
            //{
            //    Console.WriteLine("Enter name");
            //    string name = (Console.ReadLine().ToLower());
            //    var res = Products.Where(p => p.Name.ToLower() == name).ToList();
            //    Console.WriteLine(" ");
            //    res.ForEach(item => Console.WriteLine("Id: " + item.Id + "\t" + "Name: " + item.Name + "\t" + "ShortCode: " + item.ShortCode + "\t" + "Description: " + item.Description + "Manufacturer: " + item.Manufacturer + "Price: " + item.SellingPrice));
            //}


        }
    }
}
