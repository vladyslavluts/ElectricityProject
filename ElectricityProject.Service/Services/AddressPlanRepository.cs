using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    public class AddressPlanRepository : GenericRepository<AddressPlan>
    {
        public AddressPlanRepository(DbContext context) : base (context){ }

    }
}
