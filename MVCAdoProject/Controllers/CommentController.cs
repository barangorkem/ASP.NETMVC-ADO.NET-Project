using MVCAdoProject.Models;
using MVCAdoProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAdoProject.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentRepository commentRepository = new CommentRepository();
        public ActionResult Index()
        {
            List<PostComments> postComments = commentRepository.getComments();
            return View(postComments);
        }
        public ActionResult Delete(int id)
        {
            commentRepository.deleteComments(id);
            return RedirectToAction("Index");
        }
    }
}