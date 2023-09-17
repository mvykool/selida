using Microsoft.AspNetCore.Mvc;
using selida.Data;
using selida.Models.Domain;
using selida.Models.ViewModels;

namespace selida.Controllers
{
    public class AdminTagController : Controller
    {
        private readonly SelidaDbContext selidaDbContext;

        public AdminTagController(SelidaDbContext selidaDbContext)
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
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.displayName
            };

            selidaDbContext.Tags.Add(tag);
            selidaDbContext.SaveChanges();

            return View("Add");
        }
    }
}
