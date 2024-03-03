using APC.Application.Common.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Commands.Update
{
    public class UpdateTaskCommand : IRequest<UpdateTaskResponseDto>
    {
        public UpdateTaskRequestDto Todo { get; set; }
        public AuditDto Audit { get; set; }
        public UpdateTaskCommand(AuditDto audit, UpdateTaskRequestDto todo)
        {
            Audit = audit;
            Todo = todo;
        }
    }
}