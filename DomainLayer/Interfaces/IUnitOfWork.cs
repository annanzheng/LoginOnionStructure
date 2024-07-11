﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepo StudentRepo { get; }
        int complete(); 
    }
}
