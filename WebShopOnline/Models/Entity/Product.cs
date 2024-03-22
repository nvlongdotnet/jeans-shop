using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopOnline.Models.Entity
{
    [Table("tb_Product")]
    public class Product:CommonAbstract
    {
        public Product() {
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 ký tự")]
        public string ProductCode {  get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public int CountView { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }
        [StringLength(250, ErrorMessage = "Không được vượt quá 250 ký tự")]
        public string SeoTitle { get; set; }
        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string SeoDescription { get; set; }
        [StringLength(250, ErrorMessage = "Không được vượt quá 250 ký tự")]
        public string SeoKeywords { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}