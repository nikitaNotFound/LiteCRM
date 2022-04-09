using LiteCRM.Application.Dto;
using MediatR;

namespace LiteCRM.Application.Commands.RegisterApplication;

public class RegisterApplicationCommand : IRequest<RegisterApplicationResultDto>
{
    public string Name { get; set; }

    public string Host { get; set; }
}

public class RegisterApplicationCommandHandler
    : IRequestHandler<RegisterApplicationCommand, RegisterApplicationResultDto>
{
    public Task<RegisterApplicationResultDto> Handle(
        RegisterApplicationCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}