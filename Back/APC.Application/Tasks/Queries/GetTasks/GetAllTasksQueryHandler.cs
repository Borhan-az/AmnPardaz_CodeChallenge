using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Queries.GetTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<GetAllTasksResponseDto>>
    {
        private readonly IApplicationDbContext _ctx;
        public GetAllTasksQueryHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<GetAllTasksResponseDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _ctx.Todos.Where(x => x.UserId == request.Audit.UserId)
                  .Select(s => new GetAllTasksResponseDto
                  {
                      Id = s.Id,
                      Description = s.Description,
                      Title = s.Title,
                      IsChecked = s.IsChecked
                  })
                  .AsNoTracking().ToListAsync();
            return tasks;
        }
    }
}