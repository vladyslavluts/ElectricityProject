using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    class TypeBuildingRepository : GenericRepository<TypeBuilding>
    {
        public TypeBuildingRepository(DbContext context) : base(context)
        {
        }
    }
}
