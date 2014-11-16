namespace Application.Web.Models.Pages
{
    using Application.Models;
    using Application.Web.Infrastructure.Mapping;

    public class PagesFooterViewModel : IMapFrom<InfoPage>
    {
        public string SeoUrl { get; set; }

        public string Title { get; set; }
    }
}