using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    class SubdivisionRepository : GenericRepository<Subdivision>
    {
        public SubdivisionRepository(DbContext context) : base(context)
        {
        }
    }
}
