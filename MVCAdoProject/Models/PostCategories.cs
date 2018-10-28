using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Models
{
    public class PostCategories
    {
        public int PostCategoriesId { get; set; }

        public int CategoryId { get; set; }

        public int PostId { get; set; }

        public virtual Posts Posts { get; set; }

        public virtual Categories Categories { get; set; }
    }
}