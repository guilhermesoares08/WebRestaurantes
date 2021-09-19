using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Repository;
using WebRestaurantes.Repository.Interfaces;
using WebRestaurantes.Domain;
using AutoMapper;
using WebRestaurantes.WebAPI.Dtos;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
namespace WebRestaurantes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController: ControllerBase
    {
        private readonly IWebRestaurantesRepository _repo;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public SchedulingController(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
         
        [HttpGet("{restaurantId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int restaurantId,[FromBody] ScheduleDate scheduleDate)
        {
            try
            {                
                var results = await _restaurantRepository.GetScheduleByRestaurant(restaurantId);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                string innerEx = "";//ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }
        }       
    }
}