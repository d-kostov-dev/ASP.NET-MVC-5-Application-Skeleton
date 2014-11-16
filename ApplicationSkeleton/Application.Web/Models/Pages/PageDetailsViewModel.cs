namespace Application.Web.Models.Pages
{
    using Application.Models;
    using Application.Web.Infrastructure.Mapping;

    public class PageDetailsViewModel : IMapFrom<InfoPage>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}