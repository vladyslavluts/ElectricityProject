namespace ElectricityProject.DataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Building")]
    public partial class Building
    {
        public int BuildingId { get; set; }

        public int AddressPlanId { get; set; }

        public int TypeBuildingId { get; set; }

        public int? YearConstruction { get; set; }

        public short? CountFloors { get; set; }

        [StringLength(50)]
        public string SerialBuilding { get; set; }

        public int MaterialsWall { get; set; }

        [StringLength(50)]
        public string MaterialsWallString { get; set; }

        public bool IsAccounting { get; set; }

        public bool IsPlumbing { get; set; }

        public bool IsSewerage { get; set; }

        public bool IsHeating { get; set; }

        public bool IsHotWater { get; set; }

        public bool IsGas { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Balanse { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Iznos { get; set; }

        public virtual AddressPlan AddressPlan { get; set; }

        public virtual TypeBuilding TypeBuilding { get; set; }
    }
}
