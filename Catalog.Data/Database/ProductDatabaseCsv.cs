using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Catalog.Data.Entities;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Catalog.Data.Database
{
    public class ProductDatabaseCsv
    {
        static string filepath = @"C:\Users\lenovo\source\repos\Catalog.Console\Product.csv";

        public static List<Product> allproducts = new List<Product>();
        public static void addProductToCsvFile(Product product){
            FileInfo finfo = new FileInfo(filepath);
            Console.WriteLine(finfo.Length);
            if (finfo.Length == 0){
                Console.WriteLine("Hello");
                string productTableHeader = "Id" + "," + "Name" + "," + "ShortCode" + "," + "Description" + ","
                + "Manufacturer" + "," + "SellingPrice" + "\n";
                File.AppendAllText(filepath, productTableHeader);
            }
            string newproduct =  product.Id + "," + product.Name + "," + product.ShortCode + "," + product.Description + "," +
                product.Manufacturer + "," + product.SellingPrice + "\n";
            File.AppendAllText(filepath, newproduct);
        }

        public List<Product> displayProductFromCsvFile(){
            //using (StreamReader sr = new StreamReader(filepath))
            //using (CsvReader csvr = new CsvReader(sr, CultureInfo.InvariantCulture)) {
            //    csvr.GetRecords<Product>().ToList().ForEach(i =>
            //    {
            //        Console.WriteLine(i.Name);
            //    });
            //}

            string data = File.ReadAllText(filepath);
            //var arrays = new List<Product[]>();

            List<String> lines = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            lines.RemoveAt(0);
        
            foreach (var line in lines)
            {
                var lineArray = new List<string>();

                foreach (var s in line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    lineArray.Add(s);
                }
                //lineArray.ForEach(i => Console.WriteLine(i));
                allproducts.Add(new Product
                {
                    Id = int.Parse(lineArray[0]),
                    Name = lineArray[1],
                    ShortCode = lineArray[2],
                    Description = lineArray[3],
                    Manufacturer = lineArray[4],
                    SellingPrice = int.Parse(lineArray[5])
                });
            }
            return allproducts;
        }

        public void deleteProductFromCsvFile(int id) {
            Product productToBeDeleted = allproducts.Single(i => i.Id == id);
            allproducts.Remove(productToBeDeleted);
            string productTableHeader = "Id" + "," + "Name" + "," + "ShortCode" + "," + "Description" + "," +
                "Manufacturer" + "," + "SellingPrice" + "\n";
            File.WriteAllText(filepath, productTableHeader);
            allproducts.ForEach(product =>
            {
                string addproduct= product.Id + "," + product.Name + "," + product.ShortCode + "," + product.Description +
                product.Manufacturer + "," + product.SellingPrice + "\n";
                File.AppendAllText(filepath, addproduct);
            });
        }
    }
}
