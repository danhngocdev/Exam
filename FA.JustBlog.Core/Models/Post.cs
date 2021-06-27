using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title name is required.")]
        [StringLength(255)]
        [Display(Name ="Post title")]
        public string Title { get; set; }

        [Column("Short Description")]
        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(1024)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Content")]
        public string PostContent { get; set; }

        [Display(Name = "Meta")]
        public string Meta { get; set; }

        [StringLength(255)]
        [Display(Name = "Url")]
        public string UrlSlug { get; set; }

        public DateTime Published { get; set; }

        [Column("Posted On")]
        [Display(Name = "Posted On")]
        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual IList<Tag> Tags { get; set; }

        public int? ViewCount { get; set; }
        public int? RateCount { get; set; }
        public int? TotalRate { get; set; }

        [NotMapped]
        
        public decimal Rate
        {
            get
            {
                if (RateCount == null || RateCount == 0)
                {
                    return 0;
                }

                return Math.Round((decimal)TotalRate.Value / RateCount.Value, 2);
            }
        }

        [NotMapped]
        public string TagValues { get; set; }

        public virtual IList<Comment> Comments { get; set; }


        // Build custom SEO link
         public string BuildLink(int year,int month,string title)
        {
            return string.Format("Post/{0}/{1}/{2}", this.PostedOn.Year, this.PostedOn.Month.ToString("00"), this.UrlSlug);
        }
        public string Url => BuildLink(PostedOn.Year, (int)PostedOn.Month, UrlSlug);

        public string BuildLink_Post(int year, int month, string title)
        {
            return string.Format("{0}/{1}/{2}", this.PostedOn.Year, this.PostedOn.Month.ToString("00"), this.UrlSlug);
        }
        public string Url_Post => BuildLink_Post(PostedOn.Year, (int)PostedOn.Month, UrlSlug);

    }
}


