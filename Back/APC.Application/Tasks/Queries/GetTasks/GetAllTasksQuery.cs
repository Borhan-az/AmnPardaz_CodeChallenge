using APC.Application.Common.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Queries.GetTasks
{
    public class GetAllTasksQuery : IRequest<List<GetAllTasksResponseDto>>
    {
        public AuditDto Audit { get; set; }
        public GetAllTasksQuery(AuditDto audit)
        {
            Audit = audit;
        }
    }
}