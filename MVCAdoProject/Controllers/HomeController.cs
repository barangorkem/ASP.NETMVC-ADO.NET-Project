using MVCAdoProject.Models;
using MVCAdoProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAdoProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        PostsRepository postsRepository = new PostsRepository();
        MyRepository myRepository = new MyRepository();
        public ActionResult Index()
        {
           
            List<Posts> posts = postsRepository.ListPosts();
            return View(posts);
        }

        public ActionResult PostContent(int id)
        {
            Posts post = postsRepository.FindPosts(id);
            return View(post);
        }
        [HttpPost]
        public bool DoComment(Comments comments)
        {
            myRepository.doComments(comments, User.Identity.Name);
            return true;
        }
        [HttpGet]
        public PartialViewResult GetComments(int PostId)
        {
            List<PostComments> postComments = myRepository.getComments(PostId);
            return PartialView(postComments);
        }
      
    }
}