using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string PostContent { get; set; }

        [Required]
        [Display(Name = "URL")]
        public string UrlSlug { get; set; }

        [Display(Name = "Posted on")]
        [DataType(DataType.DateTime)]
        public DateTime PostedOn { get; set; }

        [Display(Name = "Is published?")]
        public bool Published { get; set; }

        [Display(Name = "Is modified?")]
        public bool Modified { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Rating")]
        public decimal Rate { get; set; }

        [Display(Name = "Views")]
        public int ViewCount { get; set; }
    }
}
