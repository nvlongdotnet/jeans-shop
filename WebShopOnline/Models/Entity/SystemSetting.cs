using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShopOnline.Models.Entity
{
    [Table("tb_SystemSetting")]
    public class SystemSetting
    {
        [Key]
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 ký tự")]
        public string SettingKey { get; set; }
        [StringLength(4000, ErrorMessage = "Không được vượt quá 400 ký tự")]
        public string SettingValue { get; set; }
        [StringLength(4000, ErrorMessage = "Không được vượt quá 400 ký tự")]
        public string SettingDescription { get; set; }
    }
}