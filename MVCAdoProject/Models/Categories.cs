using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<PostCategories> PostCategories { get; set; }
    }
}