﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Employee.Permissions.Domain.Primitives
{
    public record DomainEvent(Guid Id) : INotification;

}