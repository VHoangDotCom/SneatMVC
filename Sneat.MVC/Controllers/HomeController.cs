using Sneat.MVC.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers
{
    public class HomeController : Controller
    {
        public string fullUrl = Utils.getFullUrl();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadFiles(HttpPostedFileBase[] files)
        {
            var listImages = new List<string>();
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        string name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + "-" + InputFileName;
                        var ServerSavePath = Path.Combine(Server.MapPath(@"/Uploads/files/"), name);
                        file.SaveAs(ServerSavePath);

                        // Construct the full URL to access the uploaded file
                        var imageUrl = fullUrl + "/Uploads/files/" + name;
                        listImages.Add(imageUrl);
                    }
                }
            }
            return Json(listImages);
        }

        [HttpPost]
        public JsonResult DeleteFile(string fileName)
        {
            try
            {
                var filePath = Path.Combine(Server.MapPath("~/Uploads/files/"), fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "File not found" });
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Json(new { success = false, message = ex.ToString() });
            }

        }
    } 
}