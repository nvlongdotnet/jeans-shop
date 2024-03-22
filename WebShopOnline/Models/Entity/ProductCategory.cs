using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShopOnline.Models.Entity
{
    [Table("tb_ProductCategory")]
    public class ProductCategory : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Title { get; set; }
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Alias { get; set; }
        public string Description { get; set; }
        [StringLength(250, ErrorMessage = "Không được vượt quá 250 ký tự")]
        public string Icon { get; set; }
        [StringLength(250, ErrorMessage = "Không được vượt quá 250 ký tự")]
        public string SeoTitle { get; set; }
        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string SeoDescription { get; set; }
        [StringLength(250, ErrorMessage = "Không được vượt quá 250 ký tự")]
        public string SeoKeywords { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
    }
}