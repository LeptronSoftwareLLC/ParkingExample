using MyParkingApp.Data.Remote.APIObjects;
using MyParkingApp.Data.Remote.APIService;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyParkingApp.Data.Remote
{
    class ParkingServiceAPI : IParkingServiceAPI
    {
        const string _url = "http://10.0.2.2/MyParkingAPI";
        IParkingAPI _apiObject;
        public ParkingServiceAPI()
        {
            _apiObject = RestService.For<IParkingAPI>(_url);
        }
        async public Task<List<Location>> GetAll()
        {
            try
            {                               
                return await _apiObject.GetAll();
            }
            catch (Exception ex)
            {
                //TODO: log error
                return new List<Location>();
            }
        }
        async public Task<List<Location>> AddCar(int locationID, string space)
        {
            try
            {
                var data = new Dictionary<string, object> {
                    {"locationid", locationID},
                    {"space", space}
                };
              
                return await _apiObject.AddCar(data);                
            }
            catch (Exception ex)
            {
                //TODO: log error here to AppCenter etc
                return new List<Location>();
            }
        }
        async public Task<List<Location>> RemoveCar(int locationID, string space)
        {
            try
            {
                var data = new Dictionary<string, object> {
                    {"locationid", locationID},
                    {"space", space}
                };
              
                return await _apiObject.RemoveCar(data);
            }
            catch (Exception ex)
            {
                //TODO: log error here to AppCenter etc
                return new List<Location>();
            }
        }
    }
}
