using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IApplicationDbContext _ctx;
        public DeleteUserCommandHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _ctx.Users.Where(w => w.Id == request.UserId).AsNoTracking().FirstOrDefaultAsync();


            if (user == null)
                throw new NullReferenceException();

            _ctx.Users.Remove(user);
           
            await _ctx.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
