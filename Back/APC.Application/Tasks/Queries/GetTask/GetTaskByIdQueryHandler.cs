using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Queries.GetTask
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, GetTaskByIdResponseDto>
    {
        private readonly IApplicationDbContext _ctx;
        public GetTaskByIdQueryHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<GetTaskByIdResponseDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _ctx.Todos.Where(x => x.Id == request.TaskId).Select(s => new GetTaskByIdResponseDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                IsChecked = s.IsChecked
            }).AsNoTracking().FirstOrDefaultAsync();

            return task;
        }
    }
}
