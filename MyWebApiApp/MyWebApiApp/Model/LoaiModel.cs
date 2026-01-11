using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Model
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }

}
