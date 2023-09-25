using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using selida.Data;
using selida.Models.Domain;
using System.Reflection.Metadata;

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

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var post = selidaDbContext.BlogPosts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View("Edit", post);
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Edit(Guid id, BlogPost editBlogRequest)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var post = selidaDbContext.BlogPosts.Find(id);

            if (post == null)
            {
                return NotFound();
            }
            else
            {
                // Update the post properties with values from the editBlogRequest.
                post.Heading = editBlogRequest.Heading;
                post.PageTitle = editBlogRequest.PageTitle;
                post.Content = editBlogRequest.Content;
                post.ShortDescription = editBlogRequest.ShortDescription;
                post.FeatureImageUrl = editBlogRequest.FeatureImageUrl;
                post.PublishDate = editBlogRequest.PublishDate;
                post.Author = editBlogRequest.Author;
            }
            

            // Save changes to the database.
            selidaDbContext.BlogPosts.Add(post);
            selidaDbContext.SaveChanges();

            return View("Edit");

        }

        //PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<BlogPost>> UpdateBlog(Guid id, BlogPost editBlogRequest)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid post ID");
            }

            var post = await selidaDbContext.BlogPosts.FindAsync(id);

            if (post == null)
            {
                return NotFound("Post not found");
            }

            post.Heading = editBlogRequest.Heading;
            post.PageTitle = editBlogRequest.PageTitle;
            post.Content = editBlogRequest.Content;
            post.ShortDescription = editBlogRequest.ShortDescription;
            post.FeatureImageUrl = editBlogRequest.FeatureImageUrl;
            post.PublishDate = editBlogRequest.PublishDate;
            post.Author = editBlogRequest.Author;

            await selidaDbContext.SaveChangesAsync();

            return Ok(post);
        }

    }
}
