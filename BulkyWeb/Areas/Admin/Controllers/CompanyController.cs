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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Company> companiesList = _unitOfwork.Company.GetAll().ToList();

            return View(companiesList);
        }


        public ActionResult Upsert(int? id )
        {
             var company =  new Company();
            if (id == null || id == 0) { return View(company); }
            else { 
            Company companyFromDb = _unitOfwork.Company.GetFirstOrDefault(x => x.Id == id);
                if (companyFromDb == null) {
                    return NotFound();
                }
                return View(companyFromDb);
            }
        }

        [HttpPost]
        public ActionResult Upsert(Company company) {
            if (ModelState.IsValid ) {
                if (company == null)
                {
                    _unitOfwork.Company.Add(company);
                }
                else
                {
                    _unitOfwork.Company.Update(company);
                }
                _unitOfwork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(company);
                TempData["error"] = "Error while creating company";
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfwork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public ActionResult Delete(int id) {
            
            var obj = _unitOfwork.Company.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfwork.Company.Remove(obj);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion

    }
}
