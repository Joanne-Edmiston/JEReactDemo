using ReactDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;


        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    ID = 1,
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!",
                },
                new CommentModel
                {
                    ID = 2,
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new CommentModel
                {
                    ID = 3,
                    Author = "Jordan Walke",
                    Text = "This is *another* comment",
                },
            };
            
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddComment(CommentModel comment)
        {
            // Create a fake ID for this comment
            comment.ID = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }
    }
}