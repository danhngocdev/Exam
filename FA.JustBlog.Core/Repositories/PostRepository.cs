using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.DTO;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository()
        {
        }
        public PostRepository(JustBlogContext context) : base(context)
        {
        }
        public int CountPostsForCategory(string category)
        {
            return _base.Posts.Include(p => p.Category).Where(p => p.Category.Name == category).Count();
        }

        public int CountPostsForTag(string tag)
        {
            return _base.Posts.Where(p => p.Tags.Any(t => t.Name == tag)).Count();
        }

        public Post Find(int year, int month, string urlSlug)
        {
            return _base.Posts.Include(p => p.Category).FirstOrDefault(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
        }
        public IList<Post> GetAllPosts()
        {
            return _base.Posts.ToList();
        }
        public IList<Post> GetLatestPost(int size)
        {
            List<Post> results = _base.Posts.OrderByDescending(p => p.PostedOn).Take(size).ToList();
            return results;
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return _base.Posts.Where(p => p.Category.Name == category).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _base.Posts.Where(p => p.PostedOn.Year == monthYear.Year && p.PostedOn.Month == monthYear.Month).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return _base.Posts.Where(p => p.Tags.Any(t => t.Name == tag)).ToList();
        }

        public IList<Post> GetPublishedPosts()
        {
            return _base.Posts.Where(p => p.Published <= DateTime.Now).ToList();
        }

        public IList<Post> GetUnpublishedPosts()
        {
            return _base.Posts.Where(p => p.Published > DateTime.Now).ToList();
        }

        // New Methods
        public IList<Post> GetMostViewedPost(int size)
        {
            return _base.Posts.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<PostRateDTO> GetHighestPosts(int size)
        {
            List<PostRateDTO> results = _base.Posts.Select(p => new PostRateDTO()
            {
                Title = p.Title,
                ShortDesc = p.ShortDescription,
                Content = p.PostContent,
                ViewCount = p.ViewCount.Value,
                RateCount = p.RateCount.Value,
                TotalRate = p.TotalRate.Value,
                Rate = (p.RateCount == 0) ? 0 : (decimal)p.TotalRate.Value / p.RateCount.Value

            }).OrderByDescending(P => P.Rate).Take(size).ToList();
            return results;
        }

        public List<PostRateModel> GetHighestPost(int size)
        {
            List<PostRateModel> results = _base.Posts.Select(p => new PostRateModel()
            {
                Title = p.Title,
                ShortDesc = p.ShortDescription,
                Content = p.PostContent,
                ViewCount = p.ViewCount.Value,
                RateCount = p.RateCount.Value,
                TotalRate = p.TotalRate.Value,
                Rate = (p.RateCount == 0) ? 0 : (decimal)p.TotalRate.Value / p.RateCount.Value

            }).OrderByDescending(P => P.Rate).Take(size).ToList();
            return results;

        }
    }
}