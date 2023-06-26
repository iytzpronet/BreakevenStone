using LibraryApi.Controller.Request;
using LibraryApi.Entity;
using LibraryApi.Repository;
 using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controller;

    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UserController(IUserRepository userRepository, ITransactionRepository transactionRepository)
        {
            this._userRepository = userRepository;
            _transactionRepository = transactionRepository;
        }

        [HttpPost()]
        public async Task<IActionResult> Add(CreateUserRequest createUserRequest)
        {
            var user = new User();
            user.Name = createUserRequest.Name;
            user.Document = createUserRequest.Document;
            _userRepository.Add(user);
            return Ok();
        }

        [HttpGet()]
        public async Task<List<User>> List()
        {
            return await _userRepository.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }
        
        [HttpPut("{id}")]
        public async Task Update(Guid id,CreateUserRequest request)
        {
            var user = await _userRepository.GetById(id);
            user.Name = request.Name;
            user.Document = request.Document;
            _userRepository.Update(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound("Id não encontrado.");
            }

            if (await VerifyExistTransaction(id))
            {
                return UnprocessableEntity("existem transaçoes pendentes");
            }
        
            _userRepository.Delete(user);

            return NoContent();
        }

        private async Task<bool> VerifyExistTransaction(Guid id)
        {
            var userTransactions = await _transactionRepository.GetCheckoutTransactionsByUserId(id);
            return userTransactions.Count > 0;
        }
    } 
