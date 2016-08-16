using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public CompanyRepository(DbContext context) : base (context){ }

    }
}
