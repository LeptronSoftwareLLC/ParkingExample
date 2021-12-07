using MyParkingApp.Data.Remote.APIObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyParkingApp.Data.Remote
{
    public interface IParkingServiceAPI
    {
        Task<List<Location>> GetAll();
        Task<List<Location>> AddCar(int locationID, string space);
        Task<List<Location>> RemoveCar(int locationID, string space);
    }
}
