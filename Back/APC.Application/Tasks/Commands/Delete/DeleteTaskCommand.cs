using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Commands.Delete
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public DeleteTaskCommand(Guid taskId, Guid userId)
        {
            TaskId = taskId;
            UserId = userId;
        }
    }
}