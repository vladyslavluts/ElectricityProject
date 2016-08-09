using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    class BuildingRepository : GenericRepository<Building>
    {
        public BuildingRepository(DbContext context) : base(context)
        {
            }
    }
}
