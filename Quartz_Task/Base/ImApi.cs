using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImApiDotNet;
using Quartz_Task;
namespace Quartz_Task.Base
{
    public class ImApi
    {
        private static ImApiDotNet.APIClient apiclient;
        private static Table.Business.Task_Info oSendedTask = new Table.Business.Task_Info();
        public ImApi()
        {
        }

        public static long SendMessage(string mobileStr, string contentStr)
        {
             
            long srcID = 0;
            try
            {
                if (apiclient == null)
                {
                    apiclient = new APIClient();

                    int con = apiclient.init(Program.connection.SmsAddress, Program.connection.SmsName, Program.connection.SmsPwd, Program.connection.SmsCode, "mas");
                    con = System.Math.Abs(con);
                    if (con != 0)
                    {
                        throw new Exception("短信初使化失败");
                    }
                }

                Random r = new Random();
                long strID = 0;
                //判断现有的随机数据是否已经数据库表中
                while (true)
                {
                    strID = r.Next(0, 999999);
                    if (ExistCode(strID) == false)
                        break;
                }
              


                long smID = strID;
                srcID = strID;
                String sendTime = DateTime.Now.ToString();
                int sm = 1;
                sm = apiclient.sendSM(mobileStr.Split(';'), contentStr, null, smID, srcID);

                //sm = 0;
                sm = System.Math.Abs(sm);
                if (sm == 0)
                {
    
                }
                else
                {
                    throw new Exception("短消息发送失败");
                }
                
            }
            catch (Exception ex)
            {
 
                throw ex;
            }
            finally
            {
                apiclient.release();
                apiclient = null;
            }
            return srcID;
        }
        public static MOItem[] Receive(int srcID)
        {

            try
            {
                if (apiclient == null)
                {
                    apiclient = new APIClient();

                    int con = apiclient.init(Program.connection.SmsAddress, Program.connection.SmsName, Program.connection.SmsPwd, Program.connection.SmsCode, "mas");
                    con = System.Math.Abs(con);
                    if (con != 0)
                    {
                        throw new Exception("短信初使化失败");
                    }
                }
                MOItem[] mo = apiclient.receiveSM(srcID, 10);
                return mo;
            }
            catch (Exception ex)
            {
                Console.WriteLine("短消息发送出错：" + ex.ToString());
                return null;
            }
            finally
            {
                apiclient.release();
                apiclient = null;
            }
        }
        private static bool ExistCode(long id)
        {

            return oSendedTask.ExistCode(id);

        }
    }

}
