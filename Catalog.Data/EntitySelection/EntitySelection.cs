using Catalog.Data.Operations;
using Catalog.Data.UserChoic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.EntitySelection
{
    public class EntitySelection
    {
        public void categorySelected()
        {
            CategoryOperation catoperation = new CategoryOperation();
            UserChoice choie = new UserChoice();
            int option1 = choie.selectInCategory();

            switch (option1)
            {
                case 1:
                    catoperation.AddCategory();
                    break;
                case 2:
                    catoperation.ListAllCategories();
                    break;
                case 3:
                    catoperation.DeleteCategory();
                    break;
                case 4:
                    catoperation.SearchCategory();
                    break;
            }

        }
        public void productSelected()
        {
            ProductOperations prodoperation = new ProductOperations();

            UserChoice choice = new UserChoice();
            int option1 = choice.selectInProduct();

            switch (option1)
            {
                case 1:
                    prodoperation.AddProduct();
                    break;
                case 2:
                    prodoperation.ListAllProducts();
                    break;
                case 3:
                    prodoperation.DeleteProduct();
                    break;
                case 4:
                    prodoperation.SearchProduct();
                    break;
            }
        }
    }
}
