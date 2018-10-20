using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Models
{
    public class Posts
    {

        public int PostId { get; set; }

        [Required(ErrorMessage ="Post title is required.")]
        public string PostTitle { get; set; }
        [Required(ErrorMessage = "Post content is required.")]

        public string PostContent { get; set; }

        public string PostImage { get; set; }

        public virtual  ICollection<Comments> Comments { get; set; }

    }
}