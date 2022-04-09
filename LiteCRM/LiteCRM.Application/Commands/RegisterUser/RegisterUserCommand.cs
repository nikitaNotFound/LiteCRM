using LiteCRM.Application.Dto;
using MediatR;

namespace LiteCRM.Application.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<RegisterUserResultDto>
{
    public string Email { get; set; }

    public string Password { get; set; }
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResultDto>
{
    public Task<RegisterUserResultDto> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}