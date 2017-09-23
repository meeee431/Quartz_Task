using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Topshelf;
using System.Xml.Serialization;
using Quartz_Task.Base;
namespace Quartz_Task
{
    class Program
    {
        public static Connection connection { get { return _connection; } }
        private static Connection _connection;
        static void Main(string[] args)
        {
            string path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + "\\config.xml";

            if (!System.IO.File.Exists(path)) throw new Exception("未找到配置文件");
            DeSerialize(path);

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            HostFactory.Run(x =>
            {
                x.UseLog4Net();

                x.Service<ServiceRunner>();

                x.SetDescription("查询未处理并超时设定时间的待办事项");
                x.SetDisplayName("待办事项提醒");
                x.SetServiceName("待办事项提醒");

                x.EnablePauseAndContinue();
            });
        }

        private static  void DeSerialize(string path)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Connection));
                FileStream myFileStream = new FileStream(path, FileMode.Open);
                _connection = (Connection)mySerializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("配置文件无效 \r\n" + ex.Message);
            }

        }
    }
}
