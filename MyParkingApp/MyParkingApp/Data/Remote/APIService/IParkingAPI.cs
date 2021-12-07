using MyParkingApp.Data.Remote.APIObjects;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyParkingApp.Data.Remote.APIService
{
    interface IParkingAPI
    {
        [Get("/Locations/GetAll")]
        Task<List<Location>> GetAll();

        [Post("/Locations/AddCar")]
        Task<List<Location>> AddCar([Body(BodySerializationMethod.Serialized)] IDictionary<string, object> data);

        [Post("/Locations/RemoveCar")]
        Task<List<Location>> RemoveCar([Body(BodySerializationMethod.Serialized)] IDictionary<string, object> data);
    }
}
