using Dapper;
using MyParkingAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyParkingAPI.Controllers.Repo
{
    public class ParkingRepo : IParkingRepo
    {
        private readonly IDbConnection _dbConnection;

        public ParkingRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public IEnumerable<Location> GetAllLocations()
        {
            const string sql = @"usp_GetLocations";
            return _dbConnection.Query<Location>(sql, 
                               commandType: CommandType.StoredProcedure);          
           // return _dbConnection.Query<Location>(sql);
        }
        public int AddCar(int LocationID, string spaceName)
        {
            const string sql = @"usp_InsertSpace";
            return _dbConnection.Execute (sql, new { LocationID, Space = spaceName },
                               commandType: CommandType.StoredProcedure);
            
        }
        public int RemoveCar(int LocationID, string spaceName)
        {
            const string sql = @"usp_DeleteSpace";
            return _dbConnection.Execute(sql, new { LocationID, Space = spaceName },
                               commandType: CommandType.StoredProcedure);
        }
    }
}
