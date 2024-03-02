using APC.Application.Common.Security.Hashing;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace APC.Application.Auth.Commands.RegisterUser
{

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IApplicationDbContext _ctx;
        public RegisterUserCommandHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var salt = PasswordHasher.GenerateSalt();
            var hash = PasswordHasher.HashPassword(request.Password, salt);

            await _ctx.Users.AddAsync(new Domain.Entities.Users.User(request.UserName, null, Convert.ToBase64String(hash), Convert.ToBase64String(salt)));

            await _ctx.SaveChangesAsync();


            var get = await _ctx.Users.AsNoTracking().ToListAsync();
            return Unit.Value;
        }
    }
}