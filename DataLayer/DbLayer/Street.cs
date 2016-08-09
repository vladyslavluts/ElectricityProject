namespace ElectricityProject.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Street")]
    public partial class Street
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Street()
        {
            AddressPlans = new HashSet<AddressPlan>();
        }

        public int StreetId { get; set; }

        [Required]
        [StringLength(64)]
        public string StreetName { get; set; }

        public int StreetPrefixId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressPlan> AddressPlans { get; set; }

        public virtual StreetPrefix StreetPrefix { get; set; }
    }
}
