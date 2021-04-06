using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceApp.DataAccess.Data.Repository.IRepository;

namespace ServiceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Category.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete (int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success=false , message="Error While Deleting" });
            }
            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
