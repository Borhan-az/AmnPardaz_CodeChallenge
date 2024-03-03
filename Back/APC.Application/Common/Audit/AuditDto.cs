using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Common.Audit
{
    public class AuditDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public AuditDto(Guid userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}