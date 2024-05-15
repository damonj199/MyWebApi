using AutoMapper;
using Moq;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Services;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;

namespace MyWebApi.Business.Tests.Services
{
    public class UserServiceTest
    {
        private const string _guidPattern = "^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$)";
        private readonly Mock<IUsersRepository> _usersRepositoryMock;
        private readonly IMapper _mapper;
        private IUserServices _sut;
        public UserServiceTest()
        {
            _usersRepositoryMock = new Mock<IUsersRepository>();

        }

        [Fact]
        public void AddUserTest()
        {

            var validUserDto = new CreateUserRequest()
            {
                UserName = "Name",
                Password = "password",
                Email = "sobaka@mail.ru",
                Age = 23
            };
            var expectedGuid = Guid.NewGuid();
            _usersRepositoryMock.Setup(x => x.AddUser(It.IsAny<UserDto>())).Returns(expectedGuid);
            var sut = new UserServices(_usersRepositoryMock.Object, _mapper);

            var actual = sut.AddUser(validUserDto);

            Assert.Matches(_guidPattern, actual.ToString());
            Assert.NotEqual("00000000-0000-0000-0000-000000000000", actual.ToString());

        }
    }
}
