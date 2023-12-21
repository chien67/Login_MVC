namespace WebApp_Login.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        public int? GioiTinh { get; set; }
    }
}
