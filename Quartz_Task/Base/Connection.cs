using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Quartz_Task.Base
{
    [XmlRoot(ElementName = "Config")]
    [Serializable]
    public class Connection
    {
 
        [XmlElement("Server")]
        public string Server;
        [XmlElement("Database")]
        public string Database;
        [XmlElement("User")]
        public string User;
        [XmlElement("Pass")]
        public string Pass;

        [XmlElement("SmsAddress")]
        public string SmsAddress;

        [XmlElement("SmsCode")]
        public string SmsCode;

        [XmlElement("SmsName")]
        public string SmsName;

        [XmlElement("SmsPwd")]
        public string SmsPwd;

        [XmlElement("FirstOutTime")]
        public int FirstOutTime;

        [XmlElement("SecondOutTime")]
        public int SecondOutTime;

        [XmlElement("ThirdOutTime")]
        public int ThirdOutTime;

        [XmlElement("SendType")]
        public int SendType;

        [XmlElement("FirstSendType")]
        public int FirstSendType;


        [XmlElement("SecondSendType")]
        public int SecondSendType;


        [XmlElement("ThirdSendType")]
        public int ThirdSendType;
 
        [XmlIgnore]
        public string Connstr
        {
            get
            {
                return @"user id=" + User + ";password=" + Pass + ";initial catalog=" + Database + ";data source=" + Server;
            }
        }
    }
 
}