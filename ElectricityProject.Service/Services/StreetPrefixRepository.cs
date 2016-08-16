using ElectricityProject.DataLayer.DbLayer;
using ElectricityProject.Repository.Repositories;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityProject.Service.Services
{
    public class StreetPrefixRepository : GenericRepository<StreetPrefix>
    {
        public StreetPrefixRepository(DbContext context) : base(context)
        {
        }
    }
}
