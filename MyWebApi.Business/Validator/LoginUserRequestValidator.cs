using FluentValidation;
using MyWebApi.Business.Models.Request;

namespace MyWebApi.Business.Validator
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {

        }
    }
}
