using FluentValidation;
using MyWebApi.Business.Models.Request;

namespace MyWebApi.Business.Validator;

public class CreateUserRequestValidator: AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(u => u.UserName).NotEmpty().NotNull().WithMessage("Имя не может быть пустым");
        RuleFor(u => u.Email).NotEmpty().WithMessage("Почта не может быть пустой");
        RuleFor(u => u.Password).NotEmpty().WithMessage("Пароль не может быть пустым")
            .MinimumLength(8).WithMessage("Длина пароля должна быть минимум 8 символов.")
            .MaximumLength(16).WithMessage("Длина пароля должна быть максимум 16 символов.");
        RuleFor(u => u.Age).NotEmpty().WithMessage("Возраст не должен быть пустым");
        RuleFor(u => u.Age).GreaterThan(15).WithMessage("Возраст должен быть больше 16");
        RuleFor(u => u.Age).LessThan(100).WithMessage("Возраст должен быть меньше 100");
    }
}
