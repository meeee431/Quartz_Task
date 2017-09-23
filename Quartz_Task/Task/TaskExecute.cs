using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVelocity.App;
using NVelocity.Runtime;
using NVelocity;
using System.Data;
using Quartz_Task.Base;
using Quartz_Task.Table;
using ImApiDotNet;
using System.Net.Mail;
namespace Quartz_Task.Task
{
 
    public sealed class TaskExecute : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TaskExecute));
        private DBHelper oDB = new DBHelper();
        //已发送信息
        private Table.Business.Task_Info oSendedTask=new Table.Business.Task_Info();
        private Table.Business.Task_SendList oSendedTaskList = new Table.Business.Task_SendList();
        private Table.Business.Process_Step_Time oProcess = new Table.Business.Process_Step_Time();

        VelocityEngine vltEngine = new VelocityEngine();
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                //从数据库查询未执行的待办事项
                string sql = "select  * from JGSTEEL_BPM.dbo.V_WorkFlow_Check  where 1=1 order by starttime ";
                 DataTable oTask  = oDB.GetDataTable(sql );
                DataTable oOutTask = FilterTask(oTask);
                oOutTask = CompareWithDB(oOutTask, oSendedTask.GetAll());
                if (Program.connection.SendType == 0)
                    SendSms(oOutTask, 0);
                else
                    SendMail(oOutTask, 0);

                ////处理已回复的消息
                //ReceiveSms();
                //DeleteFinishTask();
                ////从数据库查询未执行的待办事项
                //string sql = "select top 1  * from JGSTEEL_BPM.dbo.V_WorkFlow_Check  where 1=1 ";
                //string where = "";
                ////查询超过24小时的待办任务
                //where = " and datediff( hour, starttime, getdate())>" + Program.connection.FirstOutTime
                //    + " and  datediff(hour, starttime, getdate()) <= " + Program.connection.SecondOutTime;
                //DataTable oTask24 = oDB.GetDataTable(sql+ where);
                //oTask24=CompareWithDB(oTask24, oSendedTask.GetAll());
                //if (Program.connection.FirstSendType == 0)
                //    SendSms(oTask24, 0);
                //else
                //    SendMail(oTask24, 0);

                //////查询超过48小时的待办任务
                //where = " and datediff( hour, starttime, getdate())>" + Program.connection.SecondOutTime
                //    + " and  datediff(hour,  starttime, getdate()) <= " + Program.connection.ThirdOutTime;
                //DataTable oTask48 = oDB.GetDataTable(sql + where);
                //oTask48 = CompareWithDB(oTask48, oSendedTask.GetAll());
                //if (Program.connection.SecondSendType == 0)
                //    SendSms(oTask48,1);
                //else
                //    SendMail(oTask48, 1);
                //////查询超过72小时的待办任务
                //where = " and datediff( hour, starttime, getdate())>" + Program.connection.ThirdOutTime;
                //DataTable oTask72 = oDB.GetDataTable(sql + where);
                //oTask72 = CompareWithDB(oTask72, oSendedTask.GetAll());

                //if (Program.connection.ThirdSendType == 0)
                //    SendSms(oTask72, 2);
                //else
                //    SendMail(oTask72, 2);

            }
            catch (Exception ex)
            {

                _logger.InfoFormat("执行出错："+ ex.Message );
            }



            
 

        }
        #region "根据工时筛选需发送短消息的任务"
        private DataTable FilterTask(DataTable AllTask)
        {
            try
            {
                List<Quartz_Task.Table.Model.Process_Step_Time> lstRes = oProcess.GetAll("", "");
                AllTask.Columns.Add("OutHour", typeof(string ));
 
                DataTable oReturn = AllTask.Clone();
               
                for (int i = 0; i < AllTask.Rows.Count ; i++)
                {
                    Quartz_Task.Table.Model.Process_Step_Time o=lstRes.Find(s => s.StepID.Trim() == AllTask.Rows[i]["stepid"].ToString().Trim());
                    if (o != null)
                    {
                        //找到超过工时的任务
                        TimeSpan sp = DateTime.Now - DateTime.Parse(AllTask.Rows[i]["starttime"].ToString());
                        if(sp.TotalHours>o.DoHour )
                        {
                             
                            AllTask.Rows[i]["OutHour"] =sp.ToString();
                            oReturn.Rows.Add(AllTask.Rows[i].ItemArray);
                        }
 

                    }
                    else
                    {
                        _logger.InfoFormat("未在工时表中找到此任务：流程名称：" + AllTask.Rows[i]["processname"].ToString().Trim()
                            +",步骤ID：" + AllTask.Rows[i]["stepid"].ToString().Trim()
                            + ",任务ID：" + AllTask.Rows[i]["taskid"].ToString().Trim()
                            + ",接收人：" + AllTask.Rows[i]["receivename"].ToString().Trim());
                    }
                }
                return oReturn;

            }
            catch (Exception ex)
            {

                throw new Exception("筛选短消息出错：" + ex.Message);
            }

        }
        #endregion
        #region "导出已完成的待办事项"
        private void DeleteFinishTask()
        {
            try
            {
                //获取所有待办事项
                string sql = "select  * from JGSTEEL_BPM.dbo.V_WorkFlow_Check  where 1=1  ";

                DataTable oTask = oDB.GetDataTable(sql);
                //获取已发送消息的待办事项
                List<Quartz_Task.Table.Model.Task_Info> oList = oSendedTask.GetAll();
                List<Quartz_Task.Table.Model.Task_Info> oRemove = new List<Quartz_Task.Table.Model.Task_Info>();
                bool have;
                foreach (Quartz_Task.Table.Model.Task_Info item in oList)
                {
                    have = false;
                    for (int i = 0; i < oTask.Rows.Count; i++)
                    {
                        if (item.TaskID.Trim() == oTask.Rows[i]["taskid"].ToString().Trim() && item.Status == false)
                        {
                            have = true;
                            break;
                        }
                    }
                    if (have == false)
                        oRemove.Add(item);
                }
                ExportData(oRemove);

            }
            catch (Exception ex)
            {

                _logger.InfoFormat("删除完成任务出错：" + ex.Message);
            }

        }
        private void ExportData(List<Quartz_Task.Table.Model.Task_Info> oList)
        {
            Table.Business.Task_Info_His oBrHis = new Table.Business.Task_Info_His();
            Table.Model.Task_Info_His oModel = new Table.Model.Task_Info_His();

            foreach (Quartz_Task.Table.Model.Task_Info item in oList)
            {
                DataTable oTable = oSendedTask.GetByID(item.id);
                for (int i = 0; i < oTable.Rows.Count; i++)
                {
                    oModel.Name = oTable.Rows[i]["Name"].ToString();
                    oModel.Phone = oTable.Rows[i]["Phone"].ToString();
                    oModel.Mail = oTable.Rows[i]["Mail"].ToString();
                    oModel.Incident = oTable.Rows[i]["Incident"].ToString();
                    oModel.BusinessName = oTable.Rows[i]["BusinessName"].ToString();
                    oModel.ReceiveDate = DateTime.Parse(oTable.Rows[i]["ReceiveDate"].ToString());

                    oModel.MessageBack = oTable.Rows[i]["MessageBack"].ToString();
                    oModel.Status = bool.Parse(oTable.Rows[i]["Status"].ToString());

                    oModel.TaskID = oTable.Rows[i]["TaskID"].ToString();


                    oModel.SendDate = DateTime.Parse(oTable.Rows[i]["SendDate"].ToString());
                    oModel.SendType = int.Parse(oTable.Rows[i]["SendType"].ToString());
                    oModel.TimeType = int.Parse(oTable.Rows[i]["TimeType"].ToString());
                    oModel.SrcID = int.Parse(oTable.Rows[i]["SrcID"].ToString());
                    oBrHis.Add(oModel);
                }
                oSendedTaskList.DeleteByTask(item.id);
                oSendedTask.Delete(item.id);

            }
        }

        #endregion

        //与本地已发送的信息进行比较，并把没的数据插入到里面
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oTask">已超时处理的任务</param>
        private DataTable  CompareWithDB(DataTable oTask, List<Quartz_Task.Table.Model.Task_Info> oSend)
        {
            if (oSend.Count > 0)
 
            {
                for (int i = 0; i < oTask.Rows.Count; i++)
                {
                    foreach (  Quartz_Task.Table.Model.Task_Info item in oSend)
                    {
                        //短信回复不发送
                        if (oTask.Rows[i]["taskid"].ToString() == item.TaskID.ToString() && item.Status == true)
                        {
                            oTask.Rows[i].Delete();
                            break;
                        }
                        //如果已经发送3次的
                        if (oTask.Rows[i]["taskid"].ToString() == item.TaskID.ToString() && item.SendNum == 3)
                        {
                            oTask.Rows[i].Delete();
                            break;
                        }
                    }
 
                   
                }
                oTask.AcceptChanges();

            }
            return oTask;

        }

        private void InsertUpdateTable(DataRow oTask, int SendType,int TimeType) {
            Table.Model.Task_Info oAdd = new Table.Model.Task_Info();
            Table.Model.Task_SendList oAddList = new Table.Model.Task_SendList();
            string id = oTask["taskid"].ToString();
            Table.Model.Task_Info oExist = oSendedTask.GetByTaskID(id);
            if (oExist == null)
            {
                oAdd.Name = oTask["ReceiveName"].ToString();
                oAdd.Phone = oTask["phone"].ToString();
                oAdd.Mail = oTask["email"].ToString();
                oAdd.Incident = oTask["incident"].ToString();
                oAdd.BusinessName = oTask["processname"].ToString();
                oAdd.ReceiveDate  = DateTime.Parse(oTask["starttime"].ToString());
                //oAdd.SendDate = DateTime.Now ;

                oAdd.SendNum = 1;
                oAdd.MessageBack = "";
                oAdd.Status = false;
                //oAdd.SrcID = int.Parse(oTask["SrcID"].ToString());
                oAdd.TaskID = oTask["taskid"].ToString() ;
                //oAdd.SendType = SendType;
                //oAdd.TimeType = TimeType;
                long nNewID=  oSendedTask.Add(oAdd);

                oAddList.task = nNewID;
                oAddList.SendDate = DateTime.Now;
                oAddList.SendType = SendType;
                oAddList.TimeType = TimeType;
                oAddList.SrcID = int.Parse(oTask["SrcID"].ToString());
                oSendedTaskList.Add(oAddList);
            }
            else
            {

                oExist.SendNum += 1;
                oSendedTask.Update(oExist);

                oAddList.task = oExist.id;
                oAddList.SendDate = DateTime.Now;
                oAddList.SendType = SendType;
                oAddList.TimeType = TimeType;
                oAddList.SrcID = int.Parse(oTask["SrcID"].ToString());
                oSendedTaskList.Add(oAddList);

            }




        }
        /// <summary>
        /// 合并消息模板
        /// </summary>
        /// <param name="oRow"></param>
        /// <returns></returns>
        private string GetSMS(DataRow oRow,int nTemplete  = 0)
        {
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.IO.Directory.GetCurrentDirectory() + "/Templates");
            //模板文件所在的文件夹
            vltEngine.Init();
            VelocityContext vltContext = new VelocityContext();

            vltContext.Put("dt", oRow);
            //计算超时间
            //DateTime now = DateTime.Now ;
            TimeSpan sp = TimeSpan.Parse(oRow["OutHour"].ToString());
            string outtime = string.Format("{0}天{1}小时{2}分", sp.Days, sp.Hours, sp.Minutes);// Convert.ToDateTime(sp.ToString()).ToString("HH小时mm分");
            vltContext.Put("outTime", outtime);

            string temp = "";
            if (nTemplete == 0)
                temp = "sms.tlp";
            else
                temp = "mail.tlp";
            Template vltTemplate = vltEngine.GetTemplate(temp);//设定模板  
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            vltTemplate.Merge(vltContext, vltWriter);

            string szSMS = vltWriter.GetStringBuilder().ToString();

            return szSMS;

        }
        #region"短消息"


        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="oTask"></param>
        private void SendSms(DataTable oTask, int nType)
        {
            try
            {
                if (oTask.Columns.Contains("SrcID") == false)
                    oTask.Columns.Add("SrcID", typeof(long));
                long id = 0;
                for (int i = 0; i < oTask.Rows.Count; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    try
                    {
                        string sms = GetSMS(oTask.Rows[i]);
                        _logger.InfoFormat(sms);
                        if (oTask.Rows[i]["phone"].ToString() == "")
                            throw new Exception("用户：" + oTask.Rows[i]["ReceiveName"].ToString() + "手机号为空");
                        id = ImApi.SendMessage(oTask.Rows[i]["phone"].ToString(), sms);

                    }
                    catch (Exception ex)
                    {

                        _logger.InfoFormat("短信发送失败：" + ex.Message);
                        continue;
                    }

                    oTask.Rows[i]["SrcID"] = id;
                    InsertUpdateTable(oTask.Rows[i], 0, nType);
                }

            }
            catch (Exception ex)
            {
                _logger.InfoFormat("插入数据库失败：" + ex.Message);

            }

        }

        /// <summary>
        /// 接收短消息
        /// </summary>
        private void ReceiveSms()
        {
            List<Quartz_Task.Table.Model.Task_Info> oList = oSendedTask.GetAll();
            foreach (Quartz_Task.Table.Model.Task_Info item in oList)
            {
                List<Quartz_Task.Table.Model.Task_SendList> oList2 = oSendedTaskList.GetAll(item.id);
                foreach (Quartz_Task.Table.Model.Task_SendList itemlist in oList2)
                {
                    MOItem[] oReturn = ImApi.Receive(itemlist.SrcID.Value);
                    if (oReturn != null)
                        for (int i = 0; i < oReturn.Length; i++)
                        {
                            if (oReturn[i].getMobile() == item.Phone && oReturn[i].getContent().IndexOf("0") >= 0)
                            {
                                item.Status = true;
                                item.MessageBack = oReturn[i].getContent();
                                oSendedTask.Update(item);
                            }
                        }
                }


            }


        }
        #endregion

        #region "邮件"
        private void SendMail(DataTable oTask, int nType)
        {
            try
            {
                if(oTask.Columns.Contains("SrcID")==false)
                    oTask.Columns.Add("SrcID", typeof(long));
                long id = 0;
                for (int i = 0; i < oTask.Rows.Count; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    try
                    {
                        string sms = GetSMS(oTask.Rows[i],1);
                        _logger.InfoFormat(sms);
                        if (oTask.Rows[i]["email"].ToString() == "")
                            throw new Exception("用户：" + oTask.Rows[i]["ReceiveName"].ToString() + "邮箱为空");

                        Mail.SendMail(oTask.Rows[i]["email"].ToString(), sms);  

                    }
                    catch (Exception ex)
                    {

                        _logger.InfoFormat("邮件发送失败：" + ex.Message);
                        continue;
                    }

                    oTask.Rows[i]["SrcID"] = id;
                    InsertUpdateTable(oTask.Rows[i], 1, nType);
                }

            }
            catch (Exception ex)
            {
                _logger.InfoFormat("插入数据库失败：" + ex.Message);

            }

        }

        #endregion
    }
}
