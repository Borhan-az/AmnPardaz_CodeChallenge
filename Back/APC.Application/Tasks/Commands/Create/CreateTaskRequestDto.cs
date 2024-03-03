using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Commands.Create
{
    public class CreateTaskRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}