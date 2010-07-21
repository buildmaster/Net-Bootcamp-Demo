using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SummerOfTech_Bootcamp.Models;

namespace SummerOfTech_Bootcamp.Controllers
{
    public class PostController : Controller
    {
        private Models.BlogDataContext _blogContext;
        public PostController()
        {
            this._blogContext = new Models.BlogDataContext("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\Blog.mdf\";Integrated Security=True;User Instance=True");
        }

        //
        // GET: /Post/

        public ViewResult Index()
        {
            return View(_blogContext.Posts.Select(post=>post.ToViewModel()));
        }

        // GET: /New/
        [AcceptVerbs(HttpVerbs.Get)]
        public ViewResult New()
        {
            return View(new Post().ToViewModel());
        }

        //POST: /New/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult New(Post post)
        {
            if (ModelState.IsValid)
            {
                _blogContext.Posts.InsertOnSubmit(post);
                _blogContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(post.ToViewModel());
            }
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Edit(int id)
        {
            var post = _blogContext.Posts.Single(p => p.Id == id);
            return View(post.ToViewModel());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var existingPost = _blogContext.Posts.Single(p => p.Id == post.Id);
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                _blogContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            else{
                return View(post);
            }
        }
    }

}
