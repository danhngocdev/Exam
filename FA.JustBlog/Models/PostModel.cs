using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int RateTotal { get; set; }
        public decimal Rate { get; set; }
        public string UrlSlug { get; set; }
        public List<Post> posts { get; set; }

    }
}