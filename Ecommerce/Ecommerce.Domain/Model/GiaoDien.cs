namespace Ecommerce.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoDien")]
    public partial class GiaoDien
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string ThuocTinh { get; set; }

        [Column(TypeName = "ntext")]
        public string GiaTri { get; set; }
    }
}
