﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
