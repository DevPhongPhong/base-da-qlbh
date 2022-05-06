using Entities.DTOs;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Ultilities;
using Entities.Common;

namespace Services.News
{
    public class NewsService : INewsService
    {
        private readonly CMS_DBContext context;
        public NewsService(CMS_DBContext _context)
        {
            context = _context;
        }
        public bool DeleteNews(int id)
        {
            var exist = context.Newses.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (exist == null) return false;
            else
            {
                context.Newses.Remove(exist);
                return context.SaveChanges() > 0;
            }
        }

        public NewsViewModel GetNews(int id)
        {
            var CategoryNewses = context.CategoryNewses.AsQueryable();
            var Newses = context.Newses.AsQueryable();
            var query = from a in Newses

                        join b in CategoryNewses on a.CategoryId equals b.Id into bTemp
                        from bRes in bTemp.DefaultIfEmpty()

                        select new NewsViewModel
                        {
                            Id = a.Id,
                            Author = a.Author,
                            CategoryId = a.CategoryId,
                            CategoryName = bRes.CategoryName,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            IsView = a.IsView,
                            LargeImage = a.LargeImage,
                            MetaUrl = a.MetaUrl,
                            NewsContent = a.NewsContent,
                            NewsOrder = a.NewsOrder,
                            PostedDate = a.PostedDate,
                            SubTitle = a.SubTitle,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            ThumbImage = a.ThumbImage,
                            Title = a.Title,
                            Tags = a.Tags
                        };
            return query.AsEnumerable().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<NewsViewModel> GetListNews()
        {
            var CategoryNewses = context.CategoryNewses.AsQueryable();
            var Newses = context.Newses.AsQueryable();
            var query = from a in Newses

                        join b in CategoryNewses on a.CategoryId equals b.Id into bTemp
                        from bRes in bTemp.DefaultIfEmpty()

                        select new NewsViewModel
                        {
                            Id = a.Id,
                            Author = a.Author,
                            CategoryId = a.CategoryId,
                            CategoryName = bRes.CategoryName,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            IsView = a.IsView,
                            LargeImage = a.LargeImage,
                            MetaUrl = a.MetaUrl,
                            NewsContent = a.NewsContent,
                            NewsOrder = a.NewsOrder,
                            PostedDate = a.PostedDate,
                            SubTitle = a.SubTitle,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            ThumbImage = a.ThumbImage,
                            Title = a.Title,
                            Tags = a.Tags
                        };
            return query.OrderByDescending(x => x.CreatedDate).AsEnumerable();
        }

        public bool InsertOrUpdateNews(NewsViewModel model)
        {
            try
            {
                var Newses = context.Newses.AsQueryable();
                if (model.Id > 0)
                {
                    var exist = Newses.FirstOrDefault(x => x.Id == model.Id);
                    if (exist != null)
                    {
                        PropertyCopy.Copy(model, exist);
                        context.Newses.Update(exist);
                        return context.SaveChanges() > 0;
                    }
                    else return false;
                }
                else
                {
                    var newData = new Entities.Models.News();
                    PropertyCopy.Copy(model, newData);
                    context.Newses.Add(newData);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public List<NewsViewModel> GetRandomHotNewses(int take)
        {
            var CategoryNewses = context.CategoryNewses.AsQueryable();
            var Newses = context.Newses.AsQueryable();
            var query = from a in Newses
                        where a.IsHot == true
                        join b in CategoryNewses on a.CategoryId equals b.Id into bTemp
                        from bRes in bTemp.DefaultIfEmpty()

                        select new NewsViewModel
                        {
                            Id = a.Id,
                            Author = a.Author,
                            CategoryId = a.CategoryId,
                            CategoryName = bRes.CategoryName,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            IsView = a.IsView,
                            LargeImage = a.LargeImage,
                            MetaUrl = a.MetaUrl,
                            NewsContent = a.NewsContent,
                            NewsOrder = a.NewsOrder,
                            PostedDate = a.PostedDate,
                            SubTitle = a.SubTitle,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            ThumbImage = a.ThumbImage,
                            Title = a.Title,
                            Tags = a.Tags
                        };
            return query.OrderByDescending(x => x.CreatedDate).Take(take).ToList();
        }
        public PaginationModel<List<NewsViewModel>> GetHomeNewses(RequestHomeViewModel request)
        {
            try
            {
                if (!request.Offset.HasValue)
                {
                    request.Offset = 0;
                }
                if (request.Offset > 0)
                {
                    request.Offset -= 1;
                }

                if (!request.Size.HasValue)
                {
                    request.Size = 9;
                }

                PaginationModel<List<NewsViewModel>> res = new PaginationModel<List<NewsViewModel>>();

                res.Pagination.Offset = request.Offset.Value;
                res.Pagination.Size = request.Size.Value;

                var CategoryNewses = context.CategoryNewses.AsQueryable();
                var Newses = context.Newses.AsQueryable();
                var query = from a in Newses
                            join b in CategoryNewses on a.CategoryId equals b.Id into bTemp
                            from bRes in bTemp.DefaultIfEmpty()

                            select new NewsViewModel
                            {
                                Id = a.Id,
                                Author = a.Author,
                                CategoryId = a.CategoryId,
                                CategoryName = bRes.CategoryName,
                                CreatedBy = a.CreatedBy,
                                CreatedDate = a.CreatedDate,
                                IsHome = a.IsHome,
                                IsHot = a.IsHot,
                                IsView = a.IsView,
                                LargeImage = a.LargeImage,
                                MetaUrl = a.MetaUrl,
                                NewsContent = a.NewsContent,
                                NewsOrder = a.NewsOrder,
                                PostedDate = a.PostedDate,
                                SubTitle = a.SubTitle,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedDate = a.ModifiedDate,
                                ThumbImage = a.ThumbImage,
                                Title = a.Title,
                                Tags = a.Tags,
                                currentCategoryId = request.categoryId,
                                CategoryNews = context.CategoryNewses.FirstOrDefault(x=>x.Id == request.categoryId)
                            };

                if (request.categoryId > 0)
                {
                    query = query.Where(x => x.CategoryId == request.categoryId);
                }

                var count = query.Count();
                var data = query.OrderByDescending(x => x.CreatedDate).Skip((int)request.Offset * (int)request.Size).Take((int)request.Size).ToList();
                res.Pagination.Total = count;
                res.Data = data;

                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<NewsViewModel> GetRecentNewses(int take)
        {
            var CategoryNewses = context.CategoryNewses.AsQueryable();
            var Newses = context.Newses.AsQueryable();
            var query = from a in Newses
                        join b in CategoryNewses on a.CategoryId equals b.Id into bTemp
                        from bRes in bTemp.DefaultIfEmpty()

                        select new NewsViewModel
                        {
                            Id = a.Id,
                            Author = a.Author,
                            CategoryId = a.CategoryId,
                            CategoryName = bRes.CategoryName,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            IsView = a.IsView,
                            LargeImage = a.LargeImage,
                            MetaUrl = a.MetaUrl,
                            NewsContent = a.NewsContent,
                            NewsOrder = a.NewsOrder,
                            PostedDate = a.PostedDate,
                            SubTitle = a.SubTitle,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            ThumbImage = a.ThumbImage,
                            Title = a.Title,
                            Tags = a.Tags
                        };
            return query?.OrderByDescending(x => x.CreatedDate).Take(take).ToList();
        }
    }
}
