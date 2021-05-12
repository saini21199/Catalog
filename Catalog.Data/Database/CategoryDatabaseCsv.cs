using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Catalog.Data.Entities;
using System.IO;
using System.Linq;

namespace Catalog.Data.Database
{
    public class CategoryDatabaseCsv
    {

        static string filepath = @"C:\Users\lenovo\source\repos\Catalog.Console\Category.csv";

        static List<Category> catlist = new List<Category>();
        static CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            TrimOptions = TrimOptions.Trim,
            Comment = '@',
            AllowComments = true,

        };

        public List<Category> displayCategoryFromCsv() {
            
            using (StreamReader sr = new StreamReader(filepath))
            using (CsvReader csvr= new CsvReader(sr,config)){
                catlist = csvr.GetRecords<Category>().ToList();
                catlist.ForEach(i => Console.WriteLine(i.Name));
            }
                return null;
        }

        public void addCategoryToCsv(Category category) {
            using (StreamWriter sw= new StreamWriter(filepath,true))
            using (CsvWriter csvw = new CsvWriter(sw, config))
            {
                csvw.NextRecord();
                csvw.WriteRecord(category);
            }
            this.displayCategoryFromCsv();
        }
    }
}
