using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository()
        {
        }
        public CommentRepository(JustBlogContext context) : base(context)
        {

        }
        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var targerPost = _base.Posts.Find(postId);
            Comment item = new Comment()
            {
                Post = targerPost,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };
            _base.Comments.Add(item);
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _base.Comments.Where(p => p.Post.Id == postId).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return _base.Comments.Where(p => p.Post.Id == post.Id).ToList();
        }
    }
}
