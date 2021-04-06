﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceApp.DataAccess.Data.Repository.IRepository
{
    interface IUnitOfWork : IDisposable
    {
        // Yonet all of transication in database
        ICategoryRepository Category { get; }
        void Save();

    }
}
