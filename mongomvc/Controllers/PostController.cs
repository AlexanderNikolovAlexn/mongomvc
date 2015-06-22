using mongomvc.Filters;
using mongomvc.Models;
using mongomvc.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mongomvc.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(string id)
        {
            var post = PostService.GetById(id);
            return View(post);
        }

        public ActionResult Add(Post post)
        {
            // must validate the post
            if (!String.IsNullOrEmpty(post.Title) && !String.IsNullOrEmpty(post.Body) && ModelState.IsValid)
            {       // save the post
                post.DateCreated = DateTime.Now;
                var isOk = PostService.Save(post);
                // list the post after save
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult List()
        {
            var postList = PostService.GetList();
            return View(postList);
        }

        public PartialViewResult PostComments(string postId)
        {
            List<Comment> listComments = CommentService.getList(postId);
            return PartialView("_Comments", listComments);
        }

        [HttpGet]
        public PartialViewResult AddComment(String postId)
        {
            Comment comment = new Comment();
            comment.PostId = postId;
            return PartialView("_AddComment", comment);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            comment.DateCreated = DateTime.Now;
            CommentService.Save(comment);
            var listComments = CommentService.getList(comment.PostId);
            return PartialView("_ListComments", listComments);
        }

        [HttpGet]
        public PartialViewResult ListComments(String postId)
        {
            // call service here
            var listComments = CommentService.getList(postId);
            return PartialView("_ListComments", listComments);
        }
        
    }
}