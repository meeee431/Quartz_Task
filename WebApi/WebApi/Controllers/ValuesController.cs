using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Quartz_Task.Base;
namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {

        [HttpPost]
        public object SetSmsState()
        {
            try
            {
                string id = HttpContext.Current.Request["taskid"];
                DBHelper odb = new DBHelper();
                string sql = string.Format("update Task_Info set status=1 where taskid='{0}'", id);
                int n = odb.Execute(sql);
                if (n <= 0)
                    throw new Exception("未找到相应任务");
            }
            catch (Exception ex)
            {
                return new { status = "error",message=ex.Message  };
            }
            return new { status = "ok" };
        }

 
    }
}