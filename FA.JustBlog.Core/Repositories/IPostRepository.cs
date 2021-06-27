using FA.JustBlog.Core.DTO;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Post Find(int year, int month, string urlSlug);
        IList<Post> GetPublishedPosts();
        IList<Post> GetUnpublishedPosts();
        IList<Post> GetAllPosts();
        IList<Post> GetLatestPost(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);
        // New Methods
        IList<Post> GetMostViewedPost(int size);
        IList<PostRateDTO> GetHighestPosts(int size);

        List<PostRateModel> GetHighestPost(int size);
    }
}
