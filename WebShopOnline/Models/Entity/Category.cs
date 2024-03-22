using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShopOnline.Models.Entity
{
    [Table("tb_Category")]
    public class Category : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Title { get; set; }
        public string Alias { get; set; }
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string TypeCode { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string SeoTitle { get; set; }
        [StringLength(250, ErrorMessage = "Không được vượt quá 250 ký tự")]
        public string SeoDescription { get; set; }
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public Category()
        {
            this.News = new HashSet<News>();
            this.Posts = new HashSet<Posts>();
        }
    }
}