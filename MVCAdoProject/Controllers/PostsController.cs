using MVCAdoProject.Models;
using MVCAdoProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAdoProject.Controllers
{
    public class PostsController : Controller
    {
        CategoriesRepository categoriesRepository = new CategoriesRepository();
        PostsRepository postsRepository = new PostsRepository();
        // GET: Posts
        public ActionResult Index()
        {
            List<Posts> posts = postsRepository.ListPosts();
            return View(posts);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int postId)
        {

            PostViewModel postViewModels = postsRepository.ListPostViewModel(postId);

            return View(postViewModels);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            
            List<Categories> categories = new List<Categories>();
            var myCheckBoxList = new List<CheckBoxViewCategoryModel>();
            PostViewModel postViewModel = new PostViewModel();
            categories = categoriesRepository.ListCategories();
            foreach(var item in categories)
            {
                myCheckBoxList.Add(new CheckBoxViewCategoryModel { Id = item.CategoryId, Name = item.CategoryName, Checked = false });
            }
            postViewModel.Category = myCheckBoxList;
            return View(postViewModel);
        }

        // POST: Posts/Create
        [HttpPost]
        public ActionResult Create(PostViewModel posts)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    postsRepository.AddPost(posts);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = "Error";
                    return View();
                }

            
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int postId)
        {
            PostViewModel postViewModels = postsRepository.ListPostViewModel(postId);
            var myCheckBoxList = new List<CheckBoxViewCategoryModel>();
            List<Categories> categories = categoriesRepository.ListCategories();
            foreach (var item in categories)
            {
                myCheckBoxList.Add(new CheckBoxViewCategoryModel { Id = item.CategoryId,
                    Name = item.CategoryName,
                    Checked = postsRepository.IsCheck(postId,item.CategoryId) });
            }
            postViewModels.Category = myCheckBoxList;
            return View(postViewModels);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(PostViewModel posts)
        {
            try
            {
                // TODO: Add update logic here
                postsRepository.UpdatePostRecord(posts);
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: Posts/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
              
                
                  var check=postsRepository.FindPosts(id);
                    if(check!=null)
                    {
                        // TODO: Add delete logic here
                        postsRepository.deletePost(id);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                
             
            }
            catch
            {
                return View();
            }
        }
      
    }
}
