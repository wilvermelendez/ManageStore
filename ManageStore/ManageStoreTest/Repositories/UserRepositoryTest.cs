using AutoMapper;
using ManageStore.BusinessAccess;
using ManageStore.BusinessAccess.Helper;
using ManageStore.BusinessAccess.Repositories;
using ManageStore.Controllers;
using ManageStore.Models.Models;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ManageStoreTest.Repositories
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IUserRepository> _userRepository;

        private Mock<IMapper> _mapper;
        private Mock<ITokenFactory> _tokenFactory;
        private AccountController _accountController;

        [OneTimeSetUp]
        public void Init()
        {


            _userRepository = new Mock<IUserRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Object.Users = _userRepository.Object;

            _mapper = new Mock<IMapper>();
            _tokenFactory = new Mock<ITokenFactory>();
            _accountController = new AccountController(_unitOfWork.Object, _mapper.Object, _tokenFactory.Object);
        }


        [Test]
        public async Task AccountController_Login_Successful_ReturnData()
        {
            //Arrange
            _userRepository.Setup(x => x.FindByCredentials("test", "test".ToSha256()))
                .Returns(Task.FromResult(new User
                {
                    UserName = "test"
                }));
            _unitOfWork.Setup(x => x.Users.FindByCredentials("test", "test".ToSha256()))
                .Returns(Task.FromResult(new User
                {
                    UserName = "test"
                }));

            //Act
            var response = await _accountController.Login(new ManageStore.Models.DTO.UserDto { UserName = "test", Password = "test" });

            //Assert
            _unitOfWork.VerifyAll();

        }
    }
}
