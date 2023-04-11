using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Entity;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controller;

    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            this._repository = repository;
        }
        [HttpPost("Add")]
        public void Add(User user)
        {
            _repository.Add(user);
        }
        [HttpGet("List")]
        public async Task<List<User>> List ()
        {
            return await _repository.GetAll();
        }
    }

