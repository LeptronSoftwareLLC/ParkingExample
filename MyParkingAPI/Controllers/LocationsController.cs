using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyParkingAPI.Controllers.Repo;
using MyParkingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyParkingAPI.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IParkingRepo _parkingRepo;
        public LocationsController(IParkingRepo repo)
        {
            _parkingRepo = repo;
        }
        // GET: Locations/GetAll
        public IEnumerable<Location> GetAll()
        {
            return _parkingRepo.GetAllLocations();
        }
        [HttpPost]
        public IEnumerable<Location> AddCar([FromBody] IDictionary<string, object> data)
        {
            _parkingRepo.AddCar ( Convert.ToInt32( data["locationid"].ToString()), data["space"].ToString());
            return _parkingRepo.GetAllLocations();
        }
        [HttpPost]
        public IEnumerable<Location> RemoveCar([FromBody] IDictionary<string, object > data)
        {
            _parkingRepo.RemoveCar(Convert.ToInt32(data["locationid"].ToString()), data["space"].ToString());
            return _parkingRepo.GetAllLocations();
        }
      
    }
}
