﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Commands.Update
{
    public class UpdateTaskResponseDto
    {
        public Guid Id { get; set; }
        public UpdateTaskResponseDto(Guid id)
        {
            Id = id;
        }
    }
}