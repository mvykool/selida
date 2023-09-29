using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        // GET: Posts with Id
        public ActionResult Details(Guid id)
        {
            var post = selidaDbContext.BlogPosts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound(); // Return a 404 Not Found response if the post doesn't exist.
            }

            return View(post);
        }

    }
}
