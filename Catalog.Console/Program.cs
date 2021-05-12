using System;
using System.Threading.Tasks;
using static System.Console;
using Catalog.Data.EntitySelection;
using Catalog.Data.UserChoic;
using Catalog.Data.Database;

namespace Catalog.Console
{
    class Program
    {
        static void Main(string[] args) {
            //{
            EntitySelection select = new EntitySelection();

            UserChoice choice = new UserChoice();

            while (true)
            {
                int input = choice.selectAnOption();

                switch (input)
                {
                    case 1:
                        select.categorySelected();
                        break;
                    case 2:
                        select.productSelected();
                        break;
                    default:
                        WriteLine("Invalid input!! Enter Again \n");
                        break;
                }
                Task.Delay(900);
            }
            //CategoryDatabaseCsv op = new CategoryDatabaseCsv();


            //CategoryDatabaseCsv.displayCategoryFromCsv();
            //ProductDatabaseCsv.displayProductFromCsvFile();
            //ProductDatabaseCsv.displayProductFromCsvFile();
        }
    }
}
