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
using AutoMapper;
using WebRestaurantes.WebAPI.Dtos;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IWebRestaurantesRepository _repo;
        private readonly IMapper _mapper;

        public RestaurantController(IWebRestaurantesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllRestaurantAsync(true);

                var resultMap = _mapper.Map<IEnumerable<RestaurantDto>>(results);

                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _repo.GetRestaurantAsyncById(id, true);
                var resultMap = _mapper.Map<RestaurantDto>(results);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                string innerEx = "";//ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }
        }

        //  api/values/5
        [HttpGet("getByText/{text}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string text)
        {
            try
            {
                var results = await _repo.GetRestaurantAsyncByText(text);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                string innerEx = ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(RestaurantDto model)
        {
            try
            {
                var resResult = _mapper.Map<Restaurant>(model);
                resResult.CreateDate = DateTime.Now;
                resResult.UpdateDate = DateTime.Now;
                _repo.Add(resResult);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/restaurant/{model.Id}", _mapper.Map<RestaurantDto>(model));
                }
            }
            catch (System.Exception ex)
            {
                string innerEx = ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RestaurantDto model)
        {
            try
            {
                var rest = await _repo.GetRestaurantAsyncById(id);
                if (rest == null) { return NotFound(); };

                var idsAddressess = new List<int>();
                if (model.Address != null && model.Address.Count > 0)
                {
                    model.Address.ForEach(item => idsAddressess.Add(item.Id));
                    var addressess = rest.Address.Where(
                        addr => !idsAddressess.Contains(addr.Id)
                    ).ToArray();

                    if (addressess.Length > 0) _repo.DeleteRange(addressess);
                }
                model.UpdateDate = DateTime.Now.ToString();
                model.CreateDate = rest.CreateDate.ToString();
                _mapper.Map(model, rest);
                _repo.Update(rest);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/restaurant/{model.Id}", _mapper.Map<RestaurantDto>(rest));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{ex.Message}");
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

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou { ex.InnerException }");
            }

            return BadRequest();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }            
        }
    }
}