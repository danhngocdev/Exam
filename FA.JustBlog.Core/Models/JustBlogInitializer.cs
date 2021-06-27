using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class JustBlogInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        // Sample
        //        protected override void Seed(JustBlogContext context)
        //        {
        //            Category category = new Category() { Name = "Entity Framework", Description = "All post in Entity Framework", UrlSlug = "entity framework" };
        //            Post post = new Post()
        //            {
        //                Category = category,
        //                Title = "Data Annotations - InverseProperty Attribute in EF 6 & EF Core",
        //                ShortDescription = "The InverseProperty attribute is used when two entities have more than one relationship. To understand the InverseProperty attribute, consider the following example of Course and Teacher entities.",
        //                Modified = DateTime.Now,
        //                PostedOn = DateTime.Now,
        //                PostContent = @"In the above example, the Course and Teacher entities have two one-to-many relationships. A Course can be taught by an online teacher as well as a class-room teacher. In the same way, a Teacher can teach multiple online courses as well as class room courses.

        //Here,
        //                EF API cannot determine the other end of the relationship.It will throw the following exception for the above example during migration.


        //         Unable to determine the relationship represented by navigation property 'Course.OnlineTeacher' of type 'Teacher'.Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.

        //        However, EF 6 will create the following Courses table with four foreign keys.",
        //                Published = true,
        //                RateCount = 10,
        //                TotalRate = 45,
        //                UrlSlug = "data annotation inverse property attribule in ef 6",
        //                ViewCount = 100,
        //                Tags = new List<Tag>() {
        //                    new Tag() {
        //                        Name = "Entity Framework",
        //                        Description = "Entity Framework",
        //                        Count = 100,
        //                        UrlSlug = "entity framework" } ,
        //                new Tag() {
        //                        Name = "MVC",
        //                        Description = "Microsoft MVC",
        //                        Count = 50,
        //                        UrlSlug = "mvc" } },
        //            };

        //            context.Categories.Add(category);
        //            context.Posts.Add(post);

        //            Comment comment = new Comment()
        //            {
        //                Post = post,
        //                Name = "Scott Trinh",
        //                Email = "tutb@live.com",
        //                CommentTime = DateTime.Now,
        //                CommentHeader = "This is sample comment",
        //                CommentText = @"This is sample comment with 

        //        multiple lines"
        //            };

        //            context.Comments.Add(comment);

        //            context.SaveChanges();
        //            base.Seed(context);
        //        }
        protected override void Seed(JustBlogContext context)
        {
            IList<Category> categories = new List<Category>
            {
                new Category() { Name = "Culture", Description = "Welcome to Culture zone", UrlSlug = "culture" },
                new Category() { Name = "Food", Description = "Welcome to Food zone", UrlSlug = "food" },
                new Category() { Name = "Technology", Description = "Welcome to Tech zone", UrlSlug = "tech" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            IList<Post> posts = new List<Post>
            {
                new Post()
                {
                    Category = context.Categories.Find(1),
                    Title = "The first title",
                    ShortDescription = "This is the very short description for title #1",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2011,10,1),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2011,10,1),
                    RateCount = 8,
                    TotalRate = 15,
                    Meta = "-",
                    UrlSlug = "post-01",
                    ViewCount = 100,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 01",
                            Description = "Tag description 01",
                            Count = 100,
                            UrlSlug = "tag01" } ,
                    new Tag() {
                            Name = "Tag 02",
                            Description = "Tag description 02",
                            Count = 50,
                            UrlSlug = "tag02" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(2),
                    Title = "The second title",
                    ShortDescription = "This is the very short description for title #2",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2012,2,13),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2012,2,13),
                    RateCount = 5,
                    TotalRate = 25,
                    Meta = "-",
                    UrlSlug = "post-02",
                    ViewCount = 150,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 03",
                            Description = "Tag description 03",
                            Count = 100,
                            UrlSlug = "tag03" } ,
                    new Tag() {
                            Name = "Tag 04",
                            Description = "Tag description 04",
                            Count = 50,
                            UrlSlug = "tag04" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(1),
                    Title = "The third title",
                    ShortDescription = "This is the very short description for title #3",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2016,6,13),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2016,6,13),
                    RateCount = 10,
                    TotalRate = 45,
                    Meta = "-",
                    UrlSlug = "post-03",
                    ViewCount = 80,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 05",
                            Description = "Tag description 05",
                            Count = 100,
                            UrlSlug = "tag05" } ,
                    new Tag() {
                            Name = "Tag 06",
                            Description = "Tag description 06",
                            Count = 50,
                            UrlSlug = "tag06" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(1),
                    Title = "The forth title",
                    ShortDescription = "This is the very short description for title #4",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2018,9,4),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2018,9,4),
                    RateCount = 16,
                    TotalRate = 27,
                    Meta = "-",
                    UrlSlug = "post-04",
                    ViewCount = 88,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 07",
                            Description = "Tag description 07",
                            Count = 95,
                            UrlSlug = "tag07" } ,
                    new Tag() {
                            Name = "Tag 08",
                            Description = "Tag description 08",
                            Count = 50,
                            UrlSlug = "tag08" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(3),
                    Title = "The fifth title",
                    ShortDescription = "This is the very short description for title #5",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2017,3,2),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2017,3,2),
                    RateCount = 36,
                    TotalRate = 45,
                    Meta = "-",
                    UrlSlug = "post-05",
                    ViewCount = 78,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 09",
                            Description = "Tag description 09",
                            Count = 47,
                            UrlSlug = "tag09" },
                        new Tag() {
                            Name = "Tag 10",
                            Description = "Tag description 10",
                            Count = 82,
                            UrlSlug = "tag10" }
                     },
                },
                new Post()
                {
                    Category = context.Categories.Find(1),
                    Title = "The sixth title",
                    ShortDescription = "This is the very short description for title #6",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2020,8,15),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2020,8,15),
                    RateCount = 6,
                    TotalRate = 25,
                    Meta = "-",
                    UrlSlug = "post-06",
                    ViewCount = 100,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 11",
                            Description = "Tag description 11",
                            Count = 56,
                            UrlSlug = "tag11" } ,
                    new Tag() {
                            Name = "Tag 12",
                            Description = "Tag description 12",
                            Count = 76,
                            UrlSlug = "tag12" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(2),
                    Title = "The seventh title",
                    ShortDescription = "This is the very short description for title #7",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2015,12,1),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2015,12,1),
                    RateCount = 18,
                    TotalRate = 34,
                    Meta = "-",
                    UrlSlug = "post-07",
                    ViewCount = 100,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 13",
                            Description = "Tag description 13",
                            Count = 100,
                            UrlSlug = "tag13" } ,
                    new Tag() {
                            Name = "Tag 14",
                            Description = "Tag description 14",
                            Count = 50,
                            UrlSlug = "tag14" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(1),
                    Title = "The eighth title",
                    ShortDescription = "This is the very short description for title #8",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2002,1,11),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2002,1,11),
                    RateCount = 20,
                    TotalRate = 18,
                    Meta = "-",
                    UrlSlug = "post-08",
                    ViewCount = 100,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 15",
                            Description = "Tag description 15",
                            Count = 10,
                            UrlSlug = "tag15" } ,
                    new Tag() {
                            Name = "Tag 16",
                            Description = "Tag description 16",
                            Count = 7,
                            UrlSlug = "tag16" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(2),
                    Title = "The ninth title",
                    ShortDescription = "This is the very short description for title #9",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2019,7,27),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2019,7,27),
                    RateCount = 4,
                    TotalRate = 19,
                    Meta = "-",
                    UrlSlug = "post-09",
                    ViewCount = 100,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 17",
                            Description = "Tag description 17",
                            Count = 100,
                            UrlSlug = "tag17" } ,
                    new Tag() {
                            Name = "Tag 18",
                            Description = "Tag description 18",
                            Count = 32,
                            UrlSlug = "tag18" } },
                },
                new Post()
                {
                    Category = context.Categories.Find(3),
                    Title = "The tenth title",
                    ShortDescription = "This is the very short description for title #10",
                    Modified = DateTime.Now,
                    PostedOn = new DateTime(2009,10,5),
                    PostContent = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Published = new DateTime(2009,10,5),
                    RateCount = 2,
                    TotalRate = 4,
                    Meta = "-",
                    UrlSlug = "post-10",
                    ViewCount = 110,
                    Tags = new List<Tag>() {
                        new Tag() {
                            Name = "Tag 19",
                            Description = "Tag description 19",
                            Count = 100,
                            UrlSlug = "tag19" } ,
                    new Tag() {
                            Name = "Tag 20",
                            Description = "Tag description 20",
                            Count = 50,
                            UrlSlug = "tag20" } },
                },
            };
            context.Posts.AddRange(posts);
            context.SaveChanges();

            //IList<Tag> tags = new List<Tag>
            //{
            //    new Tag() { Name = "Tag 1", UrlSlug = "tag-1", Description = "First Tag" },
            //    new Tag() { Name = "Tag 2", UrlSlug = "tag-2", Description = "Second Tag" },
            //    new Tag() { Name = "Tag 3", UrlSlug = "tag-3", Description = "Third Tag" }
            //};
            //context.Tags.AddRange(tags);
            //context.SaveChanges();

            IList<Comment> comments = new List<Comment>
            {
                new Comment()
                {
                    Post = context.Posts.Find(1),
                    Name = "Jack Ma",
                    Email = "jackma@gmail.com",
                    CommentTime = DateTime.Now,
                    CommentHeader = "This is sample comment #1",
                    CommentText = "This is sample comment with multiple lines #1"
                },
                new Comment()
                {
                    Post = context.Posts.Find(2),
                    Name = "Barron Pools",
                    Email = "barr@live.com",
                    CommentTime = DateTime.Now,
                    CommentHeader = "This is sample comment #2",
                    CommentText = "This is sample comment with multiple lines #2"
                },
                    new Comment()
                {
                    Post = context.Posts.Find(3),
                    Name = "Will Smith",
                    Email = "will@hotmail.com",
                    CommentTime = DateTime.Now,
                    CommentHeader = "This is sample comment #3",
                    CommentText = "This is sample comment with multiple lines #3"
                }
            };
            context.Comments.AddRange(comments);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
