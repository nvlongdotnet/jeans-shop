using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShopOnline.Models.Entity
{
    [Table("tb_Adv")]
    public class Adv : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Title { get; set; }
        [StringLength(4000, ErrorMessage = "Không được vượt quá 4000 ký tự")]

        public string Description { get; set; }
        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]

        public string Image { get; set; }
        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string Link { get; set; }
        public int Type { get; set; }
    }
}