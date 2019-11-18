using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Repository.DataContext;
using WebRestaurantes.Repository.Interfaces;
using WebRestaurantes.Domain;


namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IWebRestaurantesRepository _repo;

        public RestaurantController(IWebRestaurantesRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllRestaurantAsync(true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _repo.GetRestaurantAsyncById(id);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // GET api/values/5
        [HttpGet("getByText/{text}")]
        public async Task<IActionResult> Get(string text)
        {
            try
            {
                var results = await _repo.GetRestaurantAsyncByText(text);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Restaurant model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChanges())
                {
                    return Created($"/api/restaurant/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Restaurant model)
        {
            try
            {
                var rest = await _repo.GetRestaurantAsyncById(id);
                if (rest == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChanges())
                {
                    return Created($"/api/restaurant/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

             return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var rest = await _repo.GetRestaurantAsyncById(id);
                if (rest == null) return NotFound();

                _repo.Delete(rest);

                if (await _repo.SaveChanges())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

             return BadRequest();
        }
    }
}