using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShopOnline.Models.Entity
{
    [Table("tb_Contact")]
    public class Contact : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(10, ErrorMessage = "Không được vượt quá 10 ký tự")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage ="Vui lòng nhập đúng định dạng Email")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Email { get; set; }
        public string Website { get; set; }
        [StringLength(4000, ErrorMessage = "Không được vượt quá 4000 ký tự")]
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}