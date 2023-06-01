using LibraryApi.Controller.Request;
using LibraryApi.Entity;
using LibraryApi.Repository;
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

        [HttpPost()]
        public async Task<IActionResult> Add(CreateUserRequest createUserRequest)
        {
            var user = new User();
            user.Name = createUserRequest.Name;
            user.Document = createUserRequest.Document;
            _repository.Add(user);
            return Ok();
        }

        [HttpGet()]
        public async Task<List<User>> List ()
        {
            return await _repository.GetAll();
        }
        
        [HttpPut("{id}")]
        public async Task Update(Guid id,CreateUserRequest request)
        {
            var user = await _repository.GetById(id);
            user.Name = request.Name;
            user.Document = request.Document;
            _repository.Update(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return NotFound("Id não encontrado.");
            }
            _repository.Delete(user);

            return NoContent();
        }
    }
