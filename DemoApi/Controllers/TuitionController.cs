using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using DemoApi.Services.Interfaces;
using DemoApi.Exceptions;
using DemoApi.Models;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionController : ControllerBase
    {
        private readonly ICollegeTuitionService _collegeTuitionService;

        public TuitionController(ICollegeTuitionService collegeTuitionService)
        {
            _collegeTuitionService = collegeTuitionService;
        }

        [HttpGet]
        public ActionResult<decimal> Get()
        {
            return NotFound("Error: College name is required");
        }

        [HttpGet("{collegeName}")]
        public ActionResult<decimal> GetInState(string collegeName, [FromQuery] bool includeRoomBoard = false)
        {
            if(string.IsNullOrEmpty(collegeName)) return NotFound("Error: College name is required");

            var query = new TuitionQuery
            {
                IncludeRoomBoard = includeRoomBoard,
                IsInState = true,
                Name = collegeName
            };

            return GetTuitionResult(query);
        }

        [HttpGet("{collegeName}/out-of-state")]
        public ActionResult<decimal> GetOutOfState(string collegeName, [FromQuery] bool includeRoomBoard = false)
        {
            if (string.IsNullOrEmpty(collegeName)) return NotFound("Error: College name is required");

            var query = new TuitionQuery
            {
                IncludeRoomBoard = includeRoomBoard,
                IsInState = false,
                Name = collegeName
            };

            return GetTuitionResult(query);
        }

        private ActionResult<decimal> GetTuitionResult(TuitionQuery query)
        {
            try
            {
                var results = _collegeTuitionService.CalculateTuitionCost(query);

                return Ok(results);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DemoException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}