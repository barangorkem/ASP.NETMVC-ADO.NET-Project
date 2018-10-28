using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public List<CheckBoxViewCategoryModel> Category { get; set; }
    }
}