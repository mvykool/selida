using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using selida.Data;

namespace selida.Controllers
{
    public class Posts : Controller
    {

        private readonly SelidaDbContext selidaDbContext;

        public Posts(SelidaDbContext selidaDbContext)
        {
            this.selidaDbContext = selidaDbContext;
        }

        [HttpGet]
        // GET: Posts
        public ActionResult PostsView()
        {

            var posts = selidaDbContext.BlogPosts;
            return View(posts);
  
        }
    }
}
