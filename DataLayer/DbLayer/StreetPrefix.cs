namespace ElectricityProject.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StreetPrefix")]
    public partial class StreetPrefix
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StreetPrefix()
        {
            Streets = new HashSet<Street>();
        }

        public int StreetPrefixId { get; set; }

        [StringLength(16)]
        public string StreetPrefixName { get; set; }

        public bool IsAfter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Street> Streets { get; set; }
    }
}
