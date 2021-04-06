﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceApp.DataAccess.Data.Repository.IRepository;
using ServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceApp.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);

            objFromDb.Name = category.Name;
            objFromDb.DisplyOrder = category.DisplyOrder;

            _db.SaveChanges();
        }
    }
}
