using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;


namespace ElectricityProject.Service.Services
{
    public class CompanyTelephonRepository : GenericRepository<CompanyTelephon>
    {
        public CompanyTelephonRepository(DbContext context) : base (context){ }

    }
}
