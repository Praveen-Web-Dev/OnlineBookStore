
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        public CategoryController( IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfwork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            
            if (ModelState.IsValid)
            {
                _unitOfwork.Category.Add(obj);
                _unitOfwork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null|| id == 0)
            {
                 return NotFound(); 
            }
            //Category categoryFromdb =_db.Categories.Find(id);
            Category? categoryFromdb = _unitOfwork.Category.GetFirstOrDefault(u=>u.Id==id);
            //Category? categoryFromdb =_db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromdb == null)
            {
                return NotFound();
            }
            return View(categoryFromdb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfwork.Category.Update(obj);
                _unitOfwork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null|| id == 0)
            {
                 return NotFound();
            }
            //Category categoryFromdb =_db.Categories.Find(id);
            Category? categoryFromdb = _unitOfwork.Category.GetFirstOrDefault(u=>u.Id==id);
            //Category? categoryFromdb =_db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromdb == null)
            {
                return NotFound();
            }
            return View(categoryFromdb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfwork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(); 
            }
            _unitOfwork.Category.Remove(obj);
            _unitOfwork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

             
       
        }

       


    }
}
