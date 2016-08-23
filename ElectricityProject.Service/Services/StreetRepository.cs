using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    public class StreetRepository : GenericRepository<Street>
    {
        public StreetRepository(DbContext context) : base(context)
        {
        }
    }
}
