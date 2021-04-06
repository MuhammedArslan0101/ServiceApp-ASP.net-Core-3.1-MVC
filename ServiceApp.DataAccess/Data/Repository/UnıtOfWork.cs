using ServiceApp.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceApp.DataAccess.Data.Repository
{
    class UnıtOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnıtOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
