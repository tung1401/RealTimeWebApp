using RealTimeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeWebApp.Services
{
    public class MapServices
    {
        private readonly MyMapContext _dbContext = new MyMapContext();
        public List<LocationMap> GetAll()
        {
            var query = _dbContext.LocationMap.ToList();
            return query;
        }

        public void Add(LocationMap entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
