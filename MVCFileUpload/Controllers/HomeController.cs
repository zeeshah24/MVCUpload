
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFileUpload.Models;
using System.IO;

namespace MVCFileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ContentResult UploadFiles()
        {
            var r = new List<FileUploadResult>();
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;
                string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                r.Add(new FileUploadResult()
                {
                    Name=hpf.FileName,
                    Length=hpf.ContentLength,
                    Type=hpf.ContentType
                });
            }
            return Content("{\"name\":\"" +r[0].Name +"\",\"type\":\"" + r[0].Type + "\",\"size\":\""+string.Format("{0} bytes",r[0].Length +"\"}","application/json"));

        }
    }
}
