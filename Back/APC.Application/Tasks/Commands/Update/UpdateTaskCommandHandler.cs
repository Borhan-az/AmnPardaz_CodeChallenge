using APC.Domain.Entities.TodoLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Commands.Update
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResponseDto>
    {
        private readonly IApplicationDbContext _ctx;
        public UpdateTaskCommandHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UpdateTaskResponseDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var todo = await _ctx.Todos.Where(w => w.Id == request.Todo.Id).AsNoTracking().FirstOrDefaultAsync();
            if (todo is null)
                throw new NullReferenceException();

            todo.LastModified = DateTime.Now;
            todo.LastModifiedBy = request.Audit.UserName;
            todo.Title = request.Todo.Title;
            todo.Description = request.Todo.Description;

            _ctx.Todos.Update(todo);
            if (await _ctx.SaveChangesAsync() > 0)
                return new UpdateTaskResponseDto(request.Todo.Id);

            throw new Exception("Internal Error");
        }
    }
}