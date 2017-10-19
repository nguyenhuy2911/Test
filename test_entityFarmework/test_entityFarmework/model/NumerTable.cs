namespace test_entityFarmework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NumerTable")]
    public partial class NumerTable
    {
        public int Id { get; set; }

        public int? Number { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
