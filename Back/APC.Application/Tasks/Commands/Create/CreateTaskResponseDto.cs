﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Application.Tasks.Commands.Create
{
    public class CreateTaskResponseDto
    {
        public Guid Id { get; set; }
        public CreateTaskResponseDto(Guid id)
        {
            Id = id;
        }
    }
}