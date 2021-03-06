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

        static CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            TrimOptions = TrimOptions.Trim,
            Comment = '@',
            AllowComments = true,

        };
        public void addProductToCsvFile(Product product) {

            using (StreamWriter sw = new StreamWriter(filepath, true))
            using (CsvWriter csvw = new CsvWriter(sw, config))
            {
                csvw.NextRecord();
                csvw.WriteRecord(product);
            }

            //FileInfo finfo = new FileInfo(filepath);

            //if (finfo.Length == 0) {
            //    string productTableHeader = "Id" + "," + "Name" + "," + "ShortCode" + "," + "Description" + ","
            //    + "Manufacturer" + "," + "SellingPrice" + "\n";
            //    File.AppendAllText(filepath, productTableHeader);
            //}

            //string newproduct = product.Id + "," + product.Name + "," + product.ShortCode + "," + product.Description + "," +
            //    product.Manufacturer + "," + product.SellingPrice + "\n";
            //File.AppendAllText(filepath, newproduct);
        }

        public List<Product> displayProductFromCsvFile() {

            using (StreamReader sr = new StreamReader(filepath))
            using (CsvReader csvr = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                allproducts = csvr.GetRecords<Product>().ToList();
            }
            return allproducts;

            //string data = File.ReadAllText(filepath);
            ////Console.WriteLine(data);

            //Console.WriteLine(allproducts.Count);
            //List<String> lines = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //lines.RemoveAt(0);

            //foreach (var line in lines)
            //{
            //    var lineArray = new List<string>();

            //    foreach (var s in line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        lineArray.Add(s);
            //    }
            //    allproducts.Add(new Product
            //    {
            //        Id = int.Parse(lineArray[0]),
            //        Name = lineArray[1],
            //        ShortCode = lineArray[2],
            //        Description = lineArray[3],
            //        Manufacturer = lineArray[4],
            //        SellingPrice = int.Parse(lineArray[5])
            //    });
            //}
        }

        public void deleteProductFromCsvFile(int id) {

            Product productToBeDeleted = allproducts.Single(i => i.Id == id);
            allproducts.Remove(productToBeDeleted);

            using (StreamWriter sw = new StreamWriter(filepath))
            using (CsvWriter csvw = new CsvWriter(sw, config)) {
                csvw.WriteRecord(allproducts);
            }

            //    string productTableHeader = "Id" + "," + "Name" + "," + "ShortCode" + "," + "Description" + "," +
            //        "Manufacturer" + "," + "SellingPrice" + "\n";

            //File.WriteAllText(filepath, productTableHeader);
            //allproducts.ForEach(product =>
            //{
            //    string addproduct= product.Id + "," + product.Name + "," + product.ShortCode + "," + product.Description +
            //    product.Manufacturer + "," + product.SellingPrice + "\n";
            //    File.AppendAllText(filepath, addproduct);
            //});

            //allproducts = new List<Product>();
        }

        public Product findProduct(int id) {
            Product foundProduct = allproducts.Single(i => i.Id == id);

            Console.WriteLine("Product Found");
            return foundProduct;
        }
    }
}
