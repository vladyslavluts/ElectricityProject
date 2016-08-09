namespace ElectricityProject.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddressPlan")]
    public partial class AddressPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddressPlan()
        {
            Buildings = new HashSet<Building>();
        }

        public int AddressPlanId { get; set; }

        public int? SubdivisionId { get; set; }

        public int? CompanyServiceId { get; set; }

        public int StreetId { get; set; }

        [Required]
        [StringLength(12)]
        public string House { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool IsAccounting { get; set; }

        [StringLength(12)]
        public string CodePostal { get; set; }

        [StringLength(512)]
        public string remarks { get; set; }

        public virtual Street Street { get; set; }

        public virtual Subdivision Subdivision { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
