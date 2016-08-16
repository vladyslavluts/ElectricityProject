namespace ElectricityProject.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [Key]
        [Column(Order = 0)]
        public int CompanyId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string CompanyNameFull { get; set; }

        [StringLength(128)]
        public string ReestrArendator { get; set; }

        [StringLength(128)]
        public string PositionManager { get; set; }

        [StringLength(128)]
        public string Manager { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string LegalAddress { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TelephonId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(24)]
        public string Edrpou { get; set; }

        [StringLength(20)]
        public string NumberPlat { get; set; }

        [StringLength(20)]
        public string Svid { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(192)]
        public string PostalAddress { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(12)]
        public string PostalIndex { get; set; }

        public int? BankId { get; set; }
    }
}
