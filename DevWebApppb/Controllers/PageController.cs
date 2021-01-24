using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevWebApppb.Models.ViewModels;
using DevWebApppb.DataAccess;

namespace DevWebApppb.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetInfo()
        {
            DataAccessLayer objUsu = new DataAccessLayer();
            return Json(objUsu.GetData(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInfoUsu(int usuId)
        {
            DataAccessLayer objUsu = new DataAccessLayer();
            return Json(objUsu.GetUsuId(usuId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUser(DatosViewModel usuObj) {

            if (ModelState.IsValid) {
                DataAccessLayer objUsu = new DataAccessLayer();
                string result = objUsu.INSERTDATA(usuObj);
                TempData["usuObj"] = result;
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Error en la insercion de datos");
                return View();
            }
        
        }

        public ActionResult UpdateUser(DatosViewModel usuObj) {

            if (ModelState.IsValid) {
                DataAccessLayer objUsu = new DataAccessLayer();

                string result = objUsu.UPDATEUSER(usuObj);
                TempData["usuObj"] = result;
                return RedirectToAction("index");

            }
            else
            {
                ModelState.AddModelError("", "Error en la insercion de datos");
                return View();
            }
        
        }

        public ActionResult DeleteUser(int usuId) {
            DataAccessLayer objUsu = new DataAccessLayer();
            int result = objUsu.DELETE(usuId);
            TempData["objUsu"] = result;
            ModelState.Clear();

            return RedirectToAction("index");
        }
    }
}