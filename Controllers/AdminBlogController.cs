using Microsoft.AspNetCore.Mvc;
using selida.Data;
using selida.Models.Domain;
using selida.Models.ViewModels;

namespace selida.Controllers
{
    public class AdminBlogController : Controller
    {
        private readonly SelidaDbContext selidaDbContext;

        public AdminBlogController(SelidaDbContext selidaDbContext)
        {
            this.selidaDbContext = selidaDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddBlogRequest addBlogRequest)
        {
            var blog = new BlogPost
            {
                Heading = addBlogRequest.Heading,
                PageTitle = addBlogRequest.PageTitle,
                Content = addBlogRequest.Content,
                ShortDescription = addBlogRequest.ShortDescription,
                FeatureImageUrl = addBlogRequest.FeatureImageUrl,
                PublishDate = addBlogRequest.PublishDate,
                Author = addBlogRequest.Author,
            };

            selidaDbContext.BlogPosts.Add(blog);
            selidaDbContext.SaveChanges();

            return View("Add");
        }
    }
}
