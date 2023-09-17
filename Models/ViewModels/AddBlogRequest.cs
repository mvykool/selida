namespace selida.Models.ViewModels
{
    public class AddBlogRequest
    {
        public string Heading { get; set; }

        public string PageTitle { get; set; }

        public string Content { get; set; }

        public string ShortDescription { get; set; }

        public string FeatureImageUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
    }
}
