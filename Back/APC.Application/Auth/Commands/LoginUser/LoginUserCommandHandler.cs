namespace APC.Application.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponseDto>
    {
        private readonly IApplicationDbContext _ctx;
        public LoginUserCommandHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public Task<LoginUserResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {


            throw new NotImplementedException();
        }
    }
}