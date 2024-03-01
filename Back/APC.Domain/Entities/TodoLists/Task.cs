using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Domain.Entities.TodoLists
{
    public abstract class Task : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; } = false;
        public DateTime SpentTime { get; set; }

    }
}
