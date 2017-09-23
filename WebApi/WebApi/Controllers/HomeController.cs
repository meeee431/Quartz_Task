using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JGSTEEL.Data.Model;
namespace WebApi.Controllers
{
 
    public class HomeController : Controller
    {
        JGSTEEL.Business.Applications.Process_Step_Time br = new JGSTEEL.Business.Applications.Process_Step_Time();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDepartment(int limit, int offset, string processname, string stepname)
        {
 
            List<Process_Step_Time> lstRes=br.GetAll(processname,stepname);

            var total = lstRes.Count;
            var rows = lstRes.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult  GetEdit(Process_Step_Time item)
        {
            try
            {
                Process_Step_Time o= br.Get(item.id);
                if (o == null)
                    br.Add(item);
                else
                    br.Update(item);
                return Json(new { status = "ok"  });
            }
            catch (Exception ex)
            {

                return Json(new { status = "error", message = ex.Message  });
            }
        }
        public ActionResult Delete(string id)
        {
            try
            {
                int o = br.Delete(long.Parse(id));
                if (o <= 0)
                    throw new Exception("删除记录失败");
                return Json(new { status = "ok" });
            }
            catch (Exception ex)
            {

                return Json(new { status = "error", message = ex.Message });
            }
        }
        
    }
}
