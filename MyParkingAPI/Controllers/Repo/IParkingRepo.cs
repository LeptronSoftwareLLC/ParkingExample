using MyParkingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyParkingAPI.Controllers.Repo
{
    public interface IParkingRepo
    {
        IEnumerable<Location> GetAllLocations();
        int RemoveCar(int LocationID, string spaceName);
        int AddCar(int LocationID, string spaceName);
    }
}
