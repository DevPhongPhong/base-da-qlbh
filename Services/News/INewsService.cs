using Entities.Common;
using Entities.DTOs;
using Entities.Models;
using System.Collections.Generic;

namespace Services.News
{
    public interface INewsService
    {
        IEnumerable<NewsViewModel> GetListNews();
        NewsViewModel GetNews(int id);
        bool InsertOrUpdateNews(NewsViewModel model);
        bool DeleteNews(int id);
        List<NewsViewModel> GetRandomHotNewses(int take);
        List<NewsViewModel> GetRecentNewses(int take);
        PaginationModel<List<NewsViewModel>> GetHomeNewses(RequestHomeViewModel request);
    }
}
