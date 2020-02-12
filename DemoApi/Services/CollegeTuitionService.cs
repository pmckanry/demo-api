using DemoApi.Services.Interfaces;
using System;
using Dapper;
using System.Data;
using DemoApi.Models;
using DemoApi.Exceptions;

namespace DemoApi.Services
{
    public class CollegeTuitionService : ICollegeTuitionService
    {
        private readonly IDbConnection _dbConnection;

        public CollegeTuitionService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public decimal CalculateTuitionCost(TuitionQuery query)
        {
            try
            {
                // TODO : Ignore spaces?
                var result = _dbConnection.QueryFirst<CollegeTuition>(@"
                    select 
                        t.College, 
                        t.InStateTuition, 
                        t.OutStateTuition, 
                        t.RoomBoard 
                    from Tuition t 
                    where lower(t.College) = lower(@Name)", query);

                if (result == null) throw new NotFoundException("Error: College not found");

                return (query.IsInState ? result.InStateTuition : result.OutStateTuition ?? result.InStateTuition) + (query.IncludeRoomBoard ? result.RoomBoard : 0);
            }
            catch(Exception ex)
            {
                throw new DemoException("Error: An unexpected error occured", ex);
            }
        }
    }
}
