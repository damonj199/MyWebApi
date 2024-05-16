using AutoMapper;
using Moq;
using MyWebApi.Business.Models;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
using MyWebApi.Business.Services;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;

namespace MyWebApi.Business.Tests.Services
{
    public class UserServiceTest
    {
        private readonly Mock<IUsersRepository> _usersRepositoryMock;
        private readonly IMapper _mapper;
        public UserServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsersMappingProfile());
            });

            _mapper = new Mapper(config);
            _usersRepositoryMock = new Mock<IUsersRepository>();
        }

        [Fact]
        public void AddUserTest_ValidRequestGuid()
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

            Assert.Equal(expectedGuid, actual);
            _usersRepositoryMock.Verify(r => r.AddUser(It.IsAny<UserDto>()), Times.Once);
        }

        [Fact]
        public void AllUsersTest_ReturnListUsers()
        {
            var expectedList = new List<User>() 
            { new() {Email = "user1@mail.ru" }, 
            { new() {Email = "user2@mail.ru" }}};

            var expectedListDto = new List<UserDto>() 
            { new() { Email = "user1@mail.ru" }, 
            { new() { Email = "user2@mail.ru" }}};

            _usersRepositoryMock.Setup(u => u.GetUsers()).Returns(expectedListDto);

            var sut = new UserServices(_usersRepositoryMock.Object, _mapper);

            var actual = sut.GetUsers();

            actual.Equals(expectedList);
            _usersRepositoryMock.Verify(r => r.GetUsers(), Times.Once);
        }
    }
}
