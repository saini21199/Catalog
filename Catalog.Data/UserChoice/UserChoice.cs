using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.UserChoic
{
    public class UserChoice
    {
        public int selectAnOption()
        {
            Console.WriteLine("Please Select An Option \n 1.Category \n 2.Product \n 3.Exit Application \n");

            Console.WriteLine("Enter a number from above menu");
            int value = Convert.ToInt32(Console.ReadLine());
            if (value < 1 || value > 3)
            {
                Console.WriteLine("Please choose a valid operation");

            }
            return value;
        }

        public int selectInCategory()
        {
            Console.WriteLine("1.Enter a Category \n2.List all Categories \n3.Delete a Category \n4.Search a Category \n");

            Console.WriteLine("Enter a number from above menu");
            int value = Convert.ToInt32(Console.ReadLine());
            if (value < 1 || value > 4)
            {
                Console.WriteLine("Invalid Operation");
            }
            return value;
        }


        public int selectInProduct()
        {
            Console.WriteLine("1.Enter a Product \n 2.List all Product \n 3.Delete a Product \n 4.Search a Product");

            Console.WriteLine("Enter a number from above menu");
            int value = Convert.ToInt32(Console.ReadLine());
            if (value < 1 || value > 4)
            {
                Console.WriteLine("Invalid Operation");
            }
            return value;
        }
    }
}
