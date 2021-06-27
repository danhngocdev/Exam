using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.DTO
{
    public class PostRateDTO
    {
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public decimal Rate { get; set; }
    }
}
