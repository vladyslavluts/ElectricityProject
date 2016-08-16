namespace ElectricityProject.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyTelephon")]
    public partial class CompanyTelephon
    {
        [Key]
        [Column(Order = 0)]
        public int CompanyTelephonId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Number { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(13)]
        public string FullNumber { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsMain { get; set; }
    }
}
