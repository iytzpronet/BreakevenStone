using LibraryApi.Controller;
using LibraryApi.Entity;
using LibraryApi.Repository;
using Moq;


namespace LibraryApi.Tests
{
    public class UserControllerTests
    {
        private readonly UserController _userController;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<ITransactionRepository> _transactionRepository; 
        
        public UserControllerTests()
        { 
            _userRepository = new (); // Instância mocada do UserRepository
            _transactionRepository = new ();//instancia mocada do transactionRepository
            
            _userController = new UserController(_userRepository.Object,_transactionRepository.Object);
        }
        [Fact]
        public async Task GetById_ExistingId_ReturnsUser()
        {
            var userId = Guid.NewGuid();
            var expectedUser = new User { Id = userId, Name = "John Doe" };
            
            _userRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(expectedUser);
            
            var result = await _userController.GetById(userId);
            
            Assert.Equal(expectedUser, result);
        }
    }
}

