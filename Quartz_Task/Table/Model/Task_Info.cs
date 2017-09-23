using System;
using System.ComponentModel;
 

namespace Quartz_Task.Table.Model
{

    [Serializable]
    public class Task_Info
    {
        /// <summary>
        /// id
        /// </summary>
        [DisplayName("id")]
        public long id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [DisplayName("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Mail
        /// </summary>
        [DisplayName("Mail")]
        public string Mail { get; set; }

        /// <summary>
        /// Incident
        /// </summary>
        [DisplayName("Incident")]
        public string Incident { get; set; }

        /// <summary>
        /// BusinessName
        /// </summary>
        [DisplayName("BusinessName")]
        public string BusinessName { get; set; }

        /// <summary>
        /// SendNum
        /// </summary>
        [DisplayName("SendNum")]
        public int? SendNum { get; set; }

        /// <summary>
        /// MessageBack
        /// </summary>
        [DisplayName("MessageBack")]
        public string MessageBack { get; set; }

        /// <summary>
        /// 0发送
        ///1不发送
        /// </summary>
        [DisplayName("0发送1不发送")]
 
         public bool? Status { get; set; }

  

        /// <summary>
        /// TaskID
        /// </summary>
        [DisplayName("TaskID")]
        public string TaskID { get; set; }

        /// <summary>
        /// ReceiveDate
        /// </summary>
        [DisplayName("ReceiveDate")]
        public DateTime? ReceiveDate { get; set; }

    }
}
