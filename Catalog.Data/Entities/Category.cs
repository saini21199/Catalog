using Catalog.Data.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.Entities
{
    public class Category : SharedAttributes
    {
        public static int catId;
        public Category()
        {
            catId = catId + 1;
            this.Id = catId;
        }
    }
}
