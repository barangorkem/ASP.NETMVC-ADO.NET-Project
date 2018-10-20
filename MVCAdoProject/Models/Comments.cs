using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Models
{
    public class Comments
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Comment content is required.")]

        public string CommentContent { get; set; }
        
        public DateTime CommentDate { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public virtual Users Users { get; set; }

        public virtual Posts Posts { get; set; }


    }
}