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
            op.displayCategoryFromCsv();
            //Console.WriteLine("Id\t\tName\t\tShortCode\t\tDescription");
            //Console.WriteLine(" ");
            //foreach (var item in Categories)
            //{
            //    Console.WriteLine(item.Id + "\t\t" + item.Name + "\t\t" + item.ShortCode + "\t\t" + item.Description);
            //}
            
        }

        public void DeleteCategory()
        {
            //Console.WriteLine("Please select an option to delete");
            //Console.Write("1. detete by Id\t");
            //Console.WriteLine("2. delete by Short Code\t");
            //Console.WriteLine(" ");

            //int choice = Convert.ToInt32(Console.ReadLine());
            //if (choice == 1)
            //{
            //    Console.WriteLine("Enter product id to delete the category");
            //    int id = Convert.ToInt32(Console.ReadLine());

            //    Categories.RemoveAt(id - 1);
            //}
            //else if (choice == 2)
            //{
            //    Console.WriteLine("Enter product short code to delete the category");
            //    string shortcode = Console.ReadLine();
            //    var categorytoremove = Categories.Single(r => r.ShortCode == shortcode);
            //    Categories.Remove(categorytoremove);
            //}

        }

        public void SearchCategory()
        {
            //Console.WriteLine("Please select an option to search");
            //Console.Write("1. search by Id\t");
            //Console.Write("2. search by Name\t");
            //Console.WriteLine("3. search by ShortCode");
            //Console.WriteLine(" ");

            //int choice = Convert.ToInt32(Console.ReadLine());
            //if (choice == 1)
            //{
            //    Console.WriteLine("Enter Id");
            //    int id = Convert.ToInt32(Console.ReadLine());
            //    var res = Categories.Where(p => p.Id == id).ToList();
            //    Console.WriteLine(" ");
            //    res.ForEach(item => Console.WriteLine("Id: " + item.Id + "\t" + "Name: " + item.Name + "\t" + "ShortCode: " + item.ShortCode + "\t" + "Description: " + item.Description));
            //}
            //if (choice == 3)
            //{
            //    Console.WriteLine("Enter ShortCode");
            //    string code = (Console.ReadLine().ToLower());
            //    var res = Categories.Where(p => p.ShortCode.ToLower() == code).ToList();
            //    Console.WriteLine(" ");
            //    res.ForEach(item => Console.WriteLine("Id: " + item.Id + "\t" + "Name: " + item.Name + "\t" + "ShortCode: " + item.ShortCode + "\t" + "Description: " + item.Description));
            //}
            //if (choice == 2)
            //{
            //    Console.WriteLine("Enter name");
            //    string name = (Console.ReadLine().ToLower());
            //    var res = Categories.Where(p => p.Name.ToLower() == name).ToList();
            //    Console.WriteLine(" ");
            //    res.ForEach(item => Console.WriteLine("Id: " + item.Id + "\t" + "Name: " + item.Name + "\t" + "ShortCode: " + item.ShortCode + "\t" + "Description: " + item.Description));
            //}


        }
    }
}
