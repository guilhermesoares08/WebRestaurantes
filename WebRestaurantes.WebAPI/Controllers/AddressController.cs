using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebRestaurantes.Domain.Identity;
using WebRestaurantes.Repository.Interfaces;
using WebRestaurantes.WebAPI.Dtos;
namespace WebRestaurantes.WebAPI.Controllers
{
    public class AddressController
    {
        
        private readonly IWebRestaurantesRepository _repo;
        private readonly IMapper _mapper;

        public AddressController(IWebRestaurantesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}