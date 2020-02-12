using DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Services.Interfaces
{
    public interface ICollegeTuitionService
    {
        decimal CalculateTuitionCost(TuitionQuery query);
    }
}
