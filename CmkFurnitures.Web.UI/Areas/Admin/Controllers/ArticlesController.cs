using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Domain;
using CmkFurnitures.Web.UI.Areas.Admin.Models;
using AutoMapper;

namespace CmkFurnitures.Web.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class ArticlesController : BaseController
    {
        protected IArticleService ArticleService;

        public ArticlesController(IArticleService articleService)
        {
            this.ArticleService = articleService;
        }

        //
        // GET: /Admin/Articles/

        public ActionResult Index()
        {
            IEnumerable<Article> articles = ArticleService.GetAll();

            return View(new IndexArticlesViewModel
            {
                Articles = articles
            });
        }

        //
        // GET: /Admin/Articles/Create

        public ActionResult Create()
        {
            Article article = new Article();

            return View(new CreateArticlesViewModel
            {
                ArticleForm = new ArticleFormViewModel(){
                    AuthorName = User.Identity.FirstName + " " + User.Identity.LastName
                }
            });
        }

        //
        // POST: /Admin/Articles/Create

        [HttpPost]
        public ActionResult Create(CreateArticlesViewModel requestedViewModel)
        {
            if (ModelState.IsValid)
            {
                Article article = ArticleService.Create(requestedViewModel.ArticleForm.Title, requestedViewModel.ArticleForm.Text, DateTime.UtcNow, User.Identity.AdminId);
                return RedirectToAction("Update", new { id = article.ArticleId });
            }

            requestedViewModel.ArticleForm.AuthorName = User.Identity.FirstName + " " + User.Identity.LastName;
            return View(requestedViewModel);
        }

        //
        // GET: /Admin/Articles/Update/1

        public ActionResult Update(int id)
        {
            Article article = ArticleService.GetById(id);

            return View(new UpdateArticlesViewModel
            {
                Article = article,
                ArticleForm = new ArticleFormViewModel
                {
                    Text = article.Text,
                    Title = article.Title,
                    AuthorName = User.Identity.FirstName + " " + User.Identity.LastName
                }
            });
        }

        //
        // POST: /Admin/Articles/Update/1

        [HttpPost]
        public ActionResult Update(int id, UpdateArticlesViewModel requestedViewModel)
        {
            if (ModelState.IsValid)
            {
                Article article = ArticleService.Update(id, requestedViewModel.ArticleForm.Title, requestedViewModel.ArticleForm.Text);
                return RedirectToAction("Update", new { id = article.ArticleId });
            }

            requestedViewModel.Article = ArticleService.GetById(id);
            requestedViewModel.ArticleForm.AuthorName = User.Identity.FirstName + " " + User.Identity.LastName;

            return View(requestedViewModel);
        }


        public ActionResult Delete(int id)
        {
            ArticleService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
