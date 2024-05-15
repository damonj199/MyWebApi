using FluentValidation;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;

namespace MyWebApi.Business.Validator;

public class UpdateUserRequestValidator: AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(u => u.UserName).NotEmpty().NotNull().WithMessage("Заполните поле Имя");
        RuleFor(u => u.Email).NotEmpty().WithMessage("Заполните поле");
        RuleFor(u => u.Age).NotEmpty().WithMessage("Возраст не должен быть пустым")
            .GreaterThan(15).WithMessage("Возраст должен быть больше 16")
            .LessThan(100).WithMessage("Возраст должен быть меньше 100");
    }
}
