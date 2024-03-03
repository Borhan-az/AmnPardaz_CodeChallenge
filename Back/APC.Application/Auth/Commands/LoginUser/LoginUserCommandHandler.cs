using APC.Application.Common.JWT;
using APC.Application.Common.Security.Hashing;

namespace APC.Application.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponseDto>
    {
        private readonly IApplicationDbContext _ctx;
        private readonly ITokenService _token;
        public LoginUserCommandHandler(IApplicationDbContext ctx, ITokenService token)
        {
            _ctx = ctx;
            _token = token;
        }

        public async Task<LoginUserResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _ctx.Users.Where(x => x.UserName.Trim().ToLower() == request.UserName.Trim().ToLower())
                  .Select(s => new
                  {
                      s.UserName,
                      s.PasswordHash,
                      s.PasswordSalt,
                      s.Id
                  }).AsNoTracking().FirstOrDefaultAsync();

            if (user is null)
                throw new NullReferenceException();

            var verify = PasswordHasher.VerifyPassword(request.Password, user.PasswordSalt, user.PasswordHash);

            if (!verify)
                throw new UnauthorizedAccessException();

            var token = await _token.GenerateToken(user.Id, user.UserName);

            return new LoginUserResponseDto(token);
        }
    }
}