using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Commands.Delete
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly IApplicationDbContext _ctx;
        public DeleteTaskCommandHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _ctx.Todos.Where(x => x.Id == request.TaskId).AsNoTracking().FirstOrDefaultAsync();
            if (task is null)
                throw new NullReferenceException();

            _ctx.Todos.Remove(task);
            if (await _ctx.SaveChangesAsync() > 0)
                return Unit.Value;

            throw new Exception("InternalError");
        }
    }
}