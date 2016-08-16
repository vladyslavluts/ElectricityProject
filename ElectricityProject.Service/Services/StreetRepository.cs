using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    public class StreetRepository : GenericRepository<StreetPrefix>
    {
        public StreetRepository(DbContext context) : base(context)
        {
        }
    }
}
