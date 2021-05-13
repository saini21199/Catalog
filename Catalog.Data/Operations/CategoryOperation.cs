using Catalog.Data.Database;
using Catalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.Operations
{
    public class CategoryOperation
    {
        public static List<string> allCode = new List<string>();
        CategoryDatabaseCsv op = new CategoryDatabaseCsv();
        public void AddCategory()
        {
            Category category = new Category();
            Console.WriteLine("Cateory Id : " + category.Id + "\t");
            Console.WriteLine("Please enter category name: ");
            category.Name = Console.ReadLine();

            Console.WriteLine("Please enter a Shortcode for the category(max 4 characters): ");
            Boolean check = true;
            while (check)
            {
                Boolean found = false;
                category.ShortCode = Console.ReadLine();
                if (allCode.Count == 0)
                {
                    allCode.Add(category.ShortCode);
                    check = false;
                }
                else
                {
                    allCode.ForEach((e) => { if (e == category.ShortCode) { found = true; } });

                    //string result = allCode.First((string code) => code == category.ShortCode);
                    if (found == true)
                    {
                        Console.WriteLine("Code already exist!! Enter new");
                    }
                    else
                    {
                        allCode.Add(category.ShortCode);
                        check = false;
                    }
                }
            }

            Console.WriteLine("Please enter description: ");
            category.Description = Console.ReadLine();

            op.addCategoryToCsv(category);
            Console.WriteLine("Category Addded Successfully ! ");
        }

        public void ListAllCategories()
        {
            Console.WriteLine("Id\t\tName\t\tShortCode\t\tDescription");
            Console.WriteLine(" ");
            op.displayCategoryFromCsv().ForEach(item =>
                Console.WriteLine(item.Id + "\t\t" + item.Name + "\t\t" + item.ShortCode + "\t\t" + item.Description));
        }

        public void DeleteCategory()
        {
            Console.WriteLine("Enter and ID to delete Category");
            int id = int.Parse(Console.ReadLine());
            op.deleteCategoryFromCsv(id);
            Console.WriteLine("Product Removed Successfully");
        }

        public void SearchCategory()
        {
            Console.WriteLine("Enter Id to search category");
            int id =int.Parse(Console.ReadLine());

            Category foundCat=op.findCategory(id);
            Console.WriteLine("Id: " + foundCat.Id + "\t" + "Name: " + foundCat.Name + "\t" + "ShortCode: " + foundCat.ShortCode + "\t" + "Description: " + foundCat.Description); ;

        }
    }
}
