using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Users.Queries.GetUsers
{
    public class GetAllUserResponseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
