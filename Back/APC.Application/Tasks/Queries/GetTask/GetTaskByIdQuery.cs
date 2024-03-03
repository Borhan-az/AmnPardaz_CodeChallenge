using APC.Application.Common.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Queries.GetTask
{
    public class GetTaskByIdQuery : IRequest<GetTaskByIdResponseDto>
    {
        public Guid TaskId { get; set; }
        public GetTaskByIdQuery(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}