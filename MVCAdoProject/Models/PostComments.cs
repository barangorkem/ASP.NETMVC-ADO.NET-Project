using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Models
{
    public class PostComments
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; } 

        public string UserName { get; set; }

        public int PostId { get; set; }
    }
}